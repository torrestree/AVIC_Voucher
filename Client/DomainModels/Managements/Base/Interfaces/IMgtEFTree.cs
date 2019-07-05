using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtEFTree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMgtEFTree<T> : IMgtEFList<T>
    {
        /// <summary>
        /// 实例集合的默认树形视图
        /// </summary>
        ICollectionView TreeView { get; set; }

        /// <summary>
        /// 新建同级单个实例
        /// </summary>
        /// <returns></returns>
        bool AddCurrent();
        /// <summary>
        /// 新建下级单个实例
        /// </summary>
        /// <returns></returns>
        bool AddSub();
    }
}
