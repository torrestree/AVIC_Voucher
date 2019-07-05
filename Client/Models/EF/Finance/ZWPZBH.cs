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
    /// 凭证编号
    /// </summary>
    public partial class ZWPZBH
    {
        /// <summary>
        /// 会计年度
        /// <para>主键1</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string ZWPZBH_KJND { get; set; }
        /// <summary>
        /// 会计月份
        /// <para>主键2</para>
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string ZWPZBH_KJQJ { get; set; }
        /// <summary>
        /// 凭证字
        /// <para>主键3</para>
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string ZWPZBH_PZZ { get; set; }
        /// <summary>
        /// 凭证日期
        /// </summary>
        [Column(Order = 3)]
        [StringLength(8)]
        public string ZWPZBH_PZRQ { get; set; }
        /// <summary>
        /// 凭证编号
        /// </summary>
        [Column(Order = 4)]
        [StringLength(4)]
        public string ZWPZBH_PZBH { get; set; }
    }
}
