namespace Client.Models.EF.Finance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 核算项目类别
    /// </summary>
    public partial class ZWXMLB
    {
        /// <summary>
        /// 类别编号
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string ZWXMLB_LBBH { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        [Column(Order = 1)]
        [StringLength(30)]
        public string ZWXMLB_LBMC { get; set; }

        [Column(Order = 2)]
        [StringLength(1)]
        public string ZWXMLB_JZLJ { get; set; }

        [StringLength(9)]
        public string ZWXMLB_BMJG { get; set; }
    }
}
