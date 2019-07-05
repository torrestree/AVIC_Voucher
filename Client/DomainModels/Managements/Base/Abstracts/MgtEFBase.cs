using Client.DomainModels.Managements.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFBase
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class MgtEFBase<Ctx, T> : MgtData<T>, IMgtEFBase<Ctx, T>
        where Ctx : CtxRuntime, new()
        where T : new()
    {
        /// <summary>
        /// 实例集合的DbContext
        /// </summary>
        public Ctx CtxContents { get; set; }
        /// <summary>
        /// 实例集合的查询条件
        /// </summary>
        public IQueryable<T> CondContents { get; set; }

        /// <summary>
        /// 单个实例的DbContext
        /// </summary>
        public Ctx CtxEntity { get; set; }
        /// <summary>
        /// 单个实例的查询条件
        /// </summary>
        public IQueryable<T> CondEntity { get; set; }
    }
}
