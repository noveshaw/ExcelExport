namespace ReportExporter
{
    partial class DataBaseSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseSetting));
            this.label1 = new System.Windows.Forms.Label();
            this.serverTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbTbx = new System.Windows.Forms.TextBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.setBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // serverTbx
            // 
            this.serverTbx.Location = new System.Drawing.Point(175, 12);
            this.serverTbx.Name = "serverTbx";
            this.serverTbx.Size = new System.Drawing.Size(100, 21);
            this.serverTbx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名：";
            // 
            // userTbx
            // 
            this.userTbx.Location = new System.Drawing.Point(175, 56);
            this.userTbx.Name = "userTbx";
            this.userTbx.Size = new System.Drawing.Size(100, 21);
            this.userTbx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密  码：";
            // 
            // pwdTbx
            // 
            this.pwdTbx.Location = new System.Drawing.Point(175, 97);
            this.pwdTbx.MaxLength = 20;
            this.pwdTbx.Name = "pwdTbx";
            this.pwdTbx.PasswordChar = '*';
            this.pwdTbx.Size = new System.Drawing.Size(100, 21);
            this.pwdTbx.TabIndex = 5;
            this.pwdTbx.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库：";
            // 
            // dbTbx
            // 
            this.dbTbx.Location = new System.Drawing.Point(175, 136);
            this.dbTbx.Name = "dbTbx";
            this.dbTbx.Size = new System.Drawing.Size(100, 21);
            this.dbTbx.TabIndex = 7;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(63, 185);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 8;
            this.testBtn.Text = "测试连接";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // setBtn
            // 
            this.setBtn.Enabled = false;
            this.setBtn.Location = new System.Drawing.Point(175, 184);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(75, 23);
            this.setBtn.TabIndex = 9;
            this.setBtn.Text = "确定";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ReportExporter.Properties.Resources.database_process_128px_534788_easyicon_net;
            this.pictureBox1.Location = new System.Drawing.Point(11, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Complete);
            // 
            // DataBaseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 229);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.dbTbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pwdTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverTbx);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBaseSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库连接设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataBaseSetting_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pwdTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbTbx;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}