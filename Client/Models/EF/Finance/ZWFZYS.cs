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
    /// 凭证辅助
    /// </summary>
    public partial class ZWFZYS
    {
        /// <summary>
        /// 凭证分录
        /// <para>父项实例</para>
        /// </summary>
        [ForeignKey("ZWFZYS_PZNM,ZWFZYS_FLNM")]
        public virtual ZWPZFL ZWPZFL { get; set; }
        /// <summary>
        /// 核算科目
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ZWFZYS_KMBH")]
        public virtual ZWKMZD ZWKMZD { get; set; }
        /// <summary>
        /// 财务部门
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ZWFZYS_BMBH")]
        public virtual LSBMZD LSBMZD { get; set; }
        /// <summary>
        /// 核算项目1
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ZWFZYS_XM01")]
        public virtual ZWHSXM XM01 { get; set; }
        /// <summary>
        /// 凭证内码
        /// <para>主键1</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string ZWFZYS_PZNM { get; set; }
        /// <summary>
        /// 凭证分录内码
        /// <para>主键2</para>
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string ZWFZYS_FLNM { get; set; }
        /// <summary>
        /// 凭证辅助编号
        /// <para>主键3</para>
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string ZWFZYS_YSBH { get; set; }
        /// <summary>
        /// 科目编号
        /// </summary>
        [Column(Order = 3)]
        [StringLength(30)]
        public string ZWFZYS_KMBH { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_BMBH { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_DWBH { get; set; }
        /// <summary>
        /// 职工编号
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_ZGBH { get; set; }
        /// <summary>
        /// 核算项目1
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_XM01 { get; set; }
        /// <summary>
        /// 核算项目2
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_XM02 { get; set; }
        /// <summary>
        /// 核算项目3
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_XM03 { get; set; }
        /// <summary>
        /// 核算项目4
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_XM04 { get; set; }
        /// <summary>
        /// 核算项目5
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_XM05 { get; set; }
        /// <summary>
        /// 外币编号
        /// </summary>
        [StringLength(10)]
        public string ZWFZYS_WBBH { get; set; }
        /// <summary>
        /// 记账方向
        /// </summary>
        [Column(Order = 4)]
        [StringLength(1)]
        public string ZWFZYS_JZFX { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column(Order = 5)]
        public double ZWFZYS_SL { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Column(Order = 6)]
        public double ZWFZYS_DJ { get; set; }
        /// <summary>
        /// 外币
        /// </summary>
        [Column(Order = 7)]
        public double ZWFZYS_WB { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        [Column(Order = 8)]
        public double ZWFZYS_HL { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Column(Order = 9)]
        public double ZWFZYS_JE { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        [StringLength(8)]
        public string ZWFZYS_YWRQ { get; set; }
        /// <summary>
        /// 业务号？？？？
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_YWH { get; set; }
        /// <summary>
        /// 责任人？？？？
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_ZRR { get; set; }
        /// <summary>
        /// 凭据号？？？？
        /// </summary>
        [StringLength(20)]
        public string ZWFZYS_PJH { get; set; }


        [Column(Order = 10)]
        [StringLength(1)]
        public string ZWFZYS_DWDZ { get; set; }


        [Column(Order = 11)]
        public double ZWFZYS_SJ01 { get; set; }


        [Column(Order = 12)]
        public double ZWFZYS_SJ02 { get; set; }


        [Column(Order = 13)]
        public double ZWFZYS_SJ03 { get; set; }


        [Column(Order = 14)]
        public double ZWFZYS_SJ04 { get; set; }


        [Column(Order = 15)]
        public double ZWFZYS_SJ05 { get; set; }


        [Column(Order = 16)]
        public double ZWFZYS_SJ06 { get; set; }


        [Column(Order = 17)]
        public double ZWFZYS_SJ07 { get; set; }


        [Column(Order = 18)]
        public double ZWFZYS_SJ08 { get; set; }


        [Column(Order = 19)]
        public double ZWFZYS_SJ09 { get; set; }


        [Column(Order = 20)]
        public double ZWFZYS_SJ10 { get; set; }


        [Column(Order = 21)]
        public double ZWFZYS_SJ11 { get; set; }


        [Column(Order = 22)]
        public double ZWFZYS_SJ12 { get; set; }


        [Column(Order = 23)]
        public double ZWFZYS_SJ13 { get; set; }


        [Column(Order = 24)]
        public double ZWFZYS_SJ14 { get; set; }


        [Column(Order = 25)]
        public double ZWFZYS_SJ15 { get; set; }


        [Column(Order = 26)]
        public double ZWFZYS_SJ16 { get; set; }


        [Column(Order = 27)]
        public double ZWFZYS_SJ17 { get; set; }


        [Column(Order = 28)]
        public double ZWFZYS_SJ18 { get; set; }


        [Column(Order = 29)]
        public double ZWFZYS_SJ19 { get; set; }


        [Column(Order = 30)]
        public double ZWFZYS_SJ20 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM01 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM02 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM03 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM04 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM05 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM06 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM07 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM08 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM09 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM10 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM11 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM12 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM13 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM14 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM15 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM16 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM17 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM18 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM19 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM20 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM21 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM22 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM23 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM24 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM25 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM26 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM27 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM28 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM29 { get; set; }

        [StringLength(100)]
        public string ZWFZYS_SM30 { get; set; }

        [StringLength(4)]
        public string ZWFZYS_JSFS { get; set; }

        [StringLength(20)]
        public string ZWFZYS_JSH { get; set; }

        [StringLength(200)]
        public string ZWFZYS_YT { get; set; }

        [StringLength(1)]
        public string ZWFZYS_ZGDZ { get; set; }

        [StringLength(1)]
        public string ZWFZYS_YHDZ { get; set; }
    }
}
