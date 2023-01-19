using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ExpertSystem.ComponentBuilders;
using ExpertSystem.Model;
using ExpertSystem.Service;

namespace ExpertSystem
{
    public partial class MainWindow : Window
    {
        private List<Smartphone>? _smartphones;
        private FileIOService? _fileIOService;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Smartphone();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService("Smartphones.json");
            try
            {
                _smartphones = _fileIOService.LoadDate();
            }
            catch (Exception)
            {
                Close();
            }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            AnimateFiltersPanel(0, 200);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            AnimateFiltersPanel(200, 0);
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputedData())
            {
                var displayedSmartphones = FilterSmartphones(_smartphones);
                DisplaySmartphones(displayedSmartphones);
            }
            else MessageBox.Show("Введены не верные данные");
        }

        private void AnimateFiltersPanel(int from, int to)
        {
            DoubleAnimation filtersPanelAnimation = new DoubleAnimation();
            filtersPanelAnimation.From = from;
            filtersPanelAnimation.To = to;
            filtersPanelAnimation.Duration = TimeSpan.FromSeconds(0.25);
            scrollViewer.BeginAnimation(ScrollViewer.WidthProperty, filtersPanelAnimation);
        }

        private void DisplaySmartphones(List<Smartphone> displayedSmartphones)
        {
            presentingPanel.Children.Clear();
            foreach (var smartphone in displayedSmartphones)
            {
                var sp = SmartphonePresenterBuilder.Build(smartphone);
                presentingPanel.Children.Add(sp);
            };
        }

        private List<Smartphone> FilterSmartphones(List<Smartphone> smartphones)
        {
            var n = new Smartphone();
            return smartphones
            .Where(s => FilterService.Filter(s.Name, searchBar)
            & FilterService.Filter(s.Price, tb_minPrice, tb_maxPrice)
            & FilterService.Filter(s.RAM, tb_minRAM, tb_maxRAM)
            & FilterService.Filter(s.Storage, tb_minStorage, tb_maxStorage)
            & FilterService.Filter(s.Size, tb_minSize, tb_maxSize)
            & FilterService.Filter(s.Network, lb_networks)
            & FilterService.Filter(s.OS, cb_OS)
            & FilterService.Filter(s.Resolution, cb_resolution)
            & FilterService.Filter(s.Company, cb_company)
            & FilterService.Filter(s.IsCamera, chk_camera))
            .ToList();
        }

        private bool ValidateInputedData()
        {
            TextBox[] validatedElements = {
                tb_maxPrice,
                tb_maxRAM,
                tb_maxSize,
                tb_maxStorage,
                tb_minPrice,
                tb_minRAM,
                tb_minSize,
                tb_minStorage
            };
            foreach (TextBox element in validatedElements)
            {
                if (Validation.GetHasError(element)) return false;
            }
            return true;
        }
    }
}
