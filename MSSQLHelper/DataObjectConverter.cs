using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLHelper
{
    /// <summary>
    /// 本类提供DataRow对象和普通对象之间的相互转换功能，
    /// </summary>
    public class DataObjectConverter
    {
        /// <summary>
        /// 把实体类转换成键值对的表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="columnKeyName"></param>
        /// <param name="columnKeyValue"></param>
        /// <returns></returns>
        public static DataTable FillEntityToDataTable<T>(T t, string columnKeyName, string columnKeyValue) where T:class,new()
        {
            return null;
        }
        /// <summary>
        /// 把键值对的表数据转换成实体类
        /// </summary>
        /// <typeparam name="T">要转换成的实体</typeparam>
        /// <param name="dt">表数据</param>
        /// <param name="columnKeyName">键所对应的列名</param>
        /// <param name="columnKeyValue">值所对应列名</param>
        /// <returns></returns>
        public static T FillDataTableToEntity<T>(DataTable dt, string columnKeyName, string columnKeyValue) where T : class,new()
        {
            if (dt != null)
            {
                Type type = typeof(T);
                if (dt.Columns.Contains(columnKeyName))
                {
                    DataColumn column = dt.Columns[columnKeyName];
                    dt.PrimaryKey = new DataColumn[] { column };
                }
                T t = type.GetConstructor(Type.EmptyTypes).Invoke(null) as T;
                IEnumerable<PropertyInfo> properInfos = type.GetRuntimeProperties();
                properInfos.ToList().ForEach(p =>
                {
                    DataRow dr = dt.Rows.Find(p.Name);
                    if (dr != null)
                    {
                        switch (p.PropertyType.Name)
                        {
                            case "Int64":
                                p.SetValue(t, long.Parse(dr[columnKeyValue].ToString()));
                                break;
                            case "Int32":
                                p.SetValue(t, int.Parse(dr[columnKeyValue].ToString()));
                                break;
                            case "DateTime":
                                p.SetValue(t, DateTime.Parse(dr[columnKeyValue].ToString()));
                                break;
                            case "Boolean":
                                p.SetValue(t, dr[columnKeyValue].ToString() == "1");
                                break;
                            default:
                                p.SetValue(t, dr[columnKeyValue]);
                                break;
                        }
                    }
                });
                return t;
            }
            return default(T);
        }
        /// <summary>
        /// 把DataRow对象转换为普通持久化（业务）对象
        /// </summary>
        /// <param name="dataRow">DataRow对象</param>
        /// <param name="typeOfObject">目标持久化对象的类型</param>
        /// <returns>普通持久化（业务）对象</returns>
        public static object FillDataRowToObject(DataRow dataRow, Type typeOfObject)
        {
            if (dataRow == null)
            {
                return null;
            }
            object destObject = typeOfObject.GetConstructor(Type.EmptyTypes).Invoke(null);
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                FillDataRowValueToOjbect(dataRow, column, destObject);
            }
            return destObject;
        }

        /// <summary>
        /// 把普通持久化（业务）对象转换为DataRow对象
        /// </summary>
        /// <param name="srcObject">普通持久化（业务）对象</param>
        /// <param name="dataRow">DataRow对象</param>
        public static void FillObjectToDataRow(object srcObject, DataRow dataRow)
        {
            if (srcObject != null && dataRow != null)
            {
                foreach (DataColumn column in dataRow.Table.Columns)
                {
                    FillObjectValueToDataRow(srcObject, column, dataRow);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="column"></param>
        /// <param name="rstObject"></param>
        private static void FillDataRowValueToOjbect(DataRow dataRow, DataColumn column, object rstObject)
        {
            PropertyInfo propertyInfo = rstObject.GetType().GetProperty(column.ColumnName);
            if (propertyInfo == null)
            {
                return;
            }
            if (dataRow.IsNull(column.ColumnName))
            {
                if (propertyInfo.PropertyType.Equals(typeof(DateTime)))
                {
                    //					propertyInfo.SetValue(rstObject, MinDateTimeValueInDB, null);
                    //					propertyInfo.GetSetMethod().Invoke(rstObject, new object[]{MinDateTimeValueInDB});
                }
                return;
            }
            propertyInfo.SetValue(rstObject, dataRow[column.ColumnName], null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcObject"></param>
        /// <param name="column"></param>
        /// <param name="dataRow"></param>
        private static void FillObjectValueToDataRow(object srcObject, DataColumn column, DataRow dataRow)
        {
            PropertyInfo propertyInfo = srcObject.GetType().GetProperty(column.ColumnName);
            if (propertyInfo == null)
            {
                return;
            }

            if (propertyInfo.PropertyType.Equals(typeof(DateTime)))
            {
                if (((DateTime)propertyInfo.GetValue(srcObject, null)).Equals(DateTime.MinValue))
                {
                    dataRow[column.ColumnName] = DBNull.Value;
                    return;
                }
            }

            if (propertyInfo.PropertyType.Equals(typeof(string)))
            {
                string val = (string)propertyInfo.GetValue(srcObject, null);
                if (val == null || val.Length == 0)
                {
                    dataRow[column.ColumnName] = DBNull.Value;
                    return;
                }
            }

            if (!column.ReadOnly)
            {
                dataRow[column.ColumnName] = propertyInfo.GetValue(srcObject, null);
            }
        }
    }
}
