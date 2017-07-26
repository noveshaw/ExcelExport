using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReportExporter
{
    public partial class DataBaseSetting : Form
    {
        WaitForm wf;
        AppConf appconf = new AppConf();
        
        public DataBaseSetting()
        {
            InitializeComponent();
        }

        private void DataBaseSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            string server = serverTbx.Text;
            string user = userTbx.Text;
            string password = pwdTbx.Text;
            string db = dbTbx.Text;

            string connStr = string.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3}", server, user, password, db);
            if(AppConf.sqlconn!=null)
            {
                AppConf.sqlconn.Close();
            }
            AppConf.sqlconn.ConnectionString = connStr;

            wf = new WaitForm();
            backgroundWorker1.RunWorkerAsync();
            wf.ShowDialog();
        }

        private bool TestConn(SqlConnection sqlconn)
        {
            try
            {
                sqlconn.Open();
                MessageBox.Show(Application.OpenForms["DataBaseSettings"],"测试连接成功！");
                return true;
            }catch(Exception e)
            {
                MessageBox.Show(string.Format("测试连接失败！ \r\n {0}", e.Message));
                return false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           TestConn(AppConf.sqlconn);
        }

        private void backgroundWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.OpenForms["DataBaseSetting"].Controls["setBtn"].Enabled = true;
            Application.OpenForms["WaitForm"].Close();
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            string server = serverTbx.Text;
            string user = userTbx.Text;
            string password = pwdTbx.Text;
            string db = dbTbx.Text;

            string newConStr= string.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3}", server, user, password, db);

            appconf.SetConnStr("ReportExporterConn", newConStr, "System.Data.OleDb");
            this.Hide();
        }

    }
}
