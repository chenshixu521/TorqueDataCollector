using System;
using System.Timers;

namespace TorqueDataCollector.Services
{
    
    // 设备状态枚举
    
    public enum DeviceStatus
    {
        Disconnected,  // 已断开
        Connecting,    // 连接中
        Connected,     // 已连接
        Error          // 错误状态（重试次数超限）
    }

   
    // 设备连接管理器：管理串口设备的连接、断线重连、心跳检测
    
    public class DeviceConnectionManager
    {
        private readonly ScanSerialService _scanService;
        private readonly string _portName;
        private readonly int _baudRate;
        private readonly Timer _reconnectTimer;  // 重连定时器（3秒间隔）
        private int _retryCount = 0;
        private const int MaxRetry = 5;
        private DateTime _lastReceiveTime = DateTime.MinValue;
        private readonly Timer _heartbeatTimer;  // 心跳检测定时器（2秒间隔）

        public DeviceStatus CurrentStatus { get; private set; } = DeviceStatus.Disconnected;
        public event Action<DeviceStatus> OnStatusChanged;

        public DeviceConnectionManager(
            ScanSerialService scanService,
            string portName,
            int baudRate)
        {
            _scanService = scanService;
            _portName = portName;
            _baudRate = baudRate;

            // 订阅数据接收事件，更新心跳时间
            _scanService.OnDataReceived += () => _lastReceiveTime = DateTime.Now;

            // 心跳检测：每2秒检查一次
            _heartbeatTimer = new Timer(2000);
            _heartbeatTimer.Elapsed += CheckHeartbeat;
            _heartbeatTimer.Start();

            // 重连定时器：每3秒尝试一次
            _reconnectTimer = new Timer(3000);
            _reconnectTimer.Elapsed += TryReconnect;
        }

        // 启动连接
        public void Start()
        {
            ChangeStatus(DeviceStatus.Connecting);
            TryOpen();
        }

        // 停止连接
        public void Stop()
        {
            _reconnectTimer.Stop();
            _scanService.Close();
            ChangeStatus(DeviceStatus.Disconnected);
        }

        // 尝试打开串口
        private void TryOpen()
        {
            try
            {
                _scanService.Open(_portName, _baudRate);
                _retryCount = 0;
                _reconnectTimer.Stop();
                ChangeStatus(DeviceStatus.Connected);
            }
            catch (Exception)
            {
                HandleConnectFail();
            }
        }

        // 重连定时器回调
        private void TryReconnect(object sender, ElapsedEventArgs e)
        {
            TryOpen();
        }

        // 处理连接失败
        private void HandleConnectFail()
        {
            _retryCount++;

            if (_retryCount >= MaxRetry)
            {
                _reconnectTimer.Stop();
                ChangeStatus(DeviceStatus.Error);
                return;
            }

            ChangeStatus(DeviceStatus.Disconnected);
            _reconnectTimer.Start();
        }

        // 改变设备状态并触发事件
        private void ChangeStatus(DeviceStatus status)
        {
            if (CurrentStatus == status)
                return;

            CurrentStatus = status;
            OnStatusChanged?.Invoke(status);
        }

        // 心跳检测：超过10秒无数据则认为掉线
        private void CheckHeartbeat(object sender, ElapsedEventArgs e)
        {
            if (CurrentStatus != DeviceStatus.Connected)
                return;

            if ((DateTime.Now - _lastReceiveTime).TotalSeconds > 10)
            {
                _scanService.Close();
                ChangeStatus(DeviceStatus.Disconnected);
                _reconnectTimer.Start();
            }
        }
    }
}
