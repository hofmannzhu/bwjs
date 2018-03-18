using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Aspose.Cells;
 
//using Spire.Xls;
//using NPOI.SS.UserModel;


namespace UtilityHelper
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    /// Microsoft Excel 11.0 Object Library
    public class ExcelHelper
    {


        #region 将Excel文件导出到table等中
        public static void DataTableToExcel(DataSet dt, string Title)
        {
            HttpResponse resp = System.Web.HttpContext.Current.Response;
            resp.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><!--[if gte mso 9]><xml><x:ExcelWorkbook>");
            resp.Write("<x:ExcelWorksheets><x:ExcelWorksheet><x:Name>123</x:Name><x:WorksheetOptions><x:Print><x:ValidPrinterInfo /></x:Print></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table><tr> ");
            string ExcelName = HttpUtility.UrlEncode(Title, System.Text.Encoding.UTF8) + DateTime.Now.ToString("yyyyMMddHHmmss");
            resp.Charset = "UTF-8";  //必须写，否则会有乱码

            resp.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + ExcelName + ".xls");
            string colHeaders = "", ls_item = "";
            int counthead = 0;
            if (dt != null && dt.Tables.Count > 0)
            {
                for (int d = 0; d < dt.Tables.Count; d++)
                {

                    DataRow[] myRow = dt.Tables[d].Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
                    int i = 0;
                    int cl = dt.Tables[d].Columns.Count;
                    //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符
                    //resp.Write("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /></head><body><table border=1><tr ");
                    //添加网格
                    if (counthead == 0)
                    {
                        for (i = 0; i < cl; i++)
                        {

                            colHeaders += "<th>" + dt.Tables[d].Columns[i].Caption.ToString() + "</th>";
                        }
                        resp.Write(colHeaders + "</tr>");
                        counthead++;
                    }


                    //向HTTP输出流中写入取得的数据信息
                    //逐行处理数据

                    foreach (DataRow row in myRow)
                    {
                        //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据
                        ls_item = "<tr>";
                        for (i = 0; i < cl; i++)
                        {
                            string type = row[i].GetType().FullName;
                            if (type == "System.String")
                            {
                                ls_item += "<td style=\"vnd.ms-excel.numberformat:@\">" + row[i].ToString() + "</td>"; ;
                            }
                            else if (type == "System.Decimal")
                            {
                                ls_item += "<td style=\"vnd.ms-excel.numberformat:#,##0.00\">" + row[i].ToString() + "</td>"; ;
                            }
                            else
                            {
                                ls_item += "<td style=\"vnd.ms-excel.numberformat:@\">" + row[i].ToString() + "</td>"; ;
                            }


                            if (i == (cl - 1))//最后一列，加n
                            {
                                ls_item += "</tr>";
                            }
                        }
                        resp.Write(ls_item);
                    }

                }
            }
            resp.Write("</table></body>");

            resp.Write("</html>");
            resp.End();
        }



        /// <summary>
        /// 获取Excel文件数据表列表
        /// </summary>
        public static ArrayList GetExcelTables(string ExcelFileName)
        {
            DataTable dt = new DataTable();
            ArrayList TablesList = new ArrayList();
            if (File.Exists(ExcelFileName))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0 Xml;Data Source=" + ExcelFileName))
                {
                    try
                    {
                        conn.Open();
                        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }

                    //获取数据表个数
                    int tablecount = dt.Rows.Count;
                    for (int i = 0; i < tablecount; i++)
                    {
                        string tablename = dt.Rows[i][2].ToString().Trim();
                        if (tablename.IndexOf('$') == -1)
                        {
                            continue;
                        }
                        tablename = tablename.Substring(0, tablename.IndexOf('$')).TrimEnd('$');
                        if (TablesList.IndexOf(tablename) < 0)
                        {
                            TablesList.Add(tablename);
                        }
                    }
                }
            }
            return TablesList;
        }

        /// <summary>
        /// 将Excel文件导出至DataTable(第一行作为表头)
        /// </summary>
        /// <param name="ExcelFilePath">Excel文件路径</param>
        /// <param name="TableName">数据表名，如果数据表名错误，默认为第一个数据表名</param>
        public static DataTable InputFromExcel(string ExcelFilePath, string TableName)
        {
            if (!File.Exists(ExcelFilePath))
            {
                throw new Exception("Excel文件不存在！");
            }

            //如果数据表名不存在，则数据表名为Excel文件的第一个数据表
            ArrayList TableList = new ArrayList();
            TableList = GetExcelTables(ExcelFilePath);

            if (TableList.IndexOf(TableName) < 0)
            {
                TableName = TableList[0].ToString().Trim();
            }

            DataTable table = new DataTable();
            OleDbConnection dbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 12.0 Xml;");
            OleDbCommand cmd = new OleDbCommand("select * from [" + TableName + "$]", dbcon);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            try
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (dbcon.State == ConnectionState.Open)
                {
                    dbcon.Close();
                }
            }
            return table;
        }

        /// <summary>
        /// 重载导入方法 lyl
        /// </summary>
        /// <param name="ExcelFilePath">文件路径</param>
        /// <param name="withHeader">源文件是否包含表头</param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static DataSet Excel2DataSet(string ExcelFilePath, bool withHeader, params string[] sheetNames)
        {
            if (!File.Exists(ExcelFilePath))
            {
                throw new Exception("Excel文件不存在！");
            }

            //如果数据表名不存在，则数据表名为Excel文件的第一个数据表
            ArrayList TableList = new ArrayList();
            TableList = GetExcelTables(ExcelFilePath);
            var tempSheets = new List<string>();
            DataSet ds = new DataSet();
            if (sheetNames.Length > 0)
            {
                foreach (var sheetName in sheetNames)
                {
                    if (TableList.IndexOf(sheetName) > 0)
                    {
                        tempSheets.Add(sheetName);
                    }
                }
            }
            else
            {
                foreach (var item in TableList)
                {
                    tempSheets.Add(Convert.ToString(item));
                }
            }




            DataTable table = new DataTable();
            //在此例中两个连接都可用
            OleDbConnection dbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties='Excel 12.0 Xml;HDR=" + (withHeader ? "Yes" : "No") + ";IME=1'");
            //OleDbConnection dbcon = new OleDbConnection(@"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties='Excel 12.0;HDR=" + (withHeader ? "Yes" : "No") + ";IME=1'");
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = dbcon;
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);


            try
            {
                foreach (var item in tempSheets)
                {
                    adapter.SelectCommand.CommandText = string.Format("select * from [{0}$]", item);
                    if (dbcon.State == ConnectionState.Closed)
                    {
                        dbcon.Open();
                    }
                    adapter.Fill(ds, Convert.ToString(item));
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (dbcon.State == ConnectionState.Open)
                {
                    dbcon.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// 获取Excel文件指定数据表的数据列表
        /// </summary>
        /// <param name="ExcelFileName">Excel文件名</param>
        /// <param name="TableName">数据表名</param>
        public static ArrayList GetExcelTableColumns(string ExcelFileName, string TableName)
        {
            DataTable dt = new DataTable();
            ArrayList ColsList = new ArrayList();
            if (File.Exists(ExcelFileName))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0;Data Source=" + ExcelFileName))
                {
                    conn.Open();
                    dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, TableName, null });

                    //获取列个数
                    int colcount = dt.Rows.Count;
                    for (int i = 0; i < colcount; i++)
                    {
                        string colname = dt.Rows[i]["Column_Name"].ToString().Trim();
                        ColsList.Add(colname);
                    }
                }
            }
            return ColsList;
        }
        public static DataTable GetExcelData(string FilePath)
        {
            DataTable ExcelData = new DataTable();
            //Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
            //workbook.LoadFromFile(FilePath);
            //Spire.Xls.Worksheet sheet = workbook.Worksheets[0];
            //ExcelData = sheet.ExportDataTable();
            Bytescout.Spreadsheet.Spreadsheet sheet = new Bytescout.Spreadsheet.Spreadsheet();
            sheet.LoadFromFile(FilePath);
            var ds = sheet.ExportToDataSet();
            ////var workbook = GemBox.Spreadsheet.ExcelFile.Load(FilePath);
            //ExcelData = workbook.Worksheets[0].CreateDataTable(new GemBox.Spreadsheet.CreateDataTableOptions());
            return ds.Tables[0];



        }
        //public static DataTable GetExcelNewData(string FilePath)
        //{
        //    Workbook workbook = new Workbook();
        //    workbook.Open(FilePath);
           
        //    Cells cells;
        //    cells = workbook.Worksheets[0].Cells;
        //    int Columns = cells.MaxDataColumn;
        //    int Rows = cells.MaxDataRow;
        //    DataTable dtnew = new DataTable();
        //    for (int i = 0; i < Columns + 1; i++)
        //    {
        //        dtnew.Columns.Add(new DataColumn("Columns" + i.ToString(), typeof(string)));
        //    }
        //    for (int k = 1; k < Rows + 1; k++)
        //    {
        //        DataRow dr = dtnew.NewRow();
        //        for (int j = 0; j < Columns + 1; j++)
        //        {
        //            string s = cells[k, j].StringValue.Trim();
        //            dr[j] = s;
        //        }
        //        dtnew.Rows.Add(dr);
        //    }
        //    return dtnew;
        //}
        public static void  SaveDataTable(Dictionary<string, DataTable> dic, string filename)
        { 
            Workbook wb = new Workbook();
            foreach (var item in dic)
            {
                string WorksheetName = item.Key;
                DataTable dt = item.Value;
                Worksheet ws = wb.Worksheets.Add(WorksheetName);
                Aspose.Cells.Cell cell = null;
                int Rows = dt.Rows.Count;
                int Columns = dt.Columns.Count;
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        string Value = dt.Rows[i][j].ToString();
                        cell = ws.Cells[i, j]; 
                        cell.PutValue(Value);
                    }
                }
                ws.AutoFitRows(0, Rows);
                ws.AutoFitColumns(0, Columns);
                
            }
            wb.Save(filename); 
        }
 





        #endregion


        #region 数据导出至Excel文件
        /// </summary> 
        /// 导出Excel文件，自动返回可下载的文件流 
        /// </summary> 
        public static void DataTable1Excel(System.Data.DataTable dtData)
        {
            GridView gvExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;
            if (dtData != null)
            {
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                curContext.Response.Charset = "utf-8";
                strWriter = new StringWriter();
                htmlWriter = new HtmlTextWriter(strWriter);
                gvExport = new GridView();
                gvExport.DataSource = dtData.DefaultView;
                gvExport.AllowPaging = false;
                gvExport.DataBind();
                gvExport.RenderControl(htmlWriter);
                curContext.Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=gb2312\"/>" + strWriter.ToString());
                curContext.Response.End();
            }
        }

        /// <summary>
        /// 导出Excel文件，转换为可读模式
        /// </summary>
        public static void DataTable2Excel(System.Data.DataTable dtData)
        {
            DataGrid dgExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "";
                strWriter = new StringWriter();
                htmlWriter = new HtmlTextWriter(strWriter);
                dgExport = new DataGrid();
                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }

        /// <summary>
        /// 导出Excel文件，并自定义文件名
        /// </summary>
        public static void DataTable3Excel(System.Data.DataTable dtData, String FileName)
        {
            GridView dgExport = null;
            HttpContext curContext = HttpContext.Current;
            StringWriter strWriter = null;
            HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8);

                curContext.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                curContext.Response.ContentType = "application/ms-excel; charset=UTF-8";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "UTF-8";
                var sbHtml = new StringBuilder();
                strWriter = new StringWriter(sbHtml);
                //strWriter.Write(strWriter.Encoding);
                htmlWriter = new HtmlTextWriter(strWriter);
                dgExport = new GridView();

                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();
                dgExport.RenderControl(htmlWriter);
                // 解决IE导出乱码问题
                sbHtml.Append("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>");
                curContext.Response.Write(sbHtml.ToString());
                curContext.Response.End();
            }
        }

        #endregion


    }
}