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
        public SagOversigt()
        {
            InitializeComponent();

            afdelinger = AfdelingBLL.GetAfdelinger();

            AfdelingComboBox.ItemsSource = afdelinger;

            AfdelingComboBox.SelectionChanged += AdelingComboBoxChanged;
        }

        private void AdelingComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            DTO.model.Afdeling afdelingValgt = AfdelingComboBox.SelectedItem as DTO.model.Afdeling;
            List<DTO.model.Sag> sager = SagBLL.GetSagerByAfdelingId(afdelingValgt.Id);

            SagListBox.ItemsSource = sager;
        }
    }
}
