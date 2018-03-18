using System.Collections.Generic;

namespace UtilityHelper.Data
{
    public class DataPager<T>
    {
        public DataPager()
        {
            TotalRecord = 0;
            TotalPage = 0;
            PageSize = 0;
            Items = new List<T>();
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 每页显示数
        /// </summary>
        public int PageSize { get; set; }

        public List<T> Items { get; set; }
    }
}
