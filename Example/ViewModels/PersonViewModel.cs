﻿using Example.Models;
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
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get
            {
                return model.Age;
            }
            set
            {
                model.Age = value;
                NotifyPropertyChanged(nameof(Age));
            }
        }

        public Sex Sex
        {
            get
            {
                return model.Sex;
            }
            set
            {
                model.Sex = value;
                NotifyPropertyChanged(nameof(Sex));
            }
        }

        public PersonViewModel(Person model) : base(model) { }
    }
}