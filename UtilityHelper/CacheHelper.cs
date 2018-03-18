using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace UtilityHelper
{
    public class CacheHelper
    {
        /// <summary>
        /// 是否存在缓存
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <returns></returns>
        public static bool HasCache(string cacheKey)
        {
            if (String.IsNullOrEmpty(cacheKey))
                return false;
            return HttpRuntime.Cache[cacheKey] != null;
        }

        /// <summary>
        /// 读取缓存数据
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            return HasCache(cacheKey) ? HttpRuntime.Cache[cacheKey] : null;
        }

        /// <summary>
        /// 读取缓存数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="cacheKey">缓存名称</param>
        /// <returns></returns>
        public static T GetCache<T>(string cacheKey)
        {
            object obj = GetCache(cacheKey);
            return obj == null ? default(T) : (T)obj;
        }

        /// <summary>
        /// 数据写入到缓存中，默认缓存过期时间是15分钟
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <param name="cacheValue">缓存数据</param> 
        public static void SetCache(string cacheKey, object cacheValue)
        {
            SetCache(cacheKey, cacheValue, DateTime.Now.AddMinutes(15));
        }
        /// <summary>
        /// 数据写入到缓存中
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <param name="cacheValue">缓存数据</param> 
        /// <param name="days">缓存天数</param>
        public static void SetCache(string cacheKey, object cacheValue,int days)
        {
            SetCache(cacheKey, cacheValue, DateTime.Now.AddDays(days));
        }
        /// <summary>
        /// 数据写入到缓存中
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <param name="cacheValue">缓存数据</param>
        /// <param name="slidingExpiration">相对过期时间间隔</param>
        public static void SetCache(string cacheKey, object cacheValue, TimeSpan slidingExpiration)
        {
            if (cacheValue != null)
            {
                HttpRuntime.Cache.Insert(cacheKey, cacheValue, null, Cache.NoAbsoluteExpiration, slidingExpiration);
            }
        }

        /// <summary>
        /// 数据写入到缓存中
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <param name="cacheValue">缓存数据</param>
        /// <param name="absoluteExpiration">过期时间(表达式)</param>
        public static void SetCache(string cacheKey, object cacheValue, DateTime absoluteExpiration)
        {
            if (cacheValue != null)
            {
                SetCache(cacheKey, cacheValue, null, absoluteExpiration);
            }
        }

        /// <summary>
        /// 数据写入到缓存中
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        /// <param name="cacheValue">缓存数据</param>
        /// <param name="dependency">缓存依附关系</param>
        /// <param name="absoluteExpiration">过期时间(表达式)</param>
        public static void SetCache(string cacheKey, object cacheValue, CacheDependency dependency, DateTime absoluteExpiration)
        {
            if (cacheValue != null)
            {
                HttpRuntime.Cache.Insert(cacheKey, cacheValue, dependency, absoluteExpiration, Cache.NoSlidingExpiration);
            }
        }

        /// <summary>
        /// 删除缓存数据
        /// </summary>
        /// <param name="cacheKey">缓存名称</param>
        public static void RemoveCache(string cacheKey)
        {
            if (HasCache(cacheKey))
            {
                HttpRuntime.Cache.Remove(cacheKey);
            }
        }

        /// <summary>
        /// 删除全部缓存【慎用、慎用】
        /// </summary>
        public static void RemoveAllCache()
        {
            IDictionaryEnumerator cacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                RemoveCache(cacheEnum.Key.ToString());
            }
        }
    }
}