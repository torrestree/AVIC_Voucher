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
    /// 主键编码
    /// </summary>
    public partial class LSNBBM
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        [Column(Order = 0)]
        [StringLength(2)]
        public string LSNBBM_XTBH { get; set; }
        /// <summary>
        /// 内码编号
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string LSNBBM_NMBH { get; set; }
        /// <summary>
        /// 内码名称
        /// </summary>
        [Column(Order = 2)]
        [StringLength(20)]
        public string LSNBBM_NMMC { get; set; }
        /// <summary>
        /// 当前内码
        /// </summary>
        [Column(Order = 3)]
        [StringLength(20)]
        public string LSNBBM_DQNM { get; set; }


        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LSNBBM_NMCD { get; set; }

        [StringLength(1)]
        public string LSNBBM_FWZQ { get; set; }
    }
}
