using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    /// <summary>
    /// DHelper
    /// </summary>
    public static partial class DHelper
    {
        /// <summary>
        /// 从剪切板读取表格
        /// </summary>
        /// <param name="clipdata"></param>
        /// <returns></returns>
        public static DataTable ReadFromClipboard(string clipdata)
        {
            DataTable dataTable = new DataTable();
            string[] array = clipdata.TrimEnd('\n').Split('\n');
            for (int num = 0; num < array[0].Split('\t').Length; num++)
            {
                DataColumn column = new DataColumn();
                dataTable.Columns.Add(column);
            }
            string[] array2 = array;
            foreach (string text in array2)
            {
                string[] array3 = text.Split('\t');
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);
                for (int j = 0; j < array3.Length; j++)
                {
                    dataRow[j] = array3[j].TrimEnd('\r');
                }
            }
            return dataTable;
        }
    }
}
