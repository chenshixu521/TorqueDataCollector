using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorqueDataCollector.Utils
{
    public static class Systemstate
    {
        //当前电机二维码
        public static string CurrentMotorQr { get; private set; }

        //是否已经绑定电机二维码
        public static bool IsMotorBound
        {
            get
            {
                return !string.IsNullOrEmpty(CurrentMotorQr);
            }
        }
        public static void BindMotor(string qr)
        {
            CurrentMotorQr = qr;
        }

        public static void ClearMotor()
        {
            CurrentMotorQr = null;
        }
    }
}
