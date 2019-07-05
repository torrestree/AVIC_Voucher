using Client.DomainModels.Managements.Finance;
using Client.Helpers;
using Client.Models.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for WinPZKImport.xaml
    /// </summary>
    public partial class WinPZKImport
    {
        public VIT VIT { get; set; }
        public DataTable ImportBuffer { get; set; }
        MgtVIT MgtVIT { get; set; }
        MgtZWPZK MgtZWPZK { get; set; }

        public WinPZKImport()
        {
            InitializeComponent();

            MgtVIT = new MgtVIT();
            MgtVIT.ReadContents();
            DgVIT.ItemsSource = MgtVIT.ListView;

            MgtZWPZK = new MgtZWPZK();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            ImportBuffer = MgtZWPZK.ReadFromClipboard(Clipboard.GetText());
            DgExcel.ItemsSource = ImportBuffer.DefaultView;
        }
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (VIT == null)
                DHelper.ShowMsg("请选择一个导入模板");
            else
                DialogResult = true;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void DgVIT_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            VIT = DgVIT.SelectedItem as VIT;
        }
    }
}
