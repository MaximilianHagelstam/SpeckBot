using System;
using System.IO.Ports;

namespace SpeckBot.Modules
{
    class SerialCommunication
    {
        public int GetSerialData()
        {
            SerialPort mySerialPort = new SerialPort("COM6", 9600);

            mySerialPort.Open();

            int serialData = Int32.Parse(mySerialPort.ReadLine());

            mySerialPort.Close();

            return serialData;
        }
    }
}
