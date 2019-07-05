using Client.DomainModels.Managements.Finance;
using Client.Helpers;
using Client.Models.EF.Finance;
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
    /// Interaction logic for WinZWPZLX.xaml
    /// </summary>
    public partial class WinZWPZLX
    {
        /// <summary>
        /// 凭证类型管理器
        /// </summary>
        public MgtZWPZLX MgtZWPZLX { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public WinZWPZLX()
        {
            InitializeComponent();

            MgtZWPZLX = new MgtZWPZLX();
            PanelMain.DataContext = MgtZWPZLX;
            MgtZWPZLX.ReadContents();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (MgtZWPZLX.SelectedItem == null)
                DHelper.ShowMsg("请至少选择一个凭证类型");
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
