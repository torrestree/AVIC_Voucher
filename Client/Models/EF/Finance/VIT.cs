using Client.Models.EF.BasicInfo;
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
    /// 凭证模板表头
    /// </summary>
    public class VIT
    {
        /// <summary>
        /// 构造
        /// </summary>
        public VIT()
        {
            VITDetails = new List<VITDetail>();
        }

        /// <summary>
        /// 表体实例集合
        /// <para>子项集合</para>
        /// </summary>
        public virtual List<VITDetail> VITDetails { get; set; }

        /// <summary>
        /// 凭证类型
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("VoucherType")]
        public virtual ZWPZLX ZWPZLX { get; set; }
        /// <summary>
        /// 财务主管
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("Supervisor")]
        public virtual ZWZGZD ZWZGZD { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime DesignedDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Designator { get; set; }
        /// <summary>
        /// 凭证类型
        /// </summary>
        [Required]
        [StringLength(2)]
        public string VoucherType { get; set; }
        /// <summary>
        /// 主管
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Supervisor { get; set; }
    }
}
