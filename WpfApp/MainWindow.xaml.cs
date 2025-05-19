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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();

            List<DTO.model.Medarbejder> medarbejdereDTO = MedarbejderBLL.GetMedarbejdere();

            ObservableCollection<DTO.model.Medarbejder> medarbejdere = new ObservableCollection<DTO.model.Medarbejder>(medarbejdereDTO);
                 
            MedarbejderListBox.ItemsSource = medarbejdere;
            MedarbejderListBox.DisplayMemberPath = "Initialer";

        }

        private void OpretMedarbejderAction(object sender, RoutedEventArgs e)
        {

        }
    }
}
