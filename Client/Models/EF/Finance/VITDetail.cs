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
    /// 凭证模板表体
    /// </summary>
    public class VITDetail
    {
        /// <summary>
        /// 表头实例
        /// <para>父项实例</para>
        /// </summary>
        [ForeignKey("TemplateID")]
        public virtual VIT VIT { get; set; }
        /// <summary>
        /// 核算科目
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("AccountID")]
        public virtual ZWKMZD ZWKMZD { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 父项ID
        /// <para>外键</para>
        /// </summary>
        public int TemplateID { get; set; }
        /// <summary>
        /// 核算科目ID
        /// <para>外键</para>
        /// </summary>
        [Required]
        [StringLength(30)]
        public string AccountID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public int? Price { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 是否核算项目
        /// </summary>
        public bool IsAP { get; set; }
        /// <summary>
        /// 核算项目位置
        /// </summary>
        public int? APIndex { get; set; }
        /// <summary>
        /// 核算项目类别位置
        /// <para>外键</para>
        /// </summary>
        public int? APCatIndex { get; set; }
        /// <summary>
        /// 是否核算部门
        /// </summary>
        public bool IsAD { get; set; }
        /// <summary>
        /// 核算部门位置
        /// </summary>
        public int? ADIndex { get; set; }
        /// <summary>
        /// 借贷标志
        /// </summary>
        public bool IsDebit { get; set; }
    }
}
