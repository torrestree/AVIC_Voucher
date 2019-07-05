using Client.DomainModels.Managements.Finance;
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
    /// Interaction logic for WinZWKMZD.xaml
    /// </summary>
    public partial class WinZWKMZD
    {
        /// <summary>
        /// 核算科目管理器
        /// </summary>
        public MgtZWKMZD MgtZWKMZD { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public WinZWKMZD()
        {
            InitializeComponent();

            MgtZWKMZD = new MgtZWKMZD();
            PanelMain.DataContext = MgtZWKMZD;
            MgtZWKMZD.ReadContents();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (MgtZWKMZD.SelectedItem == null)
                DHelper.ShowMsg("请选择一个核算科目");
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
