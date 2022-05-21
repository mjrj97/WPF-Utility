using Example.Models;
using System.ComponentModel;
using System.Windows;

namespace Example.Views
{
    /// <summary>
    /// Interaction logic for PersonDialog.xaml
    /// </summary>
    public partial class PersonDialog : Window, INotifyPropertyChanged
    {
        private string _personName = string.Empty;
        public string PersonName 
        {
            get
            {
                return _personName;
            }
            set
            {
                _personName = value;
                NotifyPropertyChanged(nameof(PersonName));
            }
        }

        private Sex _personSex = Sex.Male;
        public Sex PersonSex
        {
            get
            {
                return _personSex;
            }
            set
            {
                _personSex = value;
                NotifyPropertyChanged(nameof(PersonSex));
            }
        }

        public PersonDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (PersonName.Trim() == string.Empty)
                MessageBox.Show("The name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Used to notify UI of changes in a property.
        /// </summary>
        /// <param name="propertyName">Name of the property changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}