namespace ReportExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sessionLabel = new System.Windows.Forms.Label();
            this.sessionCmb = new System.Windows.Forms.ComboBox();
            this.browserBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filepathTbx = new System.Windows.Forms.TextBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.sumBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Location = new System.Drawing.Point(34, 39);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(53, 12);
            this.sessionLabel.TabIndex = 0;
            this.sessionLabel.Text = "系统周期";
            // 
            // sessionCmb
            // 
            this.sessionCmb.FormattingEnabled = true;
            this.sessionCmb.Location = new System.Drawing.Point(106, 36);
            this.sessionCmb.Name = "sessionCmb";
            this.sessionCmb.Size = new System.Drawing.Size(121, 20);
            this.sessionCmb.TabIndex = 1;
            // 
            // browserBtn
            // 
            this.browserBtn.Location = new System.Drawing.Point(372, 103);
            this.browserBtn.Name = "browserBtn";
            this.browserBtn.Size = new System.Drawing.Size(75, 23);
            this.browserBtn.TabIndex = 2;
            this.browserBtn.Text = "浏览";
            this.browserBtn.UseVisualStyleBackColor = true;
            this.browserBtn.Click += new System.EventHandler(this.browserBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "导出路径";
            // 
            // filepathTbx
            // 
            this.filepathTbx.Location = new System.Drawing.Point(106, 105);
            this.filepathTbx.Name = "filepathTbx";
            this.filepathTbx.Size = new System.Drawing.Size(237, 21);
            this.filepathTbx.TabIndex = 4;
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(195, 247);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(87, 28);
            this.exportBtn.TabIndex = 5;
            this.exportBtn.Text = "导出";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // sumBtn
            // 
            this.sumBtn.Location = new System.Drawing.Point(372, 33);
            this.sumBtn.Name = "sumBtn";
            this.sumBtn.Size = new System.Drawing.Size(75, 23);
            this.sumBtn.TabIndex = 6;
            this.sumBtn.Text = "数据汇总";
            this.sumBtn.UseVisualStyleBackColor = true;
            this.sumBtn.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.sumBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.filepathTbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browserBtn);
            this.Controls.Add(this.sessionCmb);
            this.Controls.Add(this.sessionLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportExporter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.ComboBox sessionCmb;
        private System.Windows.Forms.Button browserBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filepathTbx;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button sumBtn;
    }
}

