using Client.DomainModels.Managements.Base.Interfaces;
using Client.Helpers;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFRd
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="TRef"></typeparam>
    /// <typeparam name="TEntry"></typeparam>
    /// <typeparam name="TDetail"></typeparam>
    public abstract class MgtEFRd<Ctx, TRef, TEntry, TDetail> : MgtEFList<Ctx, TRef>, IMgtEFRd<TRef, TEntry, TDetail>
        where Ctx : CtxRuntime, new()
        where TRef : class, new()
    {
        /// <summary>
        /// 单个表体实例
        /// </summary>
        public TEntry Entry { get; set; }

        /// <summary>
        /// 表体集合的默认列表视图
        /// </summary>
        public ICollectionView Entries { get; set; }
        /// <summary>
        /// 辅助集合的默认列表视图
        /// </summary>
        public ICollectionView Details { get; set; }

        /// <summary>
        /// 表体集合字段名称
        /// </summary>
        protected string PropertyEntres { get; set; }
        /// <summary>
        /// 表体集合属性信息
        /// </summary>
        protected PropertyInfo InfoEntries { get; set; }
        /// <summary>
        /// 辅助集合字段名称
        /// </summary>
        protected string PropertyDetails { get; set; }
        /// <summary>
        /// 辅助集合属性信息
        /// </summary>
        protected PropertyInfo InfoDetails { get; set; }

        /// <summary>
        /// 创建单个实例视图
        /// </summary>
        protected override void BuildEntityView()
        {
            base.BuildEntityView();
            Entries = ((List<TEntry>)GetEntries(Entity)).AsICV();
            Entries.Refresh();
            Details = null;
        }
        /// <summary>
        /// 获取表体集合
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object GetEntries(TRef entity)
        {
            return InfoEntries.GetValue(entity, null);
        }
        /// <summary>
        /// 创建辅助集合视图
        /// </summary>
        protected virtual void BuildDetailsView()
        {
            Details = ((List<TDetail>)GetDetails(Entry)).AsICV();
        }
        /// <summary>
        /// 获取辅助集合
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected object GetDetails(TEntry entry)
        {
            return InfoDetails.GetValue(entry, null);
        }
    }
}
