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
    /// 核算项目
    /// </summary>
    public partial class ZWHSXM : PSChildren<ZWHSXM>
    {
        /// <summary>
        /// 项目内码
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string ZWHSXM_XMNM { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Column(Order = 1)]
        [StringLength(20)]
        public string ZWHSXM_XMBH { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column(Order = 2)]
        [StringLength(200)]
        public string ZWHSXM_XMMC { get; set; }
        /// <summary>
        /// 类别编号
        /// </summary>
        [Column(Order = 3)]
        [StringLength(2)]
        public string ZWHSXM_LBBH { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        [Column(Order = 4)]
        [StringLength(1)]
        public string ZWHSXM_JS { get; set; }
        /// <summary>
        /// 是否为末级
        /// </summary>
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZWHSXM_MX { get; set; }


        [Column(Order = 6)]
        [StringLength(1)]
        public string ZWHSXM_WGF { get; set; }

        [StringLength(8)]
        public string ZWHSXM_WGRQ { get; set; }


        [Column(Order = 7)]
        public double ZWHSXM_SJ01 { get; set; }


        [Column(Order = 8)]
        public double ZWHSXM_SJ02 { get; set; }


        [Column(Order = 9)]
        public double ZWHSXM_SJ03 { get; set; }


        [Column(Order = 10)]
        public double ZWHSXM_SJ04 { get; set; }


        [Column(Order = 11)]
        public double ZWHSXM_SJ05 { get; set; }


        [Column(Order = 12)]
        public double ZWHSXM_SJ06 { get; set; }


        [Column(Order = 13)]
        public double ZWHSXM_SJ07 { get; set; }


        [Column(Order = 14)]
        public double ZWHSXM_SJ08 { get; set; }


        [Column(Order = 15)]
        public double ZWHSXM_SJ09 { get; set; }


        [Column(Order = 16)]
        public double ZWHSXM_SJ10 { get; set; }


        [Column(Order = 17)]
        public double ZWHSXM_SJ11 { get; set; }


        [Column(Order = 18)]
        public double ZWHSXM_SJ12 { get; set; }


        [Column(Order = 19)]
        public double ZWHSXM_SJ13 { get; set; }


        [Column(Order = 20)]
        public double ZWHSXM_SJ14 { get; set; }


        [Column(Order = 21)]
        public double ZWHSXM_SJ15 { get; set; }


        [Column(Order = 22)]
        public double ZWHSXM_SJ16 { get; set; }


        [Column(Order = 23)]
        public double ZWHSXM_SJ17 { get; set; }


        [Column(Order = 24)]
        public double ZWHSXM_SJ18 { get; set; }


        [Column(Order = 25)]
        public double ZWHSXM_SJ19 { get; set; }


        [Column(Order = 26)]
        public double ZWHSXM_SJ20 { get; set; }


        [Column(Order = 27)]
        public double ZWHSXM_SJ21 { get; set; }


        [Column(Order = 28)]
        public double ZWHSXM_SJ22 { get; set; }


        [Column(Order = 29)]
        public double ZWHSXM_SJ23 { get; set; }


        [Column(Order = 30)]
        public double ZWHSXM_SJ24 { get; set; }


        [Column(Order = 31)]
        public double ZWHSXM_SJ25 { get; set; }


        [Column(Order = 32)]
        public double ZWHSXM_SJ26 { get; set; }


        [Column(Order = 33)]
        public double ZWHSXM_SJ27 { get; set; }


        [Column(Order = 34)]
        public double ZWHSXM_SJ28 { get; set; }


        [Column(Order = 35)]
        public double ZWHSXM_SJ29 { get; set; }


        [Column(Order = 36)]
        public double ZWHSXM_SJ30 { get; set; }


        [Column(Order = 37)]
        public double ZWHSXM_SJ31 { get; set; }


        [Column(Order = 38)]
        public double ZWHSXM_SJ32 { get; set; }


        [Column(Order = 39)]
        public double ZWHSXM_SJ33 { get; set; }


        [Column(Order = 40)]
        public double ZWHSXM_SJ34 { get; set; }


        [Column(Order = 41)]
        public double ZWHSXM_SJ35 { get; set; }


        [Column(Order = 42)]
        public double ZWHSXM_SJ36 { get; set; }


        [Column(Order = 43)]
        public double ZWHSXM_SJ37 { get; set; }


        [Column(Order = 44)]
        public double ZWHSXM_SJ38 { get; set; }


        [Column(Order = 45)]
        public double ZWHSXM_SJ39 { get; set; }


        [Column(Order = 46)]
        public double ZWHSXM_SJ40 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM01 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM02 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM03 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM04 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM05 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM06 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM07 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM08 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM09 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM10 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM11 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM12 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM13 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM14 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM15 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM16 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM17 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM18 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM19 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM20 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM21 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM22 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM23 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM24 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM25 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM26 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM27 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM28 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM29 { get; set; }

        [StringLength(100)]
        public string ZWHSXM_XM30 { get; set; }

        [StringLength(200)]
        public string ZWHSXM_ZJM { get; set; }

        [StringLength(1)]
        public string ZWHSXM_SFFC { get; set; }

        [StringLength(1)]
        public string ZWHSXM_BMJB { get; set; }

        [StringLength(2)]
        public string ZWHSXM_PZLX { get; set; }
    }
}
