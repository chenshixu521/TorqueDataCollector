namespace TorqueDataCollector
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMotorQr = new System.Windows.Forms.TextBox();
            this.btnBindMotor = new System.Windows.Forms.Button();
            this.lblMotorStatus = new System.Windows.Forms.Label();
            this.btnMockScan = new System.Windows.Forms.Button();
            this.lstTorque = new System.Windows.Forms.ListBox();
            this.btnMockTorque = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "电机二维码 \r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMotorQr
            // 
            this.txtMotorQr.Location = new System.Drawing.Point(24, 100);
            this.txtMotorQr.Name = "txtMotorQr";
            this.txtMotorQr.Size = new System.Drawing.Size(278, 28);
            this.txtMotorQr.TabIndex = 1;
            // 
            // btnBindMotor
            // 
            this.btnBindMotor.Location = new System.Drawing.Point(24, 150);
            this.btnBindMotor.Name = "btnBindMotor";
            this.btnBindMotor.Size = new System.Drawing.Size(127, 32);
            this.btnBindMotor.TabIndex = 2;
            this.btnBindMotor.Text = "绑定电机";
            this.btnBindMotor.UseVisualStyleBackColor = true;
            this.btnBindMotor.Click += new System.EventHandler(this.btnBindMotor_Click);
            // 
            // lblMotorStatus
            // 
            this.lblMotorStatus.AutoSize = true;
            this.lblMotorStatus.Location = new System.Drawing.Point(21, 58);
            this.lblMotorStatus.Name = "lblMotorStatus";
            this.lblMotorStatus.Size = new System.Drawing.Size(152, 18);
            this.lblMotorStatus.TabIndex = 3;
            this.lblMotorStatus.Text = "当前状态：未绑定";
            // 
            // btnMockScan
            // 
            this.btnMockScan.Location = new System.Drawing.Point(661, 34);
            this.btnMockScan.Name = "btnMockScan";
            this.btnMockScan.Size = new System.Drawing.Size(113, 42);
            this.btnMockScan.TabIndex = 4;
            this.btnMockScan.Text = "模拟扫码";
            this.btnMockScan.UseVisualStyleBackColor = true;
            this.btnMockScan.Click += new System.EventHandler(this.btnMockScan_Click);
            // 
            // lstTorque
            // 
            this.lstTorque.FormattingEnabled = true;
            this.lstTorque.ItemHeight = 18;
            this.lstTorque.Location = new System.Drawing.Point(24, 226);
            this.lstTorque.Name = "lstTorque";
            this.lstTorque.Size = new System.Drawing.Size(764, 184);
            this.lstTorque.TabIndex = 5;
     
            // btnMockTorque
            // 
            this.btnMockTorque.Location = new System.Drawing.Point(513, 34);
            this.btnMockTorque.Name = "btnMockTorque";
            this.btnMockTorque.Size = new System.Drawing.Size(113, 42);
            this.btnMockTorque.TabIndex = 6;
            this.btnMockTorque.Text = "模拟扭矩";
            this.btnMockTorque.UseVisualStyleBackColor = true;
            this.btnMockTorque.Click += new System.EventHandler(this.btnMockTorque_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMockTorque);
            this.Controls.Add(this.lstTorque);
            this.Controls.Add(this.btnMockScan);
            this.Controls.Add(this.lblMotorStatus);
            this.Controls.Add(this.btnBindMotor);
            this.Controls.Add(this.txtMotorQr);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMotorQr;
        private System.Windows.Forms.Button btnBindMotor;
        private System.Windows.Forms.Label lblMotorStatus;
        private System.Windows.Forms.Button btnMockScan;
        private System.Windows.Forms.ListBox lstTorque;
        private System.Windows.Forms.Button btnMockTorque;
    }
}

