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
    /// Interaction logic for OpretSagWindow.xaml
    /// </summary>
    public partial class OpretSagWindow : Window
    {
        public OpretSagWindow()
        {
            InitializeComponent();
            LoadAfdelinger();
        }

        private void OpretSagAction(object sender, RoutedEventArgs e)
        {
            string overskrift = OverskriftTextBox.Text;
            string beskrivelse = BeskrivelseTextBox.Text;
            

            DTO.model.Afdeling valgtAfdeling = AfdelingerComboBox.SelectedItem as DTO.model.Afdeling;

            try
            {
                SagBLL.OpretSag(overskrift, beskrivelse, valgtAfdeling);
                MessageBox.Show("Sag oprettet!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl ved oprettelse: " + ex.Message);
            }
        }

        private void LoadAfdelinger()
        {
            List<DTO.model.Afdeling> afdelinger = AfdelingBLL.GetAfdelinger();
            AfdelingerComboBox.ItemsSource = afdelinger;
        }
    }
}
