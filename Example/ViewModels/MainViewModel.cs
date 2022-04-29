using Example.Models;
using System.Collections.ObjectModel;
using WPFUtility.Persistance;

namespace Example.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<PersonViewModel> People { get; set; }

        public PersonViewModel SelectedPerson { get; set; }

        public MainViewModel()
        {
            People = new();

            UpdateList();
        }

        public void UpdateList()
        {
            People.Clear();
            foreach (Person person in CSVRepository<Person>.Instance.RetrieveAll())
            {
                People.Add(new PersonViewModel(person));
            }
        }

        public void RemovePerson()
        {
            if (SelectedPerson != null)
            {
                CSVRepository<Person>.Instance.Delete(SelectedPerson.ID);
                UpdateList();
            }
        }
    }
}