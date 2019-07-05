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
    /// 审批表体
    /// </summary>
    public partial class PPSPMXSJ
    {
        /// <summary>
        /// 审批表头
        /// <para>父项实例</para>
        /// </summary>
        [ForeignKey("PPSPMXSJ_YWID,PPSPMXSJ_DJLS")]
        public virtual PPSPZSJ PPSPZSJ { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string PPSPMXSJ_YWID { get; set; }
        /// <summary>
        /// 单据流水
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string PPSPMXSJ_DJLS { get; set; }
        /// <summary>
        /// 审批节点
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string PPSPMXSJ_SPJD { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        [Column(Order = 3)]
        [StringLength(200)]
        public string PPSPMXSJ_SPR { get; set; }
        /// <summary>
        /// 审批备注
        /// </summary>
        [StringLength(1)]
        public string PPSPMXSJ_SPBZ { get; set; }
        /// <summary>
        /// 审批日期
        /// </summary>
        [StringLength(8)]
        public string PPSPMXSJ_SPRQ { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        [StringLength(20)]
        public string PPSPMXSJ_SPSJ { get; set; }
        /// <summary>
        /// 审批意见
        /// </summary>
        [Column(TypeName = "text")]
        public string PPSPMXSJ_SPYJ { get; set; }


        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PPSPMXSJ_XH { get; set; }
    }
}
