using System.IO.Ports;

namespace SpeckBot.Modules
{
    class ArduinoData
    {
        public string GetTemperature()
        {
            SerialPort mySerialPort = new SerialPort("COM4", 9600);

            mySerialPort.Open();

            string temperature = mySerialPort.ReadLine();

            mySerialPort.Close();

            return temperature;
        }
    }
}
