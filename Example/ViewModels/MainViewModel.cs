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

        public void AddPerson(string Name, Sex Sex)
        {
            Person person = CSVRepository<Person>.Instance.Create(Name + ";" + (int)Sex);
            People.Add(new PersonViewModel(person));
        }

        public void EditPerson(string Name, Sex Sex)
        {
            SelectedPerson.Name = Name;
            SelectedPerson.Sex = Sex;
            CSVRepository<Person>.Instance.Update(SelectedPerson.ID);
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