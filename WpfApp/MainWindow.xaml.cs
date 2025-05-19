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
        private Dictionary<DTO.model.Medarbejder, string> medarbejderMap;
        private ObservableCollection<string> visningsTekster;
        public MainWindow()
        {
            InitializeComponent();

            medarbejderMap = MedarbejderBLL.GetMedarbejderVisningsMap();
            visningsTekster = new ObservableCollection<string>(medarbejderMap.Values);

            //ObservableCollection<KeyValuePair<DTO.model.Medarbejder, string>> medarbejdere = new ObservableCollection<KeyValuePair<DTO.model.Medarbejder, string>>();

            //ObservableCollection<DTO.model.Medarbejder> medarbejdere = new ObservableCollection<DTO.model.Medarbejder>(MedarbejderBLL.GetMedarbejdere());

            MedarbejderListBox.ItemsSource = visningsTekster;
        }

        

        
    }
}
