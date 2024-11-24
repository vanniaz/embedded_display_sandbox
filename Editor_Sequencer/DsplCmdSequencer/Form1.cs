using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;

namespace DsplCmdSequencer
{
    public partial class Form1 : Form
    {
        private readonly Config cfg = new Config();
        SerialComm sc = new SerialComm();

        struct Command
        {
            public string CmdCode;
            public string FunctionPrototype;

            public Command(string cmd_code, string prototype)
            {
                this.CmdCode = cmd_code;
                this.FunctionPrototype = prototype;
            }
        }

        Dictionary<string, Command> CmdDict = new Dictionary<string, Command>();

        Color TxColor = Color.Red;
        Color RxColor = Color.Blue;

        const int MAX_CONN_ATTEMPTS = 3;

        public Form1()
        {
            InitializeComponent();
            Config.CurrentConfig.LoadFromFile("Config.xml");
            checkBoxEditRaw.Checked = Config.CurrentConfig.EditRaw;
            try
            {
                foreach (string line in File.ReadLines("commands.csv"))
                {
                    string shortCmd = line.Split(';')[0];
                    string template = line.Split(';')[1];
                    string u8g2Cmd = template.Split('(')[0];
                    string proto = line.Split(';')[2];
                    CmdDict[u8g2Cmd] = new Command(shortCmd, proto);
                    //comboBoxCommands.Items.Add(shortCmd + " " + u8g2Cmd);
                    comboBoxFunction.Items.Add(template);
                }
            }
            catch ( Exception exc )
            {
                MessageBox.Show("Error loading command table: " + exc.Message);
                this.Close();
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textBoxEditCommands.Text = File.ReadAllText(openFileDialog1.FileName);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, textBoxEditCommands.Text);
        }

        public void AppendLine(RichTextBox box, string text, Color color, bool new_line)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            if ( new_line)
            {
                box.AppendText(Environment.NewLine);
            }
            box.SelectionColor = box.ForeColor;
        }

        string ParseSourceCommand ( string cmdstr )
        {
            string tmpstr;
            string[] arguments;
            char[] separators = { '(', ')' };

            if (!cmdstr.StartsWith(textBoxClassInstanceName.Text + "."))
            {
                return null;
            }
            tmpstr = cmdstr.Substring(textBoxClassInstanceName.Text.Length + 1);
            arguments = tmpstr.Split(separators);

            if ( !CmdDict.ContainsKey(arguments[0] ))
            {
                return null;
            }

            tmpstr = CmdDict[arguments[0]].CmdCode;

            if (arguments[1] != "")
            {
                tmpstr = tmpstr + " " + arguments[1];
            }

            return tmpstr.Replace("\"", "");   // double hyphens are not required for strings in serial messages
        }


        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            string rx = "";
            string tx = "";

            if ( !sc.Open(Config.CurrentConfig.SerialPortName, Config.CurrentConfig.BaudRate ))
            { 
                MessageBox.Show("COM port open error");
                return;
            }
            // tries to sync with MCU
            int attempts = 0;
            do
            {
                sc.WriteLine(Environment.NewLine);
                Thread.Sleep(100);
                rx = sc.ReadLine();
                if (++attempts == MAX_CONN_ATTEMPTS)
                {
                    MessageBox.Show("No response from MCU");
                    sc.Close();
                    return;
                }
            }
            while (rx != "?");
            sc.Flush();

            // get active fonts list
            comboBoxFonts.Enabled = true;
            comboBoxFonts.Items.Clear();
            comboBoxFonts.Text = "Loading font list from MCU...";

            sc.WriteLine("FOL");
            do
            {
                rx = sc.ReadLine();
                if (rx != "END")
                {
                    comboBoxFonts.Items.Add(rx);
                }
            }
            while (rx != "END");
            comboBoxFonts.SelectedIndex = 0;
            comboBoxFonts.Update();
            sc.Flush();

