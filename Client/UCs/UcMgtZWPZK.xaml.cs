using Client.DomainModels.Managements.Finance;
using Client.Helpers;
using Client.Models.EF.Finance;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.UCs
{
    /// <summary>
    /// Interaction logic for UcMgtZWPZK.xaml
    /// </summary>
    public partial class UcMgtZWPZK : UserControl
    {
        MgtZWPZK MgtZWPZK { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public UcMgtZWPZK()
        {
            InitializeComponent();

            MgtZWPZK = new MgtZWPZK();
            MgtZWPZK.OnEntityChanged += t =>
            {
                PanelPZK.DataContext = null;
                PanelPZK.DataContext = t;
                DgPZFL.ItemsSource = null;
                DgPZFL.ItemsSource = t.ListZWPZFL;
                DgFZYS.ItemsSource = null;
            };

            BtnAdd_Click(null, null);

            if (string.IsNullOrEmpty(LoginInfo.LoginName))
                DHelper.ShowMsg("业务人员为空，请在界面左下角填写业务人员");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MgtZWPZK.AddEntity();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MgtZWPZK.SaveEntity();
        }
        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginInfo.LoginName))
            {
                DHelper.ShowMsg("业务人员为空，请在界面左下角填写业务人员");
                return;
            }

            Wins.WinPZKImport win = new Wins.WinPZKImport();
            if(win.ShowDialog()==true)
            {
                MgtZWPZK.ImportBuffer = win.ImportBuffer;
                if (MgtZWPZK.Import(win.VIT))
                {
                    PanelPZK.DataContext = null;
                    PanelPZK.DataContext = MgtZWPZK.Entity;
                    DgPZFL.ItemsSource = null;
                    DgPZFL.ItemsSource = MgtZWPZK.Entity.ListZWPZFL;
                    DgPZFL.Items.Refresh();
                    DgFZYS.ItemsSource = null;
                    DgFZYS.Items.Refresh();
                }
            }
        }

        private void DgPZFL_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (DgPZFL.SelectedItem is ZWPZFL zWPZFL)
            {
                DgFZYS.ItemsSource = zWPZFL.ListZWFZYS;
            }
            DgFZYS.Items.Refresh();
        }
        private void DgFZYS_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            MgtZWPZK.ReCalculate(DgPZFL.SelectedItem as ZWPZFL);
            DgPZFL.Items.Refresh();
        }
    }
}
