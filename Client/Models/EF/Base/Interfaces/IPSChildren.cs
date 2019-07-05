using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Interfaces
{
    /// <summary>
    /// IPSChildren
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPSChildren<T>
    {
        /// <summary>
        /// 是否为第一级
        /// </summary>
        bool IsFirstLevel { get; set; }
        /// <summary>
        /// 子项集合
        /// </summary>
        List<T> Children { get; set; }
    }
}
