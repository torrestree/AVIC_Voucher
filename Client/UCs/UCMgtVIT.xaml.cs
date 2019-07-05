using Client.DomainModels.Managements.Finance;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.UCs
{
    /// <summary>
    /// Interaction logic for UCMgtVIT.xaml
    /// </summary>
    public partial class UCMgtVIT : UserControl
    {
        MgtVIT MgtVIT { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public UCMgtVIT()
        {
            InitializeComponent();

            MgtVIT = new MgtVIT();
            PanelContents.DataContext = MgtVIT;
            MgtVIT.OnSelectedItemChanged += t =>
            {
                RefreshEntity();
            };
            MgtVIT.OnEntityChanged += t =>
            {
                RefreshEntity();
            };
            MgtVIT.OnContentsNeedRefresh += () =>
            {
                MgtVIT.ReadContents();
                PanelContents.DataContext = null;
                PanelContents.DataContext = MgtVIT;
            };
            MgtVIT.ReadContents();
        }
        private void RefreshEntity()
        {
            PanelEntity.DataContext = null;
            PanelEntity.DataContext = MgtVIT.Entity;
            DgEntries.ItemsSource = null;
            DgEntries.ItemsSource = MgtVIT.Entries;
        }

        private void BtnQuery_Click(object sender, RoutedEventArgs e)
        {
            MgtVIT.ReadContents();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MgtVIT.AddEntity();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MgtVIT.DeleteEntity();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MgtVIT.SaveEntity();
        }

        private void BtnAddEntry_Click(object sender, RoutedEventArgs e)
        {
            Wins.WinZWKMZD win = new Wins.WinZWKMZD();
            if (win.ShowDialog() == true)
                MgtVIT.AddEntry(win.MgtZWKMZD.SelectedItem);
        }
        private void BtnDeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            MgtVIT.DeleteEntry(DgEntries.SelectedItem as VITDetail);
        }
        private void BtnChangeIsDebit_Click(object sender, RoutedEventArgs e)
        {
            MgtVIT.ChangeIsDebit(DgEntries.SelectedItem as VITDetail);
        }

        private void TbxZWPZLX_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Wins.WinZWPZLX win = new Wins.WinZWPZLX();
            if(win.ShowDialog()==true)
            {
                MgtVIT.SetVoucherType(win.MgtZWPZLX.SelectedItem);
                RefreshEntity();
            } 
        }
        private void TbxSupervisor_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Wins.WinZWZGZD win = new Wins.WinZWZGZD();
            if(win.ShowDialog()==true)
            {
                MgtVIT.SetSupervisor(win.MgtZWZGZD.SelectedItem);
                RefreshEntity();
            }
        }
    }
}
