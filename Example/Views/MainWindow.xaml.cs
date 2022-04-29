using Example.ViewModels;
using System.Windows;

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MVM;

        public MainWindow()
        {
            MVM = new();
            InitializeComponent();
            DataContext = MVM;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MVM.RemovePerson();
        }
    }
}