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
    /// 职工字典
    /// </summary>
    public partial class ZWZGZD
    {
        /// <summary>
        /// 单据部门
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ZWZGZD_BMBH")]
        public KCBMZD KCBMZD { get; set; }
        /// <summary>
        /// 职工编号
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ZWZGZD_ZGBH { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column(Order = 1)]
        [StringLength(40)]
        public string ZWZGZD_ZGXM { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [Column(Order = 2)]
        [StringLength(20)]
        public string ZWZGZD_BMBH { get; set; }

        [StringLength(60)]
        public string ZWZGZD_DZ { get; set; }

        [StringLength(20)]
        public string ZWZGZD_DH { get; set; }

        [StringLength(6)]
        public string ZWZGZD_YB { get; set; }


        [Column(Order = 3)]
        public double ZWZGZD_XYXE { get; set; }

        [StringLength(20)]
        public string ZWZGZD_LBBH { get; set; }

        [StringLength(40)]
        public string ZWZGZD_PYJM { get; set; }

        [StringLength(30)]
        public string ZWZGZD_DYTMH { get; set; }

        [StringLength(30)]
        public string ZWZGZD_SJHM { get; set; }

        [StringLength(30)]
        public string ZWZGZD_EMAIL { get; set; }

        [StringLength(30)]
        public string ZWZGZD_CZYBH { get; set; }

        [StringLength(2)]
        public string ZWZGZD_XYDJ { get; set; }


        [Column(Order = 4)]
        [StringLength(1)]
        public string ZWZGZD_YWY { get; set; }
        /// <summary>
        /// 是否封存
        /// </summary>
        [Column(Order = 5)]
        [StringLength(1)]
        public string ZWZGZD_SFFC { get; set; }
    }
}
