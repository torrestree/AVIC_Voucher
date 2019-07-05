using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtEFCategory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCat"></typeparam>
    public interface IMgtEFCategory<T, TCat> : IMgtEFList<T>
    {
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        bool ReadContents(TCat category);
        /// <summary>
        /// 添加单个实例
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        bool AddEntity(TCat category);
    }
}
