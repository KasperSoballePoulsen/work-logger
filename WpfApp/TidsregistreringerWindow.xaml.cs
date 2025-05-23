﻿using BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using WpfApp.viewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TidsregistreringerWindow.xaml
    /// </summary>
    public partial class TidsregistreringerWindow : Window
    {
        private List<DTO.model.Tidsregistrering> alleTidsregistreringer;
        
        private ObservableCollection<TidsregistreringViewModel> tidsregistreringer;
        //private DTO.model.Medarbejder medarbejder;
        public TidsregistreringerWindow(DTO.model.Medarbejder medarbejder)
        {
            InitializeComponent();

            alleTidsregistreringer = TidsregistreringBLL.GetTidsregistreringer(medarbejder.Id);

            DataContext = medarbejder.Initialer;
            tidsregistreringer = new ObservableCollection<TidsregistreringViewModel>();
            TidsregistreringerListBox.ItemsSource = tidsregistreringer;

            SetUpComboBoxesAndCheckBox();

        }

        private void SetUpComboBoxesAndCheckBox()
        {
            VisAlleCheckBox.IsChecked = true;
            PeriodetypeComboBox.IsEnabled = false;
            AarComboBox.IsEnabled = false;
            PeriodeComboBox.IsEnabled = false;           
            PeriodetypeComboBox.ItemsSource = new List<string> { "Måned", "Uge" };
            PeriodetypeComboBox.SelectedIndex = 0;

            PeriodetypeComboBox.SelectionChanged += PeriodetypeComboBox_SelectionChanged;
            AarComboBox.SelectionChanged += AarChanged;
            PeriodeComboBox.SelectionChanged += ShowFilteredTidsregistreringer;

            var aar = alleTidsregistreringer
                .Select(r => r.StartTidspunkt.Year)
                .Distinct()
                .OrderBy(y => y)
                .ToList();

            AarComboBox.ItemsSource = aar;
        }

        private void AarChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AarComboBox.SelectedItem == null)
                return;

            int valgtÅr = (int)AarComboBox.SelectedItem;
            string periodetype = PeriodetypeComboBox.SelectedItem.ToString();

            var registreringerForÅr = alleTidsregistreringer.Where(r => r.StartTidspunkt.Year == valgtÅr);

            if (periodetype == "Måned")
            {
                var måneder = registreringerForÅr
                    .Select(r => r.StartTidspunkt.Month)
                    .Distinct()
                    .OrderBy(m => m)
                    .Select(m => System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m))
                    .ToList();

                PeriodeComboBox.ItemsSource = måneder;
            }
            else if (periodetype == "Uge")
            {
                var calendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;
                var uger = registreringerForÅr
                    .Select(r => calendar.GetWeekOfYear(r.StartTidspunkt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                    .Distinct()
                    .OrderBy(u => u)
                    .Select(u => $"Uge {u}")
                    .ToList();

                PeriodeComboBox.ItemsSource = uger;
            }
        }

        private void PeriodetypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tidsregistreringer.Clear();
            AarComboBox.SelectedItem = null;
            PeriodeComboBox.SelectedItem = null;
            PeriodeComboBox.ItemsSource = null;
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            PeriodetypeComboBox.IsEnabled = false;
            AarComboBox.IsEnabled = false;
            PeriodeComboBox.IsEnabled = false;

            PeriodetypeLabel.Foreground = Brushes.Gray;
            AarLabel.Foreground = Brushes.Gray;
            PeriodeLabel.Foreground = Brushes.Gray;

            PeriodetypeLabel.FontWeight = FontWeights.Normal;
            AarLabel.FontWeight = FontWeights.Normal;
            PeriodeLabel.FontWeight = FontWeights.Normal;
            PeriodetypeComboBox.Foreground = Brushes.Gray;

            tidsregistreringer.Clear();
            foreach (var tidsregistrering in alleTidsregistreringer)
            {
                string sagOverskrift = tidsregistrering.SagsId.HasValue ? SagBLL.GetSagOverskriftById(tidsregistrering.SagsId.Value) : "Ingen sag";

                tidsregistreringer.Add(new TidsregistreringViewModel
                {
                    StartTidspunkt = tidsregistrering.StartTidspunkt,
                    SlutTidspunkt = tidsregistrering.SlutTidspunkt,
                    SagOverskrift = sagOverskrift
                });
            }


        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tidsregistreringer.Clear();
            PeriodetypeComboBox.IsEnabled = true;
            AarComboBox.IsEnabled = true;
            PeriodeComboBox.IsEnabled = true;

            PeriodetypeLabel.Foreground = Brushes.Black;
            AarLabel.Foreground = Brushes.Black;
            PeriodeLabel.Foreground = Brushes.Black;
            PeriodetypeComboBox.Foreground = Brushes.Black;

            PeriodetypeLabel.FontWeight = FontWeights.SemiBold;
            AarLabel.FontWeight = FontWeights.SemiBold;
            PeriodeLabel.FontWeight = FontWeights.SemiBold;


            AarComboBox.SelectedItem = null;
            PeriodeComboBox.SelectedItem = null;
            PeriodeComboBox.ItemsSource = null;

        }

        private void ShowFilteredTidsregistreringer(object sender, SelectionChangedEventArgs e)
        {
            if (AarComboBox.SelectedItem == null || PeriodetypeComboBox.SelectedItem == null || PeriodeComboBox.SelectedItem == null)
            {
                return;
            }
            int valgtÅr = (int)AarComboBox.SelectedItem;
            string periodetype = PeriodetypeComboBox.SelectedItem.ToString();
            string valgtPeriode = PeriodeComboBox.SelectedItem.ToString();

            var registreringerForÅr = alleTidsregistreringer
                .Where(r => r.StartTidspunkt.Year == valgtÅr);

            IEnumerable<DTO.model.Tidsregistrering> filtreret = Enumerable.Empty<DTO.model.Tidsregistrering>();

            if (periodetype == "Måned")
            {
                int månedsnummer = DateTime.ParseExact(valgtPeriode, "MMMM", CultureInfo.CurrentCulture).Month;
                filtreret = registreringerForÅr.Where(r => r.StartTidspunkt.Month == månedsnummer);
            }
            else if (periodetype == "Uge")
            {
                int ugenummer = int.Parse(valgtPeriode.Replace("Uge ", ""));
                var kalender = CultureInfo.CurrentCulture.Calendar;
                filtreret = registreringerForÅr.Where(r =>
                    kalender.GetWeekOfYear(r.StartTidspunkt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) == ugenummer);
            }


            tidsregistreringer.Clear();
            foreach (var tidsregistrering in filtreret)
            {
                string sagOverskrift = tidsregistrering.SagsId.HasValue
                    ? SagBLL.GetSagOverskriftById(tidsregistrering.SagsId.Value) : "Ingen sag";

                tidsregistreringer.Add(new TidsregistreringViewModel
                {
                    StartTidspunkt = tidsregistrering.StartTidspunkt,
                    SlutTidspunkt = tidsregistrering.SlutTidspunkt,
                    SagOverskrift = sagOverskrift
                });
            }
        }

    }
}
