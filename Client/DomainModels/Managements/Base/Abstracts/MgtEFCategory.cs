using Client.DomainModels.Managements.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFCategory
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCat"></typeparam>
    public abstract class MgtEFCategory<Ctx, T, TCat> : MgtEFList<Ctx, T>, IMgtEFCategory<T, TCat>
        where Ctx : CtxRuntime, new()
        where T : class, new()
        where TCat : class
    {
        /// <summary>
        /// 类别字段名称
        /// </summary>
        protected string PropertyCategory { get; set; }
        /// <summary>
        /// 类别属性信息
        /// </summary>
        protected PropertyInfo InfoCategory { get; set; }
        /// <summary>
        /// 类别类主键字段名称
        /// </summary>
        protected string PropertyCategoryKey { get; set; }
        /// <summary>
        /// 类别类主键属性信息
        /// </summary>
        protected PropertyInfo InfoCategoryKey { get; set; }

        /// <summary>
        /// 建立属性信息
        /// </summary>
        protected override void BuildPropertyInfo()
        {
            base.BuildPropertyInfo();
            InfoCategory = typeof(T).GetProperty(PropertyCategory);
            InfoCategoryKey = typeof(TCat).GetProperty(PropertyCategoryKey);
        }

        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool ReadContents(TCat category)
        {
            if (category == null) return false;
            return ReadContentsFrame(t => t.AsNoTracking().Where(GetCategoryEqualsExpression(category)));
        }

        /// <summary>
        /// 获得类别相等表达式
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        protected Expression<Func<T, bool>> GetCategoryEqualsExpression(TCat Category)
        {
            BinaryExpression binary = Expression.Equal(Expression.Property(ParaModel, InfoCategory), Expression.Constant(GetCategoryKeyValue(Category)));
            return Expression.Lambda<Func<T, bool>>(binary, ParaModel);
        }
        /// <summary>
        /// 获得类别实例主键值
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        protected string GetCategoryKeyValue(TCat Category)
        {
            return InfoCategoryKey.GetValue(Category, null).ToString();
        }

        /// <summary>
        /// 添加单个实例
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public virtual bool AddEntity(TCat category)
        {
            if (category == null) return false;
            return AddEntityFrame(() => InfoCategory.SetValue(Entity, GetCategoryKeyValue(category), null));
        }
    }
}
