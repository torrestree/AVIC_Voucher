using Client.Models.EF.Base.Abstracts;
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
    /// 核算科目
    /// </summary>
    public partial class ZWKMZD : PSChildren<ZWKMZD>
    {
        /// <summary>
        /// 科目编号
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ZWKMZD_KMBH { get; set; }
        /// <summary>
        /// 科目名称
        /// </summary>
        [Column(Order = 1)]
        [StringLength(60)]
        public string ZWKMZD_KMMC { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        [Column(Order = 2)]
        [StringLength(1)]
        public string ZWKMZD_JS { get; set; }
        /// <summary>
        /// 是否为末级
        /// </summary>
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZWKMZD_MX { get; set; }
        /// <summary>
        /// 科目属性
        /// <para>资产01；负债02；共同03；所有者权益04；成本05；损益06</para>
        /// </summary>
        [Column(Order = 4)]
        [StringLength(2)]
        public string ZWKMZD_SX { get; set; }
        /// <summary>
        /// 助记码
        /// </summary>
        [StringLength(20)]
        public string ZWKMZD_ZJM { get; set; }
        /// <summary>
        /// 核算数量
        /// <para>0：不核算；1：核算</para>
        /// </summary>
        [Column(Order = 5)]
        [StringLength(1)]
        public string ZWKMZD_HSSL { get; set; }
        /// <summary>
        /// 核算外币
        /// <para>0：不核算；1：单一外币；2：所有币种</para>
        /// </summary>
        [Column(Order = 6)]
        [StringLength(1)]
        public string ZWKMZD_HSWB { get; set; }
        /// <summary>
        /// 外币编号
        /// </summary>
        [StringLength(10)]
        public string ZWKMZD_WBBH { get; set; }
        /// <summary>
        /// 科目性质
        /// <para>0：普通科目；1：借方栏目；2：贷方栏目</para>
        /// </summary>
        [Column(Order = 7)]
        [StringLength(1)]
        public string ZWKMZD_XZ { get; set; }
        /// <summary>
        /// 账页格式
        /// <para>0：不定义；1：金额帐；2：数量金额帐；3：外币金额帐；4：数量外币金额帐</para>
        /// </summary>
        [Column(Order = 8)]
        [StringLength(1)]
        public string ZWKMZD_ZYGS { get; set; }
        /// <summary>
        /// 是否日记账
        /// </summary>
        [Column(Order = 9)]
        [StringLength(1)]
        public string ZWKMZD_RJZ { get; set; }
        /// <summary>
        /// 是否银行账
        /// </summary>
        [Column(Order = 10)]
        [StringLength(1)]
        public string ZWKMZD_YHZ { get; set; }
        /// <summary>
        /// 余额方向
        /// </summary>
        [Column(Order = 11)]
        [StringLength(1)]
        public string ZWKMZD_YEFX { get; set; }
        /// <summary>
        /// 现金科目
        /// <para>0：其他；1：现金；2：银行存款；3其他现金及现金等价物</para>
        /// </summary>
        [Column(Order = 12)]
        [StringLength(1)]
        public string ZWKMZD_XJKM { get; set; }
        /// <summary>
        /// 个人往来
        /// <para>0：否；1：是</para>
        /// </summary>
        [Column(Order = 13)]
        [StringLength(1)]
        public string ZWKMZD_GRWL { get; set; }
        /// <summary>
        /// 单位往来
        /// <para>0：否；1：是</para>
        /// </summary>
        [Column(Order = 14)]
        [StringLength(1)]
        public string ZWKMZD_DWWL { get; set; }
        /// <summary>
        /// 专项核算
        /// <para>0：否；1：是</para>
        /// </summary>
        [Column(Order = 15)]
        [StringLength(1)]
        public string ZWKMZD_ZXHS { get; set; }
        /// <summary>
        /// 部门核算
        /// <para>0：否；1：是</para>
        /// </summary>
        [Column(Order = 16)]
        [StringLength(1)]
        public string ZWKMZD_BMHS { get; set; }

        [StringLength(30)]
        public string ZWKMZD_XX01 { get; set; }

        [StringLength(30)]
        public string ZWKMZD_XX02 { get; set; }

        [StringLength(30)]
        public string ZWKMZD_XX03 { get; set; }


        [Column(Order = 17)]
        public double ZWKMZD_XJXE { get; set; }

        [StringLength(2)]
        public string ZWKMZD_YSPZ { get; set; }

        [StringLength(2)]
        public string ZWKMZD_TZLB { get; set; }


        [Column(Order = 18)]
        [StringLength(1)]
        public string ZWKMZD_QMJP { get; set; }

        [StringLength(1)]
        public string ZWKMZD_TZBS { get; set; }

        [StringLength(1)]
        public string ZWKMZD_SFFC { get; set; }

        [StringLength(1)]
        public string ZWKMZD_BMJB { get; set; }
    }
}
