// -----------------------------------------------------------
// Copyrights (c) 2016 Seditio 🍂 INC. All rights reserved.
// -----------------------------------------------------------

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

using Launcher.Classes;

namespace Launcher.Windows
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private float _dataGridOpacity;

        private Visibility _dataGridVisibility;
        private Visibility _loadingVisibility;

        public MainWindow()
        {
            InitializeComponent();

            LoadingVisibility = Visibility.Visible;
            DataGridVisibility = Visibility.Collapsed;
        }

        public ObservableCollection<SelectableViewModel> Items { get; set; }

        public float DataGridOpacity
        {
            get { return _dataGridOpacity; }
            set
            {
                _dataGridOpacity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataGridOpacity"));
            }
        }

        public Visibility DataGridVisibility
        {
            get { return _dataGridVisibility; }
            set
            {
                _dataGridVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataGridVisibility"));
            }
        }

        public Visibility LoadingVisibility
        {
            get { return _loadingVisibility; }
            set
            {
                _loadingVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadingVisibility"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Items = new ObservableCollection<SelectableViewModel>();

            // Ugly binding hack
            Dispatcher.Invoke(() =>
            {
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = Items;
                DataGrid.Items.Refresh();
            });

            Dispatcher.Invoke(() =>
            {
                for(var i = 0; i < 10; i++)
                {
                    Items.Add(new SelectableViewModel {Host = "RXT6 Dedicated Server", Map = "mp_cunts", Ping = "69"});
                }
            });

            await Task.Delay(1500);
            Fader();
        }

        private async void Fader()
        {
            DataGridVisibility = Visibility.Visible;
            LoadingVisibility = Visibility.Collapsed;

            var i = 0;
            do
            {
                DataGridOpacity = DataGridOpacity + .1F;
                i++;
                await Task.Delay(20);
            }
            while(i != 100);
        }
    }
}