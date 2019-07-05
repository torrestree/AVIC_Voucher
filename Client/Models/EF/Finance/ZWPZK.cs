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
    /// 凭证表头
    /// </summary>
    public partial class ZWPZK
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ZWPZK()
        {
            ListZWPZFL = new List<ZWPZFL>();
        }

        /// <summary>
        /// 凭证分录
        /// <para>子项集合</para>
        /// </summary>
        public virtual List<ZWPZFL> ListZWPZFL { get; set; }
        /// <summary>
        /// 凭证类型
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ZWPZK_LXBH")]
        public virtual ZWPZLX ZWPZLX { get; set; }
        /// <summary>
        /// 凭证内码
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string ZWPZK_PZNM { get; set; }
        /// <summary>
        /// 会计年度
        /// </summary>
        [Column(Order = 1)]
        [StringLength(4)]
        public string ZWPZK_KJND { get; set; }
        /// <summary>
        /// 会计月份
        /// </summary>
        [Column(Order = 2)]
        [StringLength(2)]
        public string ZWPZK_KJQJ { get; set; }
        /// <summary>
        /// 凭证日期
        /// </summary>
        [Column(Order = 3)]
        [StringLength(8)]
        public string ZWPZK_PZRQ { get; set; }
        /// <summary>
        /// 凭证编号
        /// </summary>
        [Column(Order = 4)]
        [StringLength(8)]
        public string ZWPZK_PZBH { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        [Column(Order = 5)]
        [StringLength(2)]
        public string ZWPZK_LXBH { get; set; }

        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZWPZK_FJZS { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        [StringLength(20)]
        public string ZWPZK_ZDR { get; set; }

        [StringLength(20)]
        public string ZWPZK_FHR { get; set; }

        [StringLength(20)]
        public string ZWPZK_JZR { get; set; }

        [StringLength(20)]
        public string ZWPZK_CN { get; set; }

        [StringLength(20)]
        public string ZWPZK_KJZG { get; set; }


        [Column(Order = 7)]
        [StringLength(1)]
        public string ZWPZK_FHF { get; set; }


        [Column(Order = 8)]
        [StringLength(1)]
        public string ZWPZK_JZF { get; set; }


        [Column(Order = 9)]
        [StringLength(1)]
        public string ZWPZK_WZF { get; set; }


        [Column(Order = 10)]
        [StringLength(1)]
        public string ZWPZK_ZFF { get; set; }


        [Column(Order = 11)]
        [StringLength(1)]
        public string ZWPZK_XJDQ { get; set; }

        [StringLength(30)]
        public string ZWPZK_WBBM { get; set; }

        [StringLength(30)]
        public string ZWPZK_WBZJ { get; set; }

        [StringLength(255)]
        public string ZWPZK_WBPZ { get; set; }

        [StringLength(1)]
        public string ZWPZK_CWBZ { get; set; }

        [StringLength(255)]
        public string ZWPZK_CWXX { get; set; }
    }
}
