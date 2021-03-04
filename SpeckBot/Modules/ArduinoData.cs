using System.IO.Ports;

namespace SpeckBot.Modules
{
    class ArduinoData
    {
        public string GetSmoke()
        {
            SerialPort mySerialPort = new SerialPort("COM5", 9600);

            mySerialPort.Open();

            string smoke = mySerialPort.ReadLine();

            mySerialPort.Close();

            return smoke;
        }
    }
}