            // send individual commands and wait for reply from MCU
            if (textBoxEditCommands.Lines.Length > 0)
            {
                richTextBoxOutputLog.Clear();
                foreach (string cmd in textBoxEditCommands.Lines)
                {
                    if (cmd != "")    // skip empty lines
                    {
                        if ( !Config.CurrentConfig.EditRaw )
                        {
                            tx = ParseSourceCommand(cmd);
                            if ( tx == null )
                            {
                                MessageBox.Show("Invalid command: " + cmd);
                                break;
                            }
                        }
                        else
                        {
                            tx = cmd;
                        }
                        sc.WriteLine(tx);
                        AppendLine(richTextBoxOutputLog, tx, TxColor, true);
                        richTextBoxOutputLog.Update();
                        do
                        {
                            rx = sc.ReadLine();
                            if (rx == "")
                            {
                                MessageBox.Show("No response from MCU");
                                break;
                            }
                            AppendLine(richTextBoxOutputLog, rx, RxColor, true);
                            richTextBoxOutputLog.Update();
                        }
                        while (sc.Available() > 0);
                    }
                }
            }
            else
            {
                MessageBox.Show("No commands to send");
            }
            sc.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.CurrentConfig.SaveToFile("Config.xml");
        }

        private void comboBoxFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string u8g2Cmd = comboBoxFunction.Text.Split('(')[0];
            textBoxCommand.Text = CmdDict[u8g2Cmd].CmdCode;
            textBoxPrototype.Text = CmdDict[u8g2Cmd].FunctionPrototype;
        }

        private void buttonCallMCU_Click(object sender, EventArgs e)
        {
            string rx = "";

            if (!sc.Open(Config.CurrentConfig.SerialPortName, Config.CurrentConfig.BaudRate))
            {
                MessageBox.Show("COM port open error");
                return;
            }
            // tries to sync with MCU
            int attempts = 0;
            do
            {
                sc.WriteLine(Environment.NewLine);
                Thread.Sleep(100);
                rx = sc.ReadLine();
                if (++attempts == MAX_CONN_ATTEMPTS)
                {
                    MessageBox.Show("No response from MCU");
                    sc.Close();
                    return;
                }
            }
            while (rx != "?");
            sc.Flush();

            // get active fonts list
            comboBoxFonts.Enabled = true;
            comboBoxFonts.Items.Clear();
            comboBoxFonts.Text = "Loading font list from MCU...";

            sc.WriteLine("FOL");
            do
            {
                rx = sc.ReadLine();
                if (rx != "END")
                {
                    comboBoxFonts.Items.Add(rx);
                }
            }
            while (rx != "END");
            comboBoxFonts.SelectedIndex = 0;
            comboBoxFonts.Update();
            sc.Flush();

            sc.Close();
            MessageBox.Show("Connection OK");
        }

        private void buttonInsertCommand_Click(object sender, EventArgs e)
        {
            string txt2insert;

            if ( Config.CurrentConfig.EditRaw )
            {
                txt2insert = textBoxCommand.Text;
            }
            else
            {
                txt2insert = textBoxClassInstanceName.Text + "." + comboBoxFunction.Text + ";" + Environment.NewLine;
            }
            // if command requires a font name, inserts currently selected font name
            if (txt2insert.Contains("@f"))
            {
                if (comboBoxFonts.Items.Count > 0)
                {
                    txt2insert = txt2insert.Replace("@f", comboBoxFonts.Text);
                }
                else
                {
                    txt2insert = txt2insert.Replace("@f", "f");
                }
            }
            textBoxEditCommands.Text = textBoxEditCommands.Text.Insert(textBoxEditCommands.SelectionStart, txt2insert);
            textBoxEditCommands.SelectionStart += txt2insert.Length;
            textBoxEditCommands.Update();
        }

        private void buttonInsertFont_Click(object sender, EventArgs e)
        {
            string txt2insert = comboBoxFonts.Text;
            textBoxEditCommands.Text = textBoxEditCommands.Text.Insert(textBoxEditCommands.SelectionStart, txt2insert);
            textBoxEditCommands.SelectionStart += txt2insert.Length;
            textBoxEditCommands.Update();
        }

        private void checkBoxEditRaw_CheckedChanged(object sender, EventArgs e)
        {
            Config.CurrentConfig.EditRaw = checkBoxEditRaw.Checked;
        }
    }
}