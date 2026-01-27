using System;
using System.Text;
using System.IO.Ports;


namespace TorqueDataCollector.Services
{
    internal class ScanSerialService
    {
        private SerialPort _serialPort;

        //扫码完成事件
        public event Action<string> OnScanReceived;

        public bool IsOpen
        {
            get
            {
                return _serialPort != null && _serialPort.IsOpen;
            }
        }
        //打开串口：创建并配置串口
        public void Open(string portName, int baudRate = 9600)
        {
            if (_serialPort != null && _serialPort.IsOpen)
                return;

            _serialPort = new SerialPort(portName, baudRate);
            _serialPort.Encoding = Encoding.ASCII;
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.Open();
        }
        //关闭串口：关闭串口并释放资源
        public void Close()
        {
            if (_serialPort == null)
                return;

            if (_serialPort.IsOpen)
            {
                _serialPort.DataReceived -= SerialPort_DataReceived;
                _serialPort.Close();
            }
        }
        //串口数据接收事件：处理接收到的数据
        
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _serialPort.ReadExisting();
                data = data.Trim();

                if (!string.IsNullOrEmpty(data))
                {
                    OnScanReceived?.Invoke(data);
                }
            }
            catch
            {

            }
        }
    }
}
