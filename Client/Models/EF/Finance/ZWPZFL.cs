using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Finance
{
    /// <summary>
    /// 凭证分录
    /// </summary>
    public partial class ZWPZFL
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ZWPZFL()
        {
            ListZWFZYS = new List<ZWFZYS>();
        }

        /// <summary>
        /// 凭证辅助
        /// <para>子项集合</para>
        /// </summary>
        public virtual List<ZWFZYS> ListZWFZYS { get; set; }
        /// <summary>
        /// 凭证表头
        /// <para>父项实例</para>
        /// </summary>
        [ForeignKey("ZWPZFL_PZNM")]
        public virtual ZWPZK ZWPZK { get; set; }
        /// <summary>
        /// 核算科目
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ZWPZFL_KMBH")]
        public virtual ZWKMZD ZWKMZD { get; set; }
        /// <summary>
        /// 凭证内码
        /// <para>主键1</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string ZWPZFL_PZNM { get; set; }
        /// <summary>
        /// 凭证分录内码
        /// <para>主键2</para>
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string ZWPZFL_FLNM { get; set; }
        /// <summary>
        /// 分录编号
        /// </summary>
        [Column(Order = 2)]
        [StringLength(4)]
        public string ZWPZFL_FLBH { get; set; }
        /// <summary>
        /// 科目编号
        /// </summary>
        [Column(Order = 3)]
        [StringLength(30)]
        public string ZWPZFL_KMBH { get; set; }

        [StringLength(6)]
        public string ZWPZFL_TZXM { get; set; }
        /// <summary>
        /// 借方发生
        /// </summary>
        [StringLength(4)]
        public string ZWPZFL_JSFS { get; set; }


        [Column(Order = 4)]
        [StringLength(200)]
        public string ZWPZFL_ZY { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Column(Order = 5)]
        public double ZWPZFL_JE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column(Order = 6)]
        public double ZWPZFL_SL { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Column(Order = 7)]
        public double ZWPZFL_DJ { get; set; }
        /// <summary>
        /// 外币
        /// </summary>
        [Column(Order = 8)]
        public double ZWPZFL_WB { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        [Column(Order = 9)]
        public double ZWPZFL_HL { get; set; }
        /// <summary>
        /// 记账方向
        /// </summary>
        [Column(Order = 10)]
        [StringLength(1)]
        public string ZWPZFL_JZFX { get; set; }

        [StringLength(20)]
        public string ZWPZFL_JSH { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        [StringLength(8)]
        public string ZWPZFL_YWRQ { get; set; }
        /// <summary>
        /// 外币编号
        /// </summary>
        [StringLength(10)]
        public string ZWPZFL_WBBH { get; set; }


        [Column(Order = 11)]
        [StringLength(1)]
        public string ZWPZFL_YHDZ { get; set; }
    }
}
