using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Indept
{
    /// <summary>
    /// SqlConn
    /// </summary>
    [Serializable]
    public class SqlConn
    {
        /// <summary>
        /// 账套名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账套编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 账套地址
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 账套密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"server={Server};database=cwbase{ID.TrimStart('0')};uid=sa;pwd={Password}";
        }
    }
}
