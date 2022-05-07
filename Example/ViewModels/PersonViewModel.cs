using Example.Models;
using WPFUtility.MVVM;

namespace Example.ViewModels
{
    public class PersonViewModel : ViewModel<Person>
    {
        public string Name
        {
            get
            {
                return model.Name;
            }
            set
            {
                model.Name = value;
            }
        }

        public PersonViewModel(Person model) : base(model) { }
    }
}