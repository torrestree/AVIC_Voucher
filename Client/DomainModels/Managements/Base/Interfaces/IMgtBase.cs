using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtBase
    /// </summary>
    public interface IMgtBase
    {
        /// <summary>
        /// 是否弹窗显示提示信息
        /// </summary>
        bool IsShowMsg { get; set; }
        /// <summary>
        /// 提示信息缓存
        /// </summary>
        string Msg { get; set; }
        /// <summary>
        /// 错误信息缓存
        /// </summary>
        Exception Ex { get; set; }

        /// <summary>
        /// 是否弹窗显示确认信息
        /// </summary>
        bool IsShowConfirm { get; set; }
    }
}
