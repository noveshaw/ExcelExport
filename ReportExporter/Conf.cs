using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace ReportExporter
{
    internal sealed class AppConf
    {
        private static string _CUSTOM_KEY = "Tongxine";
        private static string _CUSTOM_IV = "Tongxine";

        private SqlDataAdapter adapter;
        public static SqlConnection sqlconn = new SqlConnection();

        private Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private DESCryptoServiceProvider desCSP;

        public AppConf()
        {
            desCSP = new DESCryptoServiceProvider();
            desCSP.Key = ASCIIEncoding.ASCII.GetBytes(_CUSTOM_KEY);
            desCSP.IV = ASCIIEncoding.ASCII.GetBytes(_CUSTOM_IV);
        }

        #region 数据库连接测试、字串加密

        //获取app.config属性值 DataBase连接字串
        public string GetConnStr(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            string decStr = string.Empty;
            try
            {
                decStr = DecrpytString(connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                decStr = string.Empty;
            }
            return decStr;
        }

        //设置app.config属性值 DataBase连接字串
        public bool SetConnStr(string name, string newStr, string providerName)
        {
            bool isExists = false;
            if (ConfigurationManager.ConnectionStrings[name].ConnectionString != null)
            {
                isExists = true;
            }
            try
            {
                ConnectionStringSettings css = new ConnectionStringSettings(name, EncrptyString(newStr), providerName);
                if (isExists)
                {
                    conf.ConnectionStrings.ConnectionStrings.Remove(name);
                }
                conf.ConnectionStrings.ConnectionStrings.Add(css);
                conf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                return true;
            }
            catch (ConfigurationException e)
            {
                MessageBox.Show(string.Format("Configuration set failed!\n {0}", e.Message));
                return false;
            }
        }

        //获取app.config自定义配置Style列宽设置值
        public static List<int> GetColumnWidth()
        {
            StyleSection ss = ConfigurationManager.GetSection("userSettings/Style") as StyleSection;
            Widths widthCollection = ss.Widths;

            List<int> colsWidth = new List<int>();
            foreach (WidthSection ws in widthCollection)
            {
                colsWidth.Add(ws.width);
            }
            return colsWidth;
        }

        //获取app.config自定义配置Procedure
        public string GetProcName()
        {
            string procName = string.Empty;
            procName = ReportExporter.Properties.Settings.Default.queryProc;
            return procName;
        }

        public string EncrptyString(string str)
        {
            byte[] inBlock = Encoding.UTF8.GetBytes(str);
            ICryptoTransform xfrm = desCSP.CreateEncryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);
            return Convert.ToBase64String(outBlock);
        }

        public string DecrpytString(string decStr)
        {
            byte[] inBlock = Convert.FromBase64String(decStr);
            //byte[] inBlock = UnicodeEncoding.Unicode.GetBytes(decStr);
            ICryptoTransform xfrm = desCSP.CreateDecryptor();
            byte[] outBlock;
            try
            {
                outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);
            }
            catch
            {
                return string.Empty;
            }
            return Encoding.UTF8.GetString(outBlock);
        }

        public bool CheckConnection()
        {
            string connStr = GetConnStr("ReportExporterConn");
            sqlconn.ConnectionString = connStr;
            try
            {
                sqlconn.Open();
            }
            catch (Exception e)
            {
                sqlconn.ConnectionString = null;
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        #endregion 数据库连接测试、字串加密

        #region 数据查询

        public DataSet GetDataSet(string table, string[] columns, string where = "1=1")
        {
            string sql = SqlCompact(table, columns, where);
            DataSet ds = new DataSet();
            if (adapter == null)
            {
                adapter = new SqlDataAdapter(sql, sqlconn);
            }
            try
            {
                adapter.Fill(ds);
                //adapter.FillSchema(ds, SchemaType.Mapped);
            }
            catch (Exception e)
            {
                ds = null;
                MessageBox.Show("执行数据查询错误，数据读取失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                adapter = null;
            }
            return ds;
        }

        /// <summary>
        /// class GetDataSet
        /// </summary>
        /// <param name="procedure">存储过程名</param>
        /// <param name="paramList">存储过程参数</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string procedure, NameValueCollection paramList)
        {
            DataSet ds = new DataSet();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = AppConf.sqlconn;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = procedure;

            foreach (string key in paramList.Keys)
            {
                sqlcmd.Parameters.AddWithValue(key, paramList[key]);
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlcmd;
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception exp)
            {
                ds = null;
                MessageBox.Show("执行数据查询错误，数据读取失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                adapter = null;
            }
            return ds;
        }

        public string SqlCompact(string table, string[] columns, string where = "1=1")
        {
            string sql = "select ";
            string column = string.Empty;
            if (columns.Length == 0)
            {
                column = " * ";
            }
            if (columns.Length == 1)
            {
                column = " " + columns[0] + " ";
            }
            if (columns.Length > 1)
            {
                column = string.Join(" , ", columns);
            }

            sql += column;
            sql += " from " + table + " where " + where;
            return sql;
        }

        public bool GatherData()
        {
            SqlCommand sqlcmd = new SqlCommand();
            return false;
        }

        #endregion 数据查询
    }
}