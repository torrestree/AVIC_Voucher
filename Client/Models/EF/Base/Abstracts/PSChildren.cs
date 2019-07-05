using Client.Models.EF.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Abstracts
{
    /// <summary>
    /// PSChildren
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PSChildren<T> : IPSChildren<T>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public PSChildren()
        {
            Children = new List<T>();
        }

        /// <summary>
        /// 是否为第一级
        /// </summary>
        [NotMapped]
        public bool IsFirstLevel { get; set; }
        /// <summary>
        /// 子项集合
        /// <para>不映射</para>
        /// </summary>
        [NotMapped]
        public List<T> Children { get; set; }
    }
}
