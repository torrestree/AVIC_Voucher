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
    /// 核算项目管理器
    /// </summary>
    public class MgtZWHSXM : MgtEFList<CtxRuntime, ZWHSXM>//think 实际上，应该继承MgtEFCategory，核算项目有个类别：ZWXMLB
    {
        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "ZWHSXM_XMNM";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(ZWHSXM entity, string value)
        {
            return entity.ZWHSXM_XMNM.NoCaseContains(value)
                || entity.ZWHSXM_XMBH.NoCaseContains(value)
                || entity.ZWHSXM_XMMC.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(ZWHSXM obj)
        {
            return SetReadContentsRule(obj, SearchValue);
        }
    }
}
