using Client.DomainModels.Managements.BasicInfo;
using Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Wins
{
    /// <summary>
    /// Interaction logic for WinZWZGZD.xaml
    /// </summary>
    public partial class WinZWZGZD
    {
        /// <summary>
        /// 职工字典管理器
        /// </summary>
        public MgtZWZGZD MgtZWZGZD { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public WinZWZGZD()
        {
            InitializeComponent();

            MgtZWZGZD = new MgtZWZGZD();
            PanelMain.DataContext = MgtZWZGZD;
            MgtZWZGZD.ReadContents();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (MgtZWZGZD.SelectedItem == null)
                DHelper.ShowMsg("请选择一位员工");
            else
                DialogResult = true;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void DgContents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BtnOK_Click(null, null);
        }
    }
}
