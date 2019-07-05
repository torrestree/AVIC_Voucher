using Client.DomainModels.Managements.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFList
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract partial class MgtEFList<Ctx, T> : MgtEFCurd<Ctx, T>, IMgtEFList<T>
        where Ctx : CtxRuntime, new()
        where T : class, new()
    {
        /// <summary>
        /// 选择的实例有变更
        /// <para>触发</para>
        /// </summary>
        /// <param name="selected_item"></param>
        protected override void RaiseSelectedItemChanged(T selected_item)
        {
            base.RaiseSelectedItemChanged(selected_item);
            ReadEntity();
        }

        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <returns></returns>
        public virtual bool ReadContents()
        {
            return ReadContentsFrame(t => t.AsNoTracking());
        }
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool ReadContents(string value)
        {
            Expression<Func<T, bool>> exp = t => SetReadContentsRule(t, value);
            return ReadContentsFrame(t => t.AsNoTracking().Where(exp.Compile()).AsQueryable());
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected abstract bool SetReadContentsRule(T entity, string value);
        /// <summary>
        /// 刷新实例集合
        /// </summary>
        /// <returns></returns>
        public virtual bool RefreshContents()
        {
            return ReadContentsFrame();
        }

        /// <summary>
        /// 读取单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool ReadEntity()
        {
            if (SelectedItem == null) return false;
            return ReadEntityFrame(t => t.Where(GetKeyEqualsExpression(SelectedItem)));
        }
        /// <summary>
        /// 刷新单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool RefreshEntity()
        {
            return ReadEntityFrame();
        }

        /// <summary>
        /// 新建单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool AddEntity()
        {
            return AddEntityFrame();
        }

        /// <summary>
        /// 删除单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool DeleteEntity()
        {
            return DeleteEntityFrame();
        }

        /// <summary>
        /// 保存单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool SaveEntity()
        {
            return SaveEntityFrame();
        }
    }
}
