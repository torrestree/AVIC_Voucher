using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    /// <summary>
    /// DHelper
    /// </summary>
    public static partial class DHelper
    {
        /// <summary>
        /// 转换为字符串日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConverToDateString(DateTime date)
        {
            return date.Year.ToString("0000") + date.Month.ToString("00") + date.Day.ToString("00");
        }
    }
}
