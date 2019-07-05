using Client.Models.EF.Context;
using linq = System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFCurd
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class MgtEFCurd<Ctx, T> : MgtEFBase<Ctx, T>
        where Ctx : CtxRuntime, new()
        where T : class, new()
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MgtEFCurd()
        {
            ParaModel = Expression.Parameter(typeof(T));
            SetPropertyNames();
            BuildPropertyInfo();
        }

        /// <summary>
        /// 数据类表达式参数
        /// </summary>
        protected linq.ParameterExpression ParaModel { get; set; }

        /// <summary>
        /// 主键字段名称
        /// </summary>
        protected string PropertyKey { get; set; }
        /// <summary>
        /// 主键属性信息
        /// </summary>
        protected PropertyInfo InfoKey { get; set; }

        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected abstract void SetPropertyNames();
        /// <summary>
        /// 建立属性信息
        /// </summary>
        protected virtual void BuildPropertyInfo()
        {
            InfoKey = typeof(T).GetProperty(PropertyKey);
        }

        /// <summary>
        /// 获得主键相等表达式
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected linq.Expression<Func<T, bool>> GetKeyEqualsExpression(T entity)
        {
            linq.BinaryExpression binary = linq.Expression.Equal(linq.Expression.Property(ParaModel, InfoKey), linq.Expression.Constant(GetKeyValue(entity)));
            return linq.Expression.Lambda<Func<T, bool>>(binary, ParaModel);
        }
        /// <summary>
        /// 获得主键值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object GetKeyValue(T entity)
        {
            return InfoKey.GetValue(entity, null);
        }

        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        /// <returns></returns>
        protected virtual bool ReadContentsFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            try
            {
                CtxContents = new Ctx();
                CondContents = query_condition(CtxContents.Set<T>());
                Contents = CondContents.ToList();
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="set_query_condition"></param>
        /// <returns></returns>
        protected virtual bool ReadContentsFrame(Action set_query_condition)
        {
            try
            {
                CtxContents = new Ctx();
                set_query_condition();
                Contents = CondContents.ToList();
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <returns></returns>
        protected virtual bool ReadContentsFrame()
        {
            if (CondContents == null) return false;
            try
            {
                CtxContents = new Ctx();
                Contents = CondContents.ToList();
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }

        /// <summary>
        /// 读取单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        /// <returns></returns>
        protected virtual bool ReadEntityFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            if (BlockedByUnsaved()) return false;
            try
            {
                CtxEntity = new Ctx();
                CondEntity = query_condition(CtxEntity.Set<T>());
                Entity = CondEntity.SingleOrDefault();
                IsNew = false;
                IsEditing = false;
                BuildEntityView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 读取单个实例
        /// <para>框架</para>
        /// </summary>
        /// <returns></returns>
        protected virtual bool ReadEntityFrame()
        {
            if (BlockedByUnsaved()) return false;
            if (CondEntity == null) return false;
            try
            {
                CtxEntity = new Ctx();
                Entity = CondEntity.SingleOrDefault();
                IsNew = false;
                IsEditing = false;
                BuildEntityView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }

        /// <summary>
        /// 新建单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="ini_entity"></param>
        protected virtual bool AddEntityFrame(Action ini_entity = null)
        {
            if (BlockedByUnsaved()) return false;
            try
            {
                CtxEntity = new Ctx();
                Entity = new T();
                ini_entity?.Invoke();
                CtxEntity.Set<T>().Add(Entity);
                IsNew = true;
                IsEditing = true;
                BuildEntityView();
                return true;
            }
            catch (Exception ex) { return AddFailed(ex); }
        }

        /// <summary>
        /// 删除单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        /// <returns></returns>
        protected virtual bool DeleteEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return false;
            if (!ShowOKCancel(MsgDeleteConfirm)) return false;
            try
            {
                CtxEntity.Set<T>().Remove(Entity);
                addtional_execution?.Invoke();
                CtxEntity.SaveChanges();
                IsNew = false;
                IsEditing = false;
                Msg = MsgDeleteOK;
                ClearEntityView();
                RaiseContentsNeedRefresh();
                return true;
            }
            catch (Exception ex) { return DeleteFailed(ex); }
        }

        /// <summary>
        /// 保存单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        /// <returns></returns>
        protected virtual bool SaveEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return false;
            try
            {
                if (SaveValidation())
                {
                    addtional_execution?.Invoke();
                    CtxEntity.SaveChanges();
                    IsNew = false;
                    IsEditing = false;
                    Msg = MsgSaveOK;
                    RaiseEntityChanged();
                    RaiseContentsNeedRefresh();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex) { return SaveFailed(ex); }
        }
        /// <summary>
        /// 保存验证单个实例
        /// </summary>
        /// <returns></returns>
        protected virtual bool SaveValidation() { return true; }
    }
}
