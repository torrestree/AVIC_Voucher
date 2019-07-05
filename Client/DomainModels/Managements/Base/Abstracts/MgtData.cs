using Client.DomainModels.Managements.Base.Interfaces;
using Client.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MgtData<T> : MgtBase, IMgtData<T>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MgtData()
        {
            IsNew = false;
            IsEditing = false;
            IsReadEntity = true;
            IsContentsNeedRefresh = true;
        }

        /// <summary>
        /// 当前未保存
        /// <para>提示</para>
        /// </summary>
        protected const string MsgUnsaved = "当前数据尚未保存，是否继续？";
        /// <summary>
        /// 读取成功
        /// <para>提示</para>
        /// </summary>
        protected const string MsgReadOK = "数据读取成功！";
        /// <summary>
        /// 读取失败
        /// <para>提示</para>
        /// </summary>
        protected const string MsgReadFailed = "错误：数据读取失败！";
        /// <summary>
        /// 新建成功
        /// <para>提示</para>
        /// </summary>
        protected const string MsgAddOK = "数据新建成功！";
        /// <summary>
        /// 新建失败
        /// <para>提示</para>
        /// </summary>
        protected const string MsgAddFailed = "错误：数据新建失败！";
        /// <summary>
        /// 确认废弃
        /// <para>提示</para>
        /// </summary>
        protected const string MsgObsoleteConfirm = "确认废弃？";
        /// <summary>
        /// 废弃成功
        /// <para>提示</para>
        /// </summary>
        protected const string MsgObsoleteOK = "数据废弃成功！";
        /// <summary>
        /// 废弃失败
        /// <para>提示</para>
        /// </summary>
        protected const string MsgObsoleteFailed = "错误：数据废弃失败！";
        /// <summary>
        /// 确认删除
        /// <para>提示</para>
        /// </summary>
        protected const string MsgDeleteConfirm = "数据删除后将无法恢复，确认删除？";
        /// <summary>
        /// 删除成功
        /// <para>提示</para>
        /// </summary>
        protected const string MsgDeleteOK = "数据删除成功！";
        /// <summary>
        /// 删除失败
        /// <para>提示</para>
        /// </summary>
        protected const string MsgDeleteFailed = "错误：数据删除失败！";
        /// <summary>
        /// 保存成功
        /// <para>提示</para>
        /// </summary>
        protected const string MsgSaveOK = "数据保存成功！";
        /// <summary>
        /// 保存失败
        /// <para>提示</para>
        /// </summary>
        protected const string MsgSaveFailed = "错误：数据保存失败！";
        /// <summary>
        /// 写修改日志失败
        /// <para>提示</para>
        /// </summary>
        protected const string MsgWriteRevisedRecordFailed = "写修改日志失败！";

        /// <summary>
        /// 实例集合
        /// </summary>
        public List<T> Contents { get; set; }
        /// <summary>
        /// 实例集合的默认列表视图
        /// </summary>
        public ICollectionView ListView { get; set; }
        /// <summary>
        /// 是否需要刷新实例集合
        /// </summary>
        public bool IsContentsNeedRefresh { get; set; }
        /// <summary>
        /// 实例集合需要刷新
        /// <para>事件</para>
        /// </summary>
        public event Action OnContentsNeedRefresh;
        /// <summary>
        /// 实例集合需要刷新
        /// <para>触发</para>
        /// </summary>
        protected void RaiseContentsNeedRefresh()
        {
            if (IsContentsNeedRefresh)
                DHelper.InvokeOnMain(() => OnContentsNeedRefresh?.Invoke());
        }
        /// <summary>
        /// 创建实例集合视图
        /// </summary>
        protected virtual void BuildContentsView()
        {
            DispatcherOperation operation = DHelper.InvokeOnMain(() => ListView = Contents.AsICV());
            operation.Wait();
        }

        /// <summary>
        /// 单个实例
        /// </summary>
        public T Entity { get; set; }
        /// <summary>
        /// 是否为新增实例
        /// </summary>
        public bool IsNew { get; set; }
        /// <summary>
        /// 是否处于编辑状态
        /// </summary>
        public bool IsEditing { get; set; }
        /// <summary>
        /// 单个实例有变更
        /// <para>事件</para>
        /// </summary>
        public event Action<T> OnEntityChanged;
        /// <summary>
        /// 单个实例有变更
        /// <para>触发</para>
        /// </summary>
        protected void RaiseEntityChanged()
        {
            DHelper.InvokeOnMain(() => OnEntityChanged?.Invoke(Entity));
        }
        /// <summary>
        /// 未保存中止
        /// </summary>
        /// <returns></returns>
        protected bool BlockedByUnsaved()
        {
            if (IsEditing)
                return !ShowOKCancel(MsgUnsaved);
            else
                return false;
        }
        /// <summary>
        /// 创建单个实例视图
        /// </summary>
        protected virtual void BuildEntityView()
        {
            DHelper.InvokeOnMain(() => RaiseEntityChanged());
        }
        /// <summary>
        /// 清除单个实例视图
        /// </summary>
        protected virtual void ClearEntityView()
        {
            DHelper.InvokeOnMain(() => RaiseEntityChanged());
        }

        /// <summary>
        /// 选择的实例
        /// <para>字段</para>
        /// </summary>
        private T FieldSelectedItem;
        /// <summary>
        /// 选择的实例
        /// </summary>
        public T SelectedItem
        {
            get { return FieldSelectedItem; }
            set
            {
                FieldSelectedItem = value;
                if (IsReadEntity)
                    RaiseSelectedItemChanged(value);
            }
        }
        /// <summary>
        /// 是否读取单个实例
        /// </summary>
        public bool IsReadEntity { get; set; }
        /// <summary>
        /// 选择的实例有变更
        /// <para>事件</para>
        /// </summary>
        public event Action<T> OnSelectedItemChanged;
        /// <summary>
        /// 选择的实例有变更
        /// <para>触发</para>
        /// </summary>
        /// <param name="selected_item"></param>
        protected virtual void RaiseSelectedItemChanged(T selected_item)
        {
            DHelper.InvokeOnMain(() => OnSelectedItemChanged?.Invoke(selected_item));
        }

        /// <summary>
        /// 搜索值
        /// <para>字段</para>
        /// </summary>
        private string FieldSearchValue;
        /// <summary>
        /// 搜索值
        /// </summary>
        public string SearchValue
        {
            get { return FieldSearchValue; }
            set
            {
                FieldSearchValue = value;
                DHelper.InvokeOnMain(() => Search(value));
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        public void Search(string value)
        {
            if (ListView != null)
            {
                DHelper.InvokeOnMain(() =>
                {
                    ListView.Filter = new Predicate<object>(t => SetSearchRule((T)t));
                    ListView.Refresh();
                });
            }
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected abstract bool SetSearchRule(T obj);

        /// <summary>
        /// 读取错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected bool ReadFailed(Exception ex)
        {
            Msg = MsgReadFailed;
            Ex = ex;
            return false;
        }
        /// <summary>
        /// 新增错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected bool AddFailed(Exception ex)
        {
            Msg = MsgAddFailed;
            Ex = ex;
            return false;
        }
        /// <summary>
        /// 废弃错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected bool ObsoleteFailed(Exception ex)
        {
            Msg = MsgObsoleteFailed;
            Ex = ex;
            return false;
        }
        /// <summary>
        /// 删除错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected bool DeleteFailed(Exception ex)
        {
            Msg = MsgDeleteFailed;
            Ex = ex;
            return false;
        }
        /// <summary>
        /// 保存错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected bool SaveFailed(Exception ex)
        {
            Msg = MsgSaveFailed;
            Ex = ex;
            return false;
        }
    }
}
