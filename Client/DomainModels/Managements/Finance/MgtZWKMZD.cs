using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.Context;
using Client.Models.EF.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Client.DomainModels.Managements.Finance
{
    /// <summary>
    /// 核算科目管理器
    /// </summary>
    public class MgtZWKMZD : MgtEFTree<CtxRuntime, ZWKMZD>
    {
        private int FieldType;
        /// <summary>
        /// 科目类别
        /// </summary>
        public int Type
        {
            get { return FieldType; }
            set
            {
                FieldType = value;
                FilterType();
            }
        }

        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "ZWKMZD_KMBH";
            PropertyLevel = "ZWKMZD_JS";
            PropertyHasChildren = "ZWKMZD_MX";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(ZWKMZD entity, string value)
        {
            return entity.ZWKMZD_KMBH.NoCaseContains(value) || entity.ZWKMZD_KMMC.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(ZWKMZD obj)
        {
            if (Type == 0)
                return SetReadContentsRule(obj, SearchValue);
            else
                return obj.ZWKMZD_SX == Type.ToString("00") && SetReadContentsRule(obj, SearchValue);
        }

        /// <summary>
        /// 根据科目类型筛选
        /// </summary>
        private void FilterType()
        {
            if (ListView == null || TreeView == null) return;
            if (Type == 0)
            {
                ListView.Filter = null;
                TreeView.Filter = null;
            }
            else
            {
                ListView.Filter = new Predicate<object>(t => ((ZWKMZD)t).ZWKMZD_SX == Type.ToString("00"));
                TreeView.Filter = new Predicate<object>(t => ((ZWKMZD)t).ZWKMZD_SX == Type.ToString("00"));
            }
        }
    }
}
