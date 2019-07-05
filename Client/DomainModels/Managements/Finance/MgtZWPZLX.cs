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
    /// 凭证类型管理器
    /// </summary>
    public class MgtZWPZLX : MgtEFList<CtxRuntime, ZWPZLX>
    {
        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "ZWPZLX_LXBH";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(ZWPZLX entity, string value)
        {
            return entity.ZWPZLX_LXBH.NoCaseContains(value) || entity.ZWPZLX_LXMC.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(ZWPZLX obj)
        {
            return SetReadContentsRule(obj, SearchValue);
        }
    }
}
