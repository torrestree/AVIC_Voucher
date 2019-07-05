using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtEFList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMgtEFList<T> : IMgtData<T>
    {
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <returns></returns>
        bool ReadContents();
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ReadContents(string value);
        /// <summary>
        /// 刷新实例集合
        /// </summary>
        /// <returns></returns>
        bool RefreshContents();

        /// <summary>
        /// 读取单个实例
        /// </summary>
        /// <returns></returns>
        bool ReadEntity();
        /// <summary>
        /// 刷新单个实例
        /// </summary>
        /// <returns></returns>
        bool RefreshEntity();

        /// <summary>
        /// 新建单个实例
        /// </summary>
        /// <returns></returns>
        bool AddEntity();

        /// <summary>
        /// 删除单个实例
        /// </summary>
        /// <returns></returns>
        bool DeleteEntity();

        /// <summary>
        /// 保存单个实例
        /// </summary>
        /// <returns></returns>
        bool SaveEntity();
    }
}
