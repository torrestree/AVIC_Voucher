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
    /// 单据部门
    /// </summary>
    public partial class KCBMZD
    {
        /// <summary>
        /// 部门编号
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string KCBMZD_BMBH { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column(Order = 1)]
        [StringLength(40)]
        public string KCBMZD_BMMC { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        [Column(Order = 2)]
        [StringLength(1)]
        public string KCBMZD_JS { get; set; }
        /// <summary>
        /// 是否为末级
        /// </summary>
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KCBMZD_MX { get; set; }
        /// <summary>
        /// 是否为核算部门
        /// </summary>
        [StringLength(20)]
        public string KCBMZD_HSBM { get; set; }

        [StringLength(6)]
        public string KCBMZD_YB { get; set; }

        [StringLength(60)]
        public string KCBMZD_DZ { get; set; }

        [StringLength(20)]
        public string KCBMZD_DH { get; set; }

        [StringLength(20)]
        public string KCBMZD_CZ { get; set; }

        [StringLength(20)]
        public string KCBMZD_FZR { get; set; }

        [StringLength(20)]
        public string KCBMZD_LXR { get; set; }

        [StringLength(50)]
        public string KCBMZD_EML { get; set; }

        [StringLength(30)]
        public string KCBMZD_DYTMH { get; set; }
        /// <summary>
        /// 是否封存
        /// </summary>
        [Column(Order = 4)]
        [StringLength(1)]
        public string KCBMZD_SFFC { get; set; }
    }
}
