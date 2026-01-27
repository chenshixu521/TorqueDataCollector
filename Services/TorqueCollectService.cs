using System;
using TorqueDataCollector.Models;
using TorqueDataCollector.Utils;

namespace TorqueDataCollector.Services
{
    public class TorqueCollectService
    {
        // 扭矩数据处理完成事件
        public event Action<TorqueRecord> OnTorqueProcessed;


        public void ReceiveTorque(double torqueValue)
        {
            //是否已经绑定电机
            if (!Systemstate.IsMotorBound)
            {
                //未绑定电机，不允许记录
                return;
            }
            // 扭矩合格判定
            bool qualified = CheckTorqueQualified(torqueValue);

            //生成扭矩记录
            TorqueRecord record = new TorqueRecord
            {
                MotorQr = Systemstate.CurrentMotorQr,
                TorqueValue = torqueValue,
                IsQualified = qualified,
                Time = DateTime.Now
            };
            //触发事件，通知数据处理完成
            OnTorqueProcessed?.Invoke(record);
        }

        private bool CheckTorqueQualified(double torque)
        {
            double min = 10.0;
            double max = 20.0;
            return torque >= min && torque <= max;
        }
    }
}
