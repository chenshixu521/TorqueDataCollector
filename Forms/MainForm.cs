using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorqueDataCollector.Models;
using TorqueDataCollector.Services;
using TorqueDataCollector.Utils;
using System.Configuration;

namespace TorqueDataCollector
{
    public partial class MainForm : Form
    {
        private ScanSerialService _scanService ;
        private TorqueCollectService _torqueCollectService;
        private TorqueStorageService _csvStorage;
        private TorqueSqlStorageService _sqlStorage;



        public MainForm()
        {
            InitializeComponent();
            _scanService = new ScanSerialService();
            _scanService.OnScanReceived += ScanService_OnScanReceived;
            _torqueCollectService = new TorqueCollectService();
            _torqueCollectService.OnTorqueProcessed += TorqueCollectService_OnTorqueProcessed;
            _csvStorage = new TorqueStorageService();
            string connStr =
    ConfigurationManager.ConnectionStrings["TorqueDb"].ConnectionString;

            _sqlStorage = new TorqueSqlStorageService(connStr);
        }
        private void ScanService_OnScanReceived(string qr)
        {
            // 串口线程不能直接操作UI
            this.Invoke(new Action(() =>
            {
               Systemstate.BindMotor(qr);
               lblMotorStatus.Text = "当前状态：已绑定（" + qr + "）";
               txtMotorQr.Text = qr;
            }));
        }
        private void TorqueCollectService_OnTorqueProcessed(TorqueRecord record)
        {
            this.Invoke(new Action(() =>
            {
                string result =
                    $"{record.Time:HH:mm:ss} | " +
                    $"扭矩：{record.TorqueValue} Nm | " +
                    $"角度：{record.Angle} ° | " +
                    (record.IsQualified ? "合格" : "不合格");

                lstTorque.Items.Add(result);

                // 保存到文件
                try
                {
                    _sqlStorage.Save(record);
                }
                catch (Exception ex)
                {
                    // 数据库异常，降级写 CSV
                    MessageBox.Show(ex.Message, "数据库写入失败");
                    _csvStorage.Save(record);
                    
                }

            }));
        }

        private void btnBindMotor_Click(object sender, EventArgs e)
        {
            String qr = txtMotorQr.Text.Trim();

            if (string.IsNullOrEmpty(qr))
                {
                MessageBox.Show("请输入电机二维码！");
                return;
                }

            Systemstate.BindMotor(qr);
            lblMotorStatus.Text = "当前状态：已绑定（" + qr + "）";
        }

        private void btnMockScan_Click(object sender, EventArgs e)
        {
            String mockQr = "Mock" + DateTime.Now.Ticks;
            ScanService_OnScanReceived(mockQr);
        }

        private void btnMockTorque_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            double torque = Math.Round(r.NextDouble() * 30, 2);


            _torqueCollectService.ReceiveTorque(torque);
        }

    
    }
}
