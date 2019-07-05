using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Helpers
{
    /// <summary>
    /// DHelper
    /// </summary>
    public static partial class DHelper
    {
        /// <summary>
        /// 弹窗显示提示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        public static void ShowMsg(string msg, string title)
        {
            MessageBox.Show(msg, title);
        }
        /// <summary>
        /// 弹窗显示提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowMsg(string msg)
        {
            ShowMsg(msg, "");
        }
        /// <summary>
        /// 弹窗显示错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="title"></param>
        public static void ShowEx(Exception ex, string title)
        {
            MessageBox.Show(ex.ToString(), title);
        }
        /// <summary>
        /// 弹窗显示错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowEx(Exception ex)
        {
            ShowEx(ex, "");
        }

        /// <summary>
        /// 弹窗显示确认信息（是、否）
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool ShowOKCancel(string msg, string title)
        {
            if (MessageBox.Show(msg, title, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 弹窗显示确认信息（是、否）
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool ShowOKCancel(string msg)
        {
            return ShowOKCancel(msg, "");
        }
    }
}
