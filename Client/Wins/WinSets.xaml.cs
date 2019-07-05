using Client.DomainModels.Managements.BasicInfo;
using Client.Models.Indept;
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
    /// Interaction logic for WinSets.xaml
    /// </summary>
    public partial class WinSets
    {
        MgtSet MgtSet { get; set; }

        public WinSets()
        {
            InitializeComponent();

            MgtSet = new MgtSet("Client.dat");
            ReadContents();
        }
        private void ReadContents()
        {
            MgtSet.ReadContents();
            DgContents.ItemsSource = MgtSet.ListView;
        }
        private void RefreshEntity()
        {
            PanelEntity.DataContext = null;
            PbxPassword.Password = null;

            PanelEntity.DataContext = MgtSet.Entity;
            if (MgtSet.Entity != null)
                PbxPassword.Password = MgtSet.Entity.Password;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (MgtSet.Add())
                RefreshEntity();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MgtSet.Delete())
            {
                ReadContents();
                RefreshEntity();
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MgtSet.Save(PbxPassword.Password))
                ReadContents();
        }
        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DgContents_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            ReadEntity();
        }
        private void DgContents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ReadEntity();
        }
        private void ReadEntity()
        {
            MgtSet.Entity = DgContents.SelectedItem as SqlConn;
            MgtSet.IsNew = false;
            RefreshEntity();
        }
    }
}
