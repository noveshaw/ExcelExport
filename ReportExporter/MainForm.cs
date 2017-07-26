using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace ReportExporter
{
    public partial class MainForm : Form
    {
        private AppConf appconf = new AppConf();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!appconf.CheckConnection())
            {
                DataBaseSetting dbsetForm = new DataBaseSetting();
                dbsetForm.ShowDialog();
            }

            DataSet ds = appconf.GetDataSet("s_session", new string[] { "id", "memo" });
            if (ds == null)
            {
                MessageBox.Show("系统周期表数据读取失败");
                return;
            }
            DataTable dt = ds.Tables[0];
            this.sessionCmb.DataSource = dt;
            this.sessionCmb.DisplayMember = "memo";
            this.sessionCmb.ValueMember = "id";
            ;
        }

        private void browserBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfile = new SaveFileDialog();
            sfile.Filter = "Excel 97-2003文件|*.xls";
            sfile.FileName = this.sessionCmb.Text + "考勤工时统计";
            if (sfile.ShowDialog() == DialogResult.OK)
            {
                this.filepathTbx.Text = sfile.FileName;
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            DataExport dataExport = new DataExport();
            string procName = appconf.GetProcName();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("@sessionid", this.sessionCmb.SelectedValue.ToString());

            //DataSet ds = appconf.GetDataSet("s_session", new string[] { "id as 序号", "memo", "date0", "date1", "alldays" });
            try
            {
                DataSet ds = appconf.GetDataSet(procName, nvc);
                dataExport.WriteData(ds.Tables[0]);
                dataExport.SaveFile(this.filepathTbx.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, string.Format("数据导出失败！ \r\n {0}", exp.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataExport.release();
            MessageBox.Show(this, "导出成功!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}