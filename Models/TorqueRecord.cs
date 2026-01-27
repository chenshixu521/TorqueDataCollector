using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorqueDataCollector.Models
{
    public class TorqueRecord
    {
        //电机二维码
        public string MotorQr { get; set; }
        //扭矩值(Nm)
        public double TorqueValue { get; set; }
        //采集时间
        public DateTime Time { get; set; }
        //是否合格
        public bool IsQualified { get; set; }
        //角度值
        public double Angle { get; set; }

    }
}
