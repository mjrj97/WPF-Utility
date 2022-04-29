using Example.Models;
using WPFUtility.MVVM;

namespace Example.ViewModels
{
    public class PersonViewModel : ViewModel<Person>
    {
        public PersonViewModel(Person model) : base(model)
        {

        }
    }
}