using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMgtData<T> : IMgtBase
    {
        /// <summary>
        /// 实例集合
        /// </summary>
        List<T> Contents { get; set; }
        /// <summary>
        /// 实例集合的默认列表视图
        /// </summary>
        ICollectionView ListView { get; set; }
        /// <summary>
        /// 是否需要刷新实例集合
        /// </summary>
        bool IsContentsNeedRefresh { get; set; }
        /// <summary>
        /// 实例集合需要刷新
        /// <para>事件</para>
        /// </summary>
        event Action OnContentsNeedRefresh;

        /// <summary>
        /// 单个实例
        /// </summary>
        T Entity { get; set; }
        /// <summary>
        /// 是否为新增实例
        /// </summary>
        bool IsNew { get; set; }
        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        bool IsEditing { get; set; }
        /// <summary>
        /// 单个实例有变更
        /// <para>事件</para>
        /// </summary>
        event Action<T> OnEntityChanged;

        /// <summary>
        /// 选择的实例
        /// </summary>
        T SelectedItem { get; set; }
        /// <summary>
        /// 是否读取单个实例
        /// </summary>
        bool IsReadEntity { get; set; }
        /// <summary>
        /// 选择的实例有变更
        /// <para>事件</para>
        /// </summary>
        event Action<T> OnSelectedItemChanged;

        /// <summary>
        /// 搜索值
        /// </summary>
        string SearchValue { get; set; }
        /// <summary>
        /// 搜索
        /// </summary>
        void Search(string value);
    }
}
