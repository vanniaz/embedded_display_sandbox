using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace DsplCmdSequencer
{
    public class Config
    {
        public string SerialPortName = "";
        public int BaudRate = 115200;
        public bool EditRaw = false;
        public static Config CurrentConfig;

        public Config()
        {
            CurrentConfig = this;
        }
        
        public bool SaveToFile(string filename)
        {
            string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); ;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(Config));

                using (TextWriter writer = new StreamWriter(filePath + "\\" + filename))
                {
                    serializer.Serialize(writer, CurrentConfig);
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                MessageBox.Show("Error saving config file:" + ex.ToString());
            }
            return true;
        }

        public void LoadFromFile(string filename)
        {
            string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            XmlSerializer deserializer = new XmlSerializer(typeof(Config));
            try
            {
                TextReader reader = new StreamReader(filePath + "\\" + filename);
                object obj = deserializer.Deserialize(reader);
                reader.Close();
                CurrentConfig = (Config)obj;
            }
            catch
            {
                CurrentConfig = this;
            }
        }

    }
}
