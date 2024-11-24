using System.IO.Ports;
using System.Windows.Forms;

namespace DsplCmdSequencer
{
    public class SerialComm
    {
        SerialPort sp;

        public SerialComm ()
        {
            sp = new SerialPort();
            
        }

        public bool Open(string port_name, int baud_rate)
        {
            try
            {
                sp.PortName = port_name;
                sp.BaudRate = baud_rate;

                // format is N-8-1
                sp.BaudRate = Config.CurrentConfig.BaudRate;
                sp.DataBits = 8;
                sp.Parity = Parity.None;
                sp.StopBits = StopBits.One;
                sp.Handshake = Handshake.None;
                sp.ReadTimeout = 1000;
                sp.NewLine = "\r\n";

                sp.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Close()
        {
            sp.Close();
        }

        public void Flush()
        {
            sp.DiscardInBuffer();
        }

        public int Available()
        {
            if (sp.IsOpen)
                return sp.BytesToRead;
            else
                return 0;
        }

        public void Send(string dataToSend)
        {
            sp.Write(dataToSend);
        }

        public string ReadLine()
        {
            string rxLine;
            try
            {
                rxLine = sp.ReadLine();
            }
            catch
            {
                rxLine = sp.ReadExisting();
            }
            return rxLine;
        }
        public void WriteLine(string txLine)
        {
            sp.WriteLine(txLine);
        }
    }
}
