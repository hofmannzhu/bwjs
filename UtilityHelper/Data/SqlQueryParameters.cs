using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper.Data
{
    [DataContract]
    [KnownType(typeof(SqlQueryParameters))]
    public class SqlQueryParameters
    {
        [DataMember]
        public List<SqlParameters> param { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        [DataMember]
        public string OrderByField { get; set; }
        /// <summary>
        /// 排序方式,DESC OR ASC
        /// </summary>
        [DataMember]
        public string OrderBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int PageNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }

    [DataContract]
    [KnownType(typeof(SqlParameters))]
    public class SqlParameters
    {
        [DataMember]
        public object ParamType { get; set; }
        [DataMember]
        public string ParamDBName { get; set; }
        [DataMember]
        public string ParamName { get; set; }
        [DataMember]
        public string ParamValue { get; set; }
        [DataMember]
        public int ParamLength { get; set; }
        [DataMember]
        public string ParamAlias { get; set; }
        [DataMember]
        public string Operator { get; set; }
        [DataMember]
        public string ParamFullNmae
        {
            get
            {
                if (string.IsNullOrEmpty(ParamAlias))
                {
                    return ParamDBName;
                }
                else
                {
                    return ParamAlias + "." + ParamDBName;
                }

            }
        }
    }
    public class SqlParametersHandler
    {
        static string paramstr = "{0} {1} {2}";
        public static List<SqlParameter> GetParameters(List<SqlParameters> param, ref string strWhere)
        {
            List<SqlParameter> parametersList = new List<SqlParameter>();
            List<string> strWhereList = new List<string>();
            if (param != null)
            {
                foreach (var item in param)
                {
                    //Debug.WriteLine(GetTimeParament(item.ParamName, item.ParamType));
                    parametersList.Add(new SqlParameter(item.ParamName, GetParamValue(item.ParamValue, item.Operator)));
                    strWhereList.Add(string.Format(paramstr, GetTimeParament(item.ParamFullNmae, item.ParamType), item.Operator, "@" + item.ParamName));
                }
                strWhere = string.Join(" and ", strWhereList.ToArray());
            }
            else
            {
                strWhere = string.Empty;
            }
            return parametersList;
        }

        private static string GetTimeParament(string name, object type)
        {
            if (type.ToString() == "datetime")
            {
                return String.Format("convert(varchar(20), {0},23)", name);
            }
            else
            {
                return name;
            }
        }
        private static string GetParamValue(string value, string op)
        {
            if (op.ToLower() == "like")
            {
                return "%" + value + "%";
            }
            else
            {
                return value;
            }
        }
        public static void AddParam(string ParamName, string ParamType, string ParamAlias, string ParamValue, int ParamLength, string Operator, string ParamDBName, ref List<SqlParameters> param)
        {
            if (!String.IsNullOrEmpty(ParamValue))
                param.Add(new SqlParameters()
                {
                    ParamName = ParamName,
                    ParamType = ParamType,
                    ParamAlias = ParamAlias,
                    ParamValue = ParamValue,
                    ParamLength = ParamLength,
                    Operator = Operator,
                    ParamDBName = ParamDBName,
                });
        }
    }
}
