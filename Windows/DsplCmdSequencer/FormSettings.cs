using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace DsplCmdSequencer
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private string[] TrimNullTerminatedPortNames()
        {
            int nPorts = SerialPort.GetPortNames().Length;
            string[] cleanPortNames = new string[nPorts];

            for ( int i=0; i < nPorts; i++)
            {
                cleanPortNames[i] = SerialPort.GetPortNames()[i].Split('\0')[0];
            }
            return cleanPortNames;
        }
        private void FormSettings_Load(object sender, EventArgs e)
        {
            // array of supported baudrates
            int[] _BaudRates = { 1200, 4800, 9600, 19200, 38400, 57600, 115200 };

            // fills combobox with baud rates
            for (int i = 0; i < _BaudRates.Length; i++)
            {
                comboBoxBaudRate.Items.Add(_BaudRates[i].ToString());
            }

            // selects currently configured baud rate
            comboBoxBaudRate.SelectedItem = Config.CurrentConfig.BaudRate.ToString();

            // enumerates available serial ports
            for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
            {
                comboBoxPortNum.Items.Add(TrimNullTerminatedPortNames()[i]);
            }

            // selects currently configured serial port (or first port, if not configured)
            if (Config.CurrentConfig.SerialPortName == "")
                Config.CurrentConfig.SerialPortName = TrimNullTerminatedPortNames()[0];
            comboBoxPortNum.SelectedItem = Config.CurrentConfig.SerialPortName;

        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.BaudRate = Convert.ToInt32(comboBoxBaudRate.Items[comboBoxBaudRate.SelectedIndex].ToString());
            Config.CurrentConfig.SerialPortName = comboBoxPortNum.Items[comboBoxPortNum.SelectedIndex].ToString();
        }
    }
}
