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
    /// 核算部门
    /// </summary>
    public partial class LSBMZD : PSChildren<LSBMZD>
    {
        /// <summary>
        /// 部门编号
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string LSBMZD_BMBH { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column(Order = 1)]
        [StringLength(40)]
        public string LSBMZD_BMMC { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        [Column(Order = 2)]
        [StringLength(1)]
        public string LSBMZD_JS { get; set; }
        /// <summary>
        /// 是否为末级
        /// </summary>
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LSBMZD_MX { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100)]
        public string LSBMZD_BZ { get; set; }
        /// <summary>
        /// 是否封存
        /// </summary>
        [StringLength(1)]
        public string LSBMZD_SFFC { get; set; }
    }
}
