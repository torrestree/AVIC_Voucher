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
    /// 凭证类型
    /// </summary>
    public partial class ZWPZLX
    {
        /// <summary>
        /// 类型编号
        /// <para>主键</para>
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string ZWPZLX_LXBH { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [Column(Order = 1)]
        [StringLength(20)]
        public string ZWPZLX_LXMC { get; set; }
        /// <summary>
        /// 凭证字
        /// </summary>
        [Column(Order = 2)]
        [StringLength(4)]
        public string ZWPZLX_PZZ { get; set; }

        [StringLength(255)]
        public string ZWPZLX_XZKM { get; set; }

        [StringLength(1)]
        public string ZWPZLX_XZXZ { get; set; }

        [StringLength(2)]
        public string ZWPZLX_SCGS { get; set; }


        [Column(Order = 3)]
        [StringLength(2)]
        public string ZWPZLX_DYSX { get; set; }


        [Column(Order = 4)]
        [StringLength(1)]
        public string ZWPZLX_CNQZ { get; set; }


        [Column(Order = 5)]
        [StringLength(1)]
        public string ZWPZLX_ZGQZ { get; set; }
    }
}
