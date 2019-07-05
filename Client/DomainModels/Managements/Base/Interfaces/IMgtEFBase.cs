using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtEFBase
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IMgtEFBase<Ctx, T> : IMgtData<T>
    {
        /// <summary>
        /// 实例集合的DbContext
        /// </summary>
        Ctx CtxContents { get; set; }
        /// <summary>
        /// 实例集合的查询条件
        /// </summary>
        IQueryable<T> CondContents { get; set; }

        /// <summary>
        /// 单个实例的DbContext
        /// </summary>
        Ctx CtxEntity { get; set; }
        /// <summary>
        /// 单个实例的查询条件
        /// </summary>
        IQueryable<T> CondEntity { get; set; }
    }
}
