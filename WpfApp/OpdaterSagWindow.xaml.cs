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
    /// Interaction logic for OpdaterSagWindow.xaml
    /// </summary>
    public partial class OpdaterSagWindow : Window
    {
        private DTO.model.Sag sag;
        public OpdaterSagWindow(DTO.model.Sag sag)
        {
            InitializeComponent();
            this.sag = sag;
            OverskriftTextBox.Text = sag.Overskrift;
            BeskrivelseTextBox.Text = sag.Beskrivelse;
        }

        private void GemOpdateringAction(object sender, RoutedEventArgs e)
        {
            string updatedOverskrift = OverskriftTextBox.Text.Trim();
            string updatedBeskrivelse = BeskrivelseTextBox.Text.Trim();
            try
            {
                SagBLL.OpdaterSag(updatedOverskrift, updatedBeskrivelse, sag.Id);


                MessageBox.Show("Sag opdateret!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl ved opdatering: " + ex.Message);
            }



            
        }
    }
}
