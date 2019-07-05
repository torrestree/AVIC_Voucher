using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.Context;
using Client.Models.EF.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Finance
{
    /// <summary>
    /// 核算部门管理器
    /// </summary>
    public class MgtLSBMZD : MgtEFTree<CtxRuntime, LSBMZD>
    {
        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "LSBMZD_BMBH";
            PropertyLevel = "LSBMZD_JS";
            PropertyHasChildren = "LSBMZD_MX";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(LSBMZD entity, string value)
        {
            return entity.LSBMZD_BMBH.NoCaseContains(value) || entity.LSBMZD_BMMC.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(LSBMZD obj)
        {
            return SetReadContentsRule(obj, SearchValue);
        }
    }
}
