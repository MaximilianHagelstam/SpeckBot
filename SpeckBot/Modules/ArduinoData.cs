using System;
using System.IO.Ports;

namespace SpeckBot.Modules
{
    class ArduinoData
    {
        public int GetSmoke()
        {
            SerialPort mySerialPort = new SerialPort("COM6", 9600);

            mySerialPort.Open();

            int smoke = Int32.Parse(mySerialPort.ReadLine());

            mySerialPort.Close();

            return smoke;
        }
    }
}
