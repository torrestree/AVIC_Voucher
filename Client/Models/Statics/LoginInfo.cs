using Client.Models.Indept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Statics
{
    /// <summary>
    /// LoginInfo
    /// </summary>
    public static class LoginInfo
    {
        public static string LoginName { get; set; }

        public static DateTime LoginDate { get; set; }

        /// <summary>
        /// SqlConn
        /// </summary>
        public static SqlConn SqlConn { get; set; }
    }
}
