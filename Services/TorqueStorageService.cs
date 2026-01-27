using System;
using System.IO;
using TorqueDataCollector.Models;

namespace TorqueDataCollector.Services
{
    /// 扭矩数据存储服务（CSV）
    public class TorqueStorageService
    {
        private readonly string _filePath;

        public TorqueStorageService()
        {
            string dir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            _filePath = Path.Combine(dir, "torque_data.csv");

            // 如果文件不存在，写表头
            if (!File.Exists(_filePath))
            {
                File.AppendAllText(_filePath,
                    "时间,电机二维码,扭矩值(Nm),是否合格\r\n");
            }
        }

        public void Save(TorqueRecord record)
        {
            string line =
                $"{record.Time:yyyy-MM-dd HH:mm:ss}," +
                $"{record.MotorQr}," +
                $"{record.TorqueValue}," +
                $"{(record.IsQualified ? "合格" : "不合格")}";

            File.AppendAllText(_filePath, line + "\r\n");
        }
    }
}
