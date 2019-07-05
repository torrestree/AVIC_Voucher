using Client.DomainModels.Managements.Base.Interfaces;
using Client.Helpers;
using Client.Models.EF.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFTree
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class MgtEFTree<Ctx, T> : MgtEFList<Ctx, T>, IMgtEFTree<T>
        where Ctx : CtxRuntime, new()
        where T : class, IPSChildren<T>, new()
    {
        /// <summary>
        /// 实例集合的默认树形视图
        /// </summary>
        public ICollectionView TreeView { get; set; }

        /// <summary>
        /// 级数字段名称
        /// </summary>
        protected string PropertyLevel { get; set; }
        /// <summary>
        /// 级数属性信息
        /// </summary>
        protected PropertyInfo InfoLevel { get; set; }
        /// <summary>
        /// 是否包含下级字段名称
        /// </summary>
        protected string PropertyHasChildren { get; set; }
        /// <summary>
        /// 是否包含下级属性信息
        /// </summary>
        protected PropertyInfo InfoHasChildren { get; set; }

        /// <summary>
        /// 建立属性信息
        /// </summary>
        protected override void BuildPropertyInfo()
        {
            base.BuildPropertyInfo();
            InfoLevel = typeof(T).GetProperty(PropertyLevel);
            InfoHasChildren = typeof(T).GetProperty(PropertyHasChildren);
        }

        /// <summary>
        /// 创建实例集合视图
        /// </summary>
        protected override void BuildContentsView()
        {
            base.BuildContentsView();
            DispatcherOperation operation = DHelper.InvokeOnMain(() => TreeView = Contents.Where(t => t.IsFirstLevel).AsICV());
            operation.Wait();
        }

        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        /// <returns></returns>
        protected override bool ReadContentsFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            try
            {
                CtxContents = new Ctx();
                CondContents = query_condition(CtxContents.Set<T>());
                Contents = CondContents.ToList();
                BuildTreeChildren("1");
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
        protected override bool ReadContentsFrame(Action set_query_condition)
        {
            try
            {
                CtxContents = new Ctx();
                set_query_condition();
                Contents = CondContents.ToList();
                BuildTreeChildren("1");
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
        protected override bool ReadContentsFrame()
        {
            try
            {
                CtxContents = new Ctx();
                Contents = CondContents.ToList();
                BuildTreeChildren("1");
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 创建树形数据节点
        /// </summary>
        /// <param name="level"></param>
        /// <param name="parent"></param>
        protected virtual void BuildTreeChildren(string level, T parent = null)
        {
            foreach (T item in GetChildrenList(level, parent))
            {
                if (parent == null)
                    item.IsFirstLevel = true;
                else
                    parent.Children.Add(item);

                if(IsHasChildren(item))
                {
                    string sublevel = (int.Parse(GetLevelValue(item)) + 1).ToString();
                    BuildTreeChildren(sublevel, item);
                }
            }
        }
        /// <summary>
        /// 获取下级实例集合
        /// </summary>
        /// <param name="level"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private IEnumerable<T> GetChildrenList(string level, T parent)
        {
            if (parent == null)
                return Contents.Where(t => GetLevelValue(t) == level);
            else
                return Contents.Where(t => GetLevelValue(t) == level).Where(t => IsKeyStartsWith(t, parent));
        }

        /// <summary>
        /// 获得级数值
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        protected string GetLevelValue(T Entity)
        {
            return InfoLevel.GetValue(Entity, null).ToString();
        }
        /// <summary>
        /// 获得是否包含下级值
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        protected string GetHasChildrenValaue(T Entity)
        {
            return InfoHasChildren.GetValue(Entity, null).ToString();
        }
        /// <summary>
        /// 是否包含下级
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        protected bool IsHasChildren(T Entity)
        {
            return GetHasChildrenValaue(Entity) == "0";
        }
        /// <summary>
        /// 主键是否左相等
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Parent"></param>
        /// <returns></returns>
        protected bool IsKeyStartsWith(T Entity, T Parent)
        {
            return GetKeyValue(Entity).ToString().StartsWith(GetKeyValue(Parent).ToString());
        }

        /// <summary>
        /// 新建同级单个实例
        /// </summary>
        /// <returns></returns>
        public bool AddCurrent()
        {
            Msg = MsgNullMethod;
            return false;
        }
        /// <summary>
        /// 新建下级单个实例
        /// </summary>
        /// <returns></returns>
        public bool AddSub()
        {
            Msg = MsgNullMethod;
            return false;
        }
    }
}
