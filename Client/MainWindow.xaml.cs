using Client.Helpers;
using Client.Models.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        bool isdown { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public MainWindow()
        {
            StyleManager.ApplicationTheme = new FluentTheme();
            FluentPalette.Palette.FontFamily = new FontFamily("Microsoft YaHei UI");

            InitializeComponent();

            Wins.WinLogin win = new Wins.WinLogin();
            if(win.ShowDialog()==true)
            {
                using (Models.EF.Context.CtxRuntime ctx = new Models.EF.Context.CtxRuntime())
                {
                    ctx.VIT.FirstOrDefault();
                }
                DpLogin.SelectedDate = LoginInfo.LoginDate;
            }
            else
                Environment.Exit(0);

            //LoginInfo.SqlConn = new Models.Indept.SqlConn() { ID = "004", Name = "江航", Server = @".\lcserver", Password = "sniper89757" };
            //using(Models.EF.Context.CtxRuntime ctx=new Models.EF.Context.CtxRuntime())
            //{
            //    ctx.VIT.FirstOrDefault();
            //}
            //Wins.WinZWKMZD win = new Wins.WinZWKMZD();
            //win.ShowDialog();
        }

        private void WinMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("是否退出系统", "", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void BtnCloseCurrent_Click(object sender, RoutedEventArgs e)
        {
            ClosePage(false);
        }
        private void BtnCloseOthers_Click(object sender, RoutedEventArgs e)
        {
            int count = TclMain.Items.Count;
            if (count > 1)
            {
                for (count--; count >= 0; count--)
                {
                    object obj = TclMain.Items[count];
                    if (obj != TclMain.SelectedItem)
                    {
                        TclMain.Items.Remove(obj);
                    }
                }
            }
        }
        private void BtnCloseAll_Click(object sender, RoutedEventArgs e)
        {
            ClosePage(true);
        }
        private void ClosePage(bool allclose)
        {
            if (allclose)
            {
                while (TclMain.Items.Count > 0)
                {
                    TclMain.Items.RemoveAt(0);
                }
            }
            else if (TclMain.SelectedIndex != -1)
            {
                TclMain.Items.RemoveAt(TclMain.SelectedIndex);
            }
        }

        private void ItemVITEdit_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            UCs.UCMgtVIT uc = new UCs.UCMgtVIT();
            RadTabItem item = new RadTabItem() { Content = uc, Header = ((RadPanelBarItem)sender).Header };
            TclMain.Items.Add(item);
            item.IsSelected = true;
        }
        private void ItemVoucherImport_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            UCs.UcMgtZWPZK uc = new UCs.UcMgtZWPZK();
            RadTabItem item = new RadTabItem() { Content = uc, Header = ((RadPanelBarItem)sender).Header };
            TclMain.Items.Add(item);
            item.IsSelected = true;
        }

        private void DpLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoginInfo.LoginDate = DpLogin.SelectedDate.GetValueOrDefault(DateTime.Now);
        }
        private void TbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginInfo.LoginName = TbxName.Text;
        }
    }
}
