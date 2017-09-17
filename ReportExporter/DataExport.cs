using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System.IO;

namespace ReportExporter
{
    internal class DataExport
    {
        private HSSFWorkbook workbook;
        private HSSFSheet sheet1;
        private HSSFCellStyle cellStyle;

        public static int MergeRowsCount = AppConf.GetMergeRowCount();//合并行数
        public static int MergeColumnsCountBefore = AppConf.GetMergeCountBefore(); //需要合并的单元格前面列数
        public static int MergeColumnsCountAfter = AppConf.GetMergeCountAfter();//需要合并的后面列数

        public DataExport()
        {
            workbook = new HSSFWorkbook();
            sheet1 = workbook.CreateSheet("Sheet1") as HSSFSheet;
            cellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
        }

        public void release()
        {
            workbook = null;
        }

        public void SaveFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                workbook.Write(fs);
            }
        }

        public void WriteData(DataTable dt)
        {
            List<string> fields = new List<string> { };
            int colCount = dt.Columns.Count;
            int rowCount = dt.Rows.Count;

            foreach (DataColumn dc in dt.Columns)
            {
                fields.Add(dc.ColumnName);
            }

            //写入首行字段名
            HSSFRow row = sheet1.CreateRow(0) as HSSFRow;
            for (int i = 0; i < colCount; i++)
            {
                HSSFCell cell = row.CreateCell(i) as HSSFCell;
                cell.CellStyle = cellStyle;
                cell.SetCellValue(fields[i]);
            }

            //写入数据、居中对齐
            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
            {
                HSSFRow dataRow = sheet1.CreateRow(rowIndex) as HSSFRow;
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                {
                    HSSFCell cell = dataRow.CreateCell(colIndex) as HSSFCell;
                    cell.CellStyle = cellStyle;
                    cell.SetCellValue(dt.Rows[rowIndex - 1][colIndex].ToString());
                }
            }

            //前n列单元格合并
            for (int step = 0; step < MergeColumnsCountBefore; step++)
            {
                for (int offset = 1; offset < rowCount; offset += MergeRowsCount)
                {
                    sheet1.AddMergedRegion(new CellRangeAddress(offset, offset + MergeRowsCount - 1, step, step));
                }
            }

            //后n列单元格合并
            for (int step = colCount - 1; step > colCount - MergeColumnsCountAfter - 1; step--)
            {
                for (int offset = 1; offset < rowCount; offset += MergeRowsCount)
                {
                    sheet1.AddMergedRegion(new CellRangeAddress(offset, offset + MergeRowsCount - 1, step, step));
                }
            }

            //设置Columm的宽度
            List<int> colsWidth = AppConf.GetColumnWidth();

            for (int index = 0; index < colCount; index++)
            {
                try
                {
                    sheet1.SetColumnWidth(index, colsWidth[index] * 256); //Excel宽度单位为1/256个字符长度
                }
                catch (ArgumentOutOfRangeException exp)
                {
                    sheet1.SetColumnWidth(index, 10 * 256);
                }
                //sheet1.SetColumnWidth(index, colsWidth[index] * 256); //Excel宽度单位为1/256个字符长度
            }
        }
    }
}