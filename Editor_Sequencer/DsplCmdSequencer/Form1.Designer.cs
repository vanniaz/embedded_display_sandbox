using System.Windows.Forms;

namespace DsplCmdSequencer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSettings = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.textBoxEditCommands = new System.Windows.Forms.TextBox();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxOutputLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxCommandHelpers = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxClassInstanceName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPrototype = new System.Windows.Forms.TextBox();
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.comboBoxFunction = new System.Windows.Forms.ComboBox();
            this.buttonInsertFont = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonInsertCommand = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCallMCU = new System.Windows.Forms.Button();
            this.checkBoxEditRaw = new System.Windows.Forms.CheckBox();
            this.groupBoxCommandHelpers.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(541, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(82, 22);
            this.buttonSettings.TabIndex = 0;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(82, 22);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Location = new System.Drawing.Point(100, 12);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(82, 23);
            this.buttonSendFile.TabIndex = 2;
            this.buttonSendFile.Text = "Send File";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // textBoxEditCommands
            // 
            this.textBoxEditCommands.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEditCommands.Location = new System.Drawing.Point(12, 85);
            this.textBoxEditCommands.Multiline = true;
            this.textBoxEditCommands.Name = "textBoxEditCommands";
            this.textBoxEditCommands.Size = new System.Drawing.Size(299, 282);
            this.textBoxEditCommands.TabIndex = 4;
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Location = new System.Drawing.Point(188, 12);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(82, 22);
            this.buttonSaveFile.TabIndex = 8;
            this.buttonSaveFile.Text = "Save File";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Command Editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Communication Log";
            // 
            // richTextBoxOutputLog
            // 
            this.richTextBoxOutputLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxOutputLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxOutputLog.Location = new System.Drawing.Point(323, 85);
            this.richTextBoxOutputLog.Name = "richTextBoxOutputLog";
            this.richTextBoxOutputLog.ReadOnly = true;
            this.richTextBoxOutputLog.Size = new System.Drawing.Size(300, 282);
            this.richTextBoxOutputLog.TabIndex = 12;
            this.richTextBoxOutputLog.Text = "";
            this.richTextBoxOutputLog.WordWrap = false;
            // 
            // groupBoxCommandHelpers
            // 
            this.groupBoxCommandHelpers.Controls.Add(this.label7);
            this.groupBoxCommandHelpers.Controls.Add(this.textBoxClassInstanceName);
            this.groupBoxCommandHelpers.Controls.Add(this.label6);
            this.groupBoxCommandHelpers.Controls.Add(this.textBoxCommand);
            this.groupBoxCommandHelpers.Controls.Add(this.label5);
            this.groupBoxCommandHelpers.Controls.Add(this.textBoxPrototype);
            this.groupBoxCommandHelpers.Controls.Add(this.comboBoxFonts);
            this.groupBoxCommandHelpers.Controls.Add(this.comboBoxFunction);
            this.groupBoxCommandHelpers.Controls.Add(this.buttonInsertFont);
            this.groupBoxCommandHelpers.Controls.Add(this.label4);
            this.groupBoxCommandHelpers.Controls.Add(this.buttonInsertCommand);
            this.groupBoxCommandHelpers.Controls.Add(this.label3);
            this.groupBoxCommandHelpers.Location = new System.Drawing.Point(12, 392);
            this.groupBoxCommandHelpers.Name = "groupBoxCommandHelpers";
            this.groupBoxCommandHelpers.Size = new System.Drawing.Size(611, 223);
            this.groupBoxCommandHelpers.TabIndex = 13;
            this.groupBoxCommandHelpers.TabStop = false;
            this.groupBoxCommandHelpers.Text = "Assisted Commands";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "U8G2 Instance Name";
            // 
            // textBoxClassInstanceName
            // 
            this.textBoxClassInstanceName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClassInstanceName.Location = new System.Drawing.Point(27, 56);
            this.textBoxClassInstanceName.Name = "textBoxClassInstanceName";
            this.textBoxClassInstanceName.Size = new System.Drawing.Size(107, 23);
            this.textBoxClassInstanceName.TabIndex = 23;
            this.textBoxClassInstanceName.Text = "u8g2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Serial Command";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommand.Location = new System.Drawing.Point(394, 57);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ReadOnly = true;
            this.textBoxCommand.Size = new System.Drawing.Size(78, 23);
            this.textBoxCommand.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Function Prototype";
            // 
            // textBoxPrototype
            // 
            this.textBoxPrototype.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrototype.Location = new System.Drawing.Point(27, 107);
            this.textBoxPrototype.Name = "textBoxPrototype";
            this.textBoxPrototype.ReadOnly = true;
            this.textBoxPrototype.Size = new System.Drawing.Size(566, 23);
            this.textBoxPrototype.TabIndex = 19;
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.Enabled = false;
            this.comboBoxFonts.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(27, 180);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(490, 23);
            this.comboBoxFonts.TabIndex = 18;
            this.comboBoxFonts.Text = "Font list will be available after MCU connection";
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Location = new System.Drawing.Point(158, 56);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(210, 23);
            this.comboBoxFunction.TabIndex = 17;
            this.comboBoxFunction.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunction_SelectedIndexChanged);
            // 
            // buttonInsertFont
            // 
            this.buttonInsertFont.Location = new System.Drawing.Point(538, 180);
            this.buttonInsertFont.Name = "buttonInsertFont";
            this.buttonInsertFont.Size = new System.Drawing.Size(55, 21);
            this.buttonInsertFont.TabIndex = 16;
            this.buttonInsertFont.Text = "Insert";
            this.buttonInsertFont.UseVisualStyleBackColor = true;
            this.buttonInsertFont.Click += new System.EventHandler(this.buttonInsertFont_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Font";
            // 
            // buttonInsertCommand
            // 
            this.buttonInsertCommand.Location = new System.Drawing.Point(538, 55);
            this.buttonInsertCommand.Name = "buttonInsertCommand";
            this.buttonInsertCommand.Size = new System.Drawing.Size(55, 21);
            this.buttonInsertCommand.TabIndex = 13;
            this.buttonInsertCommand.Text = "Insert";
            this.buttonInsertCommand.UseVisualStyleBackColor = true;
            this.buttonInsertCommand.Click += new System.EventHandler(this.buttonInsertCommand_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Function";
            // 
            // buttonCallMCU
            // 
            this.buttonCallMCU.Location = new System.Drawing.Point(276, 12);
            this.buttonCallMCU.Name = "buttonCallMCU";
            this.buttonCallMCU.Size = new System.Drawing.Size(164, 22);
            this.buttonCallMCU.TabIndex = 14;
            this.buttonCallMCU.Text = "Check MCU Connection";
            this.buttonCallMCU.UseVisualStyleBackColor = true;
            this.buttonCallMCU.Click += new System.EventHandler(this.buttonCallMCU_Click);
            // 
            // checkBoxEditRaw
            // 
            this.checkBoxEditRaw.AutoSize = true;
            this.checkBoxEditRaw.Location = new System.Drawing.Point(158, 61);
            this.checkBoxEditRaw.Name = "checkBoxEditRaw";
            this.checkBoxEditRaw.Size = new System.Drawing.Size(132, 17);
            this.checkBoxEditRaw.TabIndex = 15;
            this.checkBoxEditRaw.Text = "Raw Serial Commands";
            this.checkBoxEditRaw.UseVisualStyleBackColor = true;
            this.checkBoxEditRaw.CheckedChanged += new System.EventHandler(this.checkBoxEditRaw_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 633);
            this.Controls.Add(this.checkBoxEditRaw);
            this.Controls.Add(this.buttonCallMCU);
            this.Controls.Add(this.groupBoxCommandHelpers);
            this.Controls.Add(this.richTextBoxOutputLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveFile);
            this.Controls.Add(this.textBoxEditCommands);
            this.Controls.Add(this.buttonSendFile);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonSettings);
            this.Name = "Form1";
            this.Text = "DsplCmdSequencer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxCommandHelpers.ResumeLayout(false);
            this.groupBoxCommandHelpers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSettings;
        private OpenFileDialog openFileDialog1;
        private Button buttonOpenFile;
        private Button buttonSendFile;
        private TextBox textBoxEditCommands;
        private Button buttonSaveFile;
        private SaveFileDialog saveFileDialog1;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBoxOutputLog;
        private GroupBox groupBoxCommandHelpers;
        private Button buttonInsertFont;
        private Label label4;
        private Button buttonInsertCommand;
        private Label label3;
        private ComboBox comboBoxFonts;
        private ComboBox comboBoxFunction;
        private TextBox textBoxCommand;
        private Label label5;
        private TextBox textBoxPrototype;
        private Label label6;
        private Label label7;
        private TextBox textBoxClassInstanceName;
        private Button buttonCallMCU;
        private CheckBox checkBoxEditRaw;
    }
}