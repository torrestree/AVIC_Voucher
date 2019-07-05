using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.BasicInfo
{
    /// <summary>
    /// 审批表头
    /// </summary>
    public partial class PPSPZSJ
    {
        /// <summary>
        /// 构造
        /// </summary>
        public PPSPZSJ()
        {
            ListPPSPMXSJ = new List<PPSPMXSJ>();
        }

        /// <summary>
        /// 审批表体
        /// <para>子项集合</para>
        /// </summary>
        public virtual List<PPSPMXSJ> ListPPSPMXSJ { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string PPSPZSJ_YWID { get; set; }
        /// <summary>
        /// 单据流水
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string PPSPZSJ_DJLS { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        [StringLength(1)]
        public string PPSPZSJ_SPZT { get; set; }
        /// <summary>
        /// 当前节点
        /// </summary>
        [StringLength(20)]
        public string PPSPZSJ_DQJD { get; set; }
        /// <summary>
        /// 提交日期
        /// </summary>
        [StringLength(8)]
        public string PPSPZSJ_TJRQ { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        [StringLength(20)]
        public string PPSPZSJ_TJSJ { get; set; }
        /// <summary>
        /// 审完日期
        /// </summary>
        [StringLength(8)]
        public string PPSPZSJ_SWRQ { get; set; }
        /// <summary>
        /// 审完时间
        /// </summary>
        [StringLength(20)]
        public string PPSPZSJ_SWSJ { get; set; }
        /// <summary>
        /// 提交人员
        /// </summary>
        [StringLength(200)]
        public string PPSPZSJ_TJRY { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        [StringLength(200)]
        public string PPSPZSJ_SHRY { get; set; }

        [StringLength(20)]
        public string PPSPZSJ_SDZT { get; set; }
        /// <summary>
        /// 审批意见
        /// </summary>
        [Column(TypeName = "text")]
        public string PPSPZSJ_SPYJ { get; set; }
    }
}
