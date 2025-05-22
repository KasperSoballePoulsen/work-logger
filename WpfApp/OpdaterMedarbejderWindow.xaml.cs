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
    /// Interaction logic for OpdaterMedarbejderWindow.xaml
    /// </summary>
    public partial class OpdaterMedarbejderWindow : Window
    {
        private DTO.model.Medarbejder medarbejder;
        public OpdaterMedarbejderWindow(DTO.model.Medarbejder medarbejder)
        {
            InitializeComponent();
            this.medarbejder = medarbejder;
            InitialerTextBox.Text = medarbejder.Initialer;
            NavnTextBox.Text = medarbejder.Navn;
            CprTextBox.Text = medarbejder.CPRNummer;
        }

        private void GemOpdateringAction(object sender, RoutedEventArgs e)
        {
            string updatedInitialer = InitialerTextBox.Text.Trim();
            string updatedNavn = NavnTextBox.Text.Trim();
            string updatedCprNr = CprTextBox.Text.Trim();
            
            try
            {
                MedarbejderBLL.OpdaterMedarbejder(updatedInitialer, updatedNavn, updatedCprNr, medarbejder.Id );


                MessageBox.Show("Medarbejder opdateret!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl ved opdatering: " + ex.Message);
            }
        }
    }
}
