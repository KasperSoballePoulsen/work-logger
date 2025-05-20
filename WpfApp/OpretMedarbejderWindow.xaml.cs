using BLL;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for OpretMedarbejderWindow.xaml
    /// </summary>
    public partial class OpretMedarbejderWindow : Window
    {
        public OpretMedarbejderWindow()
        {
            InitializeComponent();
            LoadAfdelinger();

        }

        private void LoadAfdelinger()
        {
            List<DTO.model.Afdeling> afdelinger = AfdelingBLL.GetAfdelinger();
            AfdelingerComboBox.ItemsSource = afdelinger;
        }

        private void OpretMedarbejder(object sender, RoutedEventArgs e)
        {
            string initialer = InitialerTextBox.Text;
            string navn = NavnTextBox.Text;
            string cpr = CprTextBox.Text;

            DTO.model.Afdeling valgtAfdeling = AfdelingerComboBox.SelectedItem as DTO.model.Afdeling;

            try
            {
                MedarbejderBLL.OpretMedarbejder(initialer, navn, cpr, valgtAfdeling);
                MessageBox.Show("Medarbejder oprettet!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl ved oprettelse: " + ex.Message);
            }
        }
    }
}
