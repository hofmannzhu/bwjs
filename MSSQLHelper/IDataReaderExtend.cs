using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLHelper
{
    public static class IDataReaderExtend
    {

        /// <summary>
        /// 从datareader读取数据到实体对象，实体的属性名称必须与数据库中的字段名称一致
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEnumerable<T> ReadTo<T>(this IDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            if (reader.Read())
            {
                int fcount = reader.FieldCount;

                INamedMemberAccessor<T>[] accessors = new INamedMemberAccessor<T>[fcount];

                PropertyAccessorManager drm = new PropertyAccessorManager();

                for (int i = 0; i < fcount; i++)
                {

                    accessors[i] = drm.FindAccessor<T>(reader.GetName(i));

                }

                do
                {

                    T t = new T();

                    for (int i = 0; i < fcount; i++)
                    {

                        if (!reader.IsDBNull(i) && accessors[i] != null)

                            accessors[i].SetValue(t, reader.GetValue(i));
                    }
                    list.Add(t);
                    //yield return t;

                } while (reader.Read());
            }
            if (reader != null)
                reader.Close();
            return list;
        }

        #region ReadTo方法的帮助类

        interface INamedMemberAccessor<T>
        {

            void SetValue(T targe, object newValue);
        }
        class PropertyAccessor<T, P> : INamedMemberAccessor<T>
        {
            private Func<T, P> GetValueDelegate;
            private Action<T, P> SetValueDelegate;
            public PropertyAccessor(Type type, string propertyName)
            {
                var propertyInfo = type.GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    GetValueDelegate = (Func<T, P>)Delegate.CreateDelegate(typeof(Func<T, P>), propertyInfo.GetGetMethod());

                    SetValueDelegate = (Action<T, P>)Delegate.CreateDelegate(typeof(Action<T, P>), propertyInfo.GetSetMethod());
                }
            }

            P GetValue(T targe)
            {
                return GetValueDelegate(targe);
            }

            void INamedMemberAccessor<T>.SetValue(T targe, object newValue)
            {
                SetValueDelegate(targe, (P)newValue);
            }
        }

        class PropertyAccessorManager
        {
            private static Dictionary<string, object> accessorCache;
            static PropertyAccessorManager()
            {
                accessorCache = new Dictionary<string, object>();
            }
            public INamedMemberAccessor<T> FindAccessor<T>(string memberName)
            {
                var type = typeof(T);
                var key = type.FullName + memberName;

                INamedMemberAccessor<T> accessor;
                object obj;
                accessorCache.TryGetValue(key, out obj);
                accessor = obj as INamedMemberAccessor<T>;
                if (accessor == null)
                {

                    var propertyInfo = type.GetProperty(memberName);

                    if (propertyInfo == null)

                        return null;

                    accessor = Activator.CreateInstance(

                    typeof(PropertyAccessor<,>).MakeGenericType(type, propertyInfo.PropertyType)

                    , type

                    , memberName

                    ) as INamedMemberAccessor<T>;

                    accessorCache.Add(key, accessor);

                }
                return accessor;
            }
        }
        #endregion

    }
}
