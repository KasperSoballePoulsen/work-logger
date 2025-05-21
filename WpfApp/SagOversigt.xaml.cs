using BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SagOversigt.xaml
    /// </summary>
    public partial class SagOversigt : UserControl
    {
        private ObservableCollection<DTO.model.Sag> sager = new ObservableCollection<DTO.model.Sag>();
        private List<DTO.model.Afdeling> afdelinger = new List<DTO.model.Afdeling>();
        DTO.model.Afdeling afdelingValgt = null;
        public SagOversigt()
        {
            InitializeComponent();

            afdelinger = AfdelingBLL.GetAfdelinger();

            AfdelingComboBox.ItemsSource = afdelinger;

            AfdelingComboBox.SelectionChanged += AfdelingComboBoxChanged;
        }

        private void AfdelingComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            afdelingValgt = AfdelingComboBox.SelectedItem as DTO.model.Afdeling;
            UpdateSagerList();


            SagListBox.ItemsSource = sager;
        }

        private void OpretSagAction(object sender, RoutedEventArgs e)
        {
           
            var vindue = new OpretSagWindow();

            vindue.ShowDialog();
            if (afdelingValgt != null)
            {

                UpdateSagerList();
            }

            
        }

        private void UpdateSagerList()
        {
            List<DTO.model.Sag> updatedSagerList = SagBLL.GetSagerByAfdelingId(afdelingValgt.Id);
            sager.Clear();

            foreach (DTO.model.Sag sag in updatedSagerList)
            {
                sager.Add(sag);
            }
        }

        private void OpdaterSagAction(object sender, RoutedEventArgs e)
        {
            DTO.model.Sag sag = SagListBox.SelectedItem as DTO.model.Sag;
            if (sag == null)
            {
                MessageBox.Show("Du skal vælge en sag først");
                return;
            }
            var vindue = new OpdaterSagWindow(sag);

            vindue.ShowDialog();
            if (afdelingValgt != null)
            {
                UpdateSagerList();
            }

        }
    }
}
