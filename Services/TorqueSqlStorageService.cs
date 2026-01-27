using System.Data.SqlClient;
using TorqueDataCollector.Models;

namespace TorqueDataCollector.Services
{
    /// 扭矩数据 SQL Server 实时存储服务
    public class TorqueSqlStorageService
    {
        private readonly string _connectionString;

        public TorqueSqlStorageService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(TorqueRecord record)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
INSERT INTO TorqueRecord
(MotorQr, TorqueValue, IsQualified, Time)
VALUES
(@MotorQr, @TorqueValue, @IsQualified, @Time)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MotorQr", record.MotorQr);
                    cmd.Parameters.AddWithValue("@TorqueValue", record.TorqueValue);
                    cmd.Parameters.AddWithValue("@IsQualified", record.IsQualified);
                    cmd.Parameters.AddWithValue("@Time", record.Time);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
