using Client.DomainModels.Managements.BasicInfo;
using Client.Helpers;
using Client.Models.Indept;
using Client.Models.Statics;
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
    /// Interaction logic for WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        MgtSet MgtSet { get; set; }

        public WinLogin()
        {
            InitializeComponent();
            DpDate.SelectedDate = DateTime.Now;
            MgtSet = new MgtSet("Client.dat");
            MgtSet.ReadContents();
            ComboSetConn.ItemsSource = MgtSet.ListView;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            LoginInfo.SqlConn = ComboSetConn.SelectedItem as SqlConn;
            if (LoginInfo.SqlConn == null)
                DHelper.ShowMsg("请选择账套");
            else
            {
                LoginInfo.LoginDate = DpDate.SelectedDate.Value;
                DialogResult = true;
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void BtnSets_Click(object sender, RoutedEventArgs e)
        {
            WinSets win = new WinSets();
            win.ShowDialog();
            MgtSet.ReadContents();
            ComboSetConn.ItemsSource = MgtSet.ListView;
        }
    }
}
