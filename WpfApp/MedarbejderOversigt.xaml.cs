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
    /// Interaction logic for MedarbejderOversigt.xaml
    /// </summary>
    public partial class MedarbejderOversigt : UserControl
    {
        private ObservableCollection<DTO.model.Medarbejder> medarbejdere;

        public MedarbejderOversigt()
        {
            InitializeComponent();

            List<DTO.model.Medarbejder> medarbejdereDTO = MedarbejderBLL.GetMedarbejdere();

            medarbejdere = new ObservableCollection<DTO.model.Medarbejder>(medarbejdereDTO);

            MedarbejderListBox.ItemsSource = medarbejdere;
            MedarbejderListBox.DisplayMemberPath = "Initialer";

        }

        private void OpretMedarbejderAction(object sender, RoutedEventArgs e)
        {
            var vindue = new OpretMedarbejderWindow();

            vindue.ShowDialog();

            List<DTO.model.Medarbejder> updatedMedarbejderList = MedarbejderBLL.GetMedarbejdere();
            medarbejdere.Clear();
            foreach (DTO.model.Medarbejder medarbejder in updatedMedarbejderList)
            {
                medarbejdere.Add(medarbejder);
            }
        }

        private void TidsregistreringerAction(object sender, RoutedEventArgs e)
        {
            DTO.model.Medarbejder valgteMedarbejder = MedarbejderListBox.SelectedItem as DTO.model.Medarbejder;

            if (valgteMedarbejder == null)
            {
                MessageBox.Show("Vælg en medarbejder først.");
                return;
            }

            var vindue = new TidsregistreringerWindow(valgteMedarbejder);
            vindue.ShowDialog();
        }
    }
}
