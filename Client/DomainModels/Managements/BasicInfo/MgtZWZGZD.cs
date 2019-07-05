using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.BasicInfo;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.BasicInfo
{
    /// <summary>
    /// 职工字典管理器
    /// </summary>
    public class MgtZWZGZD : MgtEFList<CtxRuntime, ZWZGZD>
    {
        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "ZWZGZD_ZGBH";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(ZWZGZD entity, string value)
        {
            return entity.ZWZGZD_ZGBH.NoCaseContains(value) || entity.ZWZGZD_ZGXM.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(ZWZGZD obj)
        {
            return SetReadContentsRule(obj, SearchValue);
        }
    }
}
