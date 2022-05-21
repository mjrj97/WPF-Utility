using Example.ViewModels;
using System.Windows;

namespace Example.Views
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
            PersonDialog dialog = new();

            if (dialog.ShowDialog() == true)
            {
                MVM.AddPerson(dialog.PersonName, dialog.PersonSex);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            PersonDialog dialog = new();
            dialog.PersonName = MVM.SelectedPerson.Name;
            dialog.PersonSex = MVM.SelectedPerson.Sex;

            if (dialog.ShowDialog() == true)
            {
                MVM.EditPerson(dialog.PersonName, dialog.PersonSex);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MVM.RemovePerson();
        }
    }
}