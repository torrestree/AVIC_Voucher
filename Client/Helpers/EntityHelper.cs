using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Client.Helpers
{
    /// <summary>
    /// DHelper
    /// </summary>
    public static partial class DHelper
    {
        /// <summary>
        /// 复制实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static T CopyEntity<T>(this T origin)
            where T : new()
        {
            T current = new T();
            PropertyInfo[] infos = origin.GetType().GetProperties();
            foreach (PropertyInfo info in infos)
            {
                object value = info.GetValue(origin, null);
                if (value == null) continue;
                Type type = info.GetType();
                if (type == typeof(Nullable))
                    info.SetValue(current, Convert.ChangeType(value, type.GetGenericArguments()[0]), null);
                else
                    info.SetValue(current, Convert.ChangeType(value, type), null);
            }
            return current;
        }

        /// <summary>
        /// 转换为ICollectionView
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ICollectionView AsICV(this IList data)
        {
            return CollectionViewSource.GetDefaultView(data);
        }
        /// <summary>
        /// 转换为ICollectionView
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ICollectionView AsICV(this IEnumerable data)
        {
            return CollectionViewSource.GetDefaultView(data);
        }

        /// <summary>
        /// 忽略大小写是否包含
        /// </summary>
        /// <param name="value"></param>
        /// <param name="search_value"></param>
        /// <returns></returns>
        public static bool NoCaseContains(this string value, string search_value)
        {
            if (value == null)
            {
                if (search_value == null)
                    return true;
                else
                    return false;
            }
            else
                return value.ToUpper().Contains(search_value.ToUpper());
        }
    }
}
