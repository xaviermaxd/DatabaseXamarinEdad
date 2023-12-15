using pruebaDatabase.Models;
using pruebaDatabase.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pruebaDatabase.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private string firstName;
        public string FirstName
        {
            get { return this.firstName; }
            set { SetValue(ref this.firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }

        private int edad;
        public int Edad
        {
            get { return this.edad; }
            set { SetValue(ref this.edad, value); }
        }

        private int sumaEdad;
        public int SumaEdad
        {
            get { return this.sumaEdad; }
            set { SetValue(ref this.sumaEdad, value); }
        }

        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }

        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { SetValue(ref this.people, value); }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand Sumar { get; set; }

        public PeopleViewModel()
        {
            SearchCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                People = service.GetByText(Filter);
            });

            InsertCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                int newPersonId = service.Get().Count + 1;
                service.Create(new Person { FirstName = FirstName, LastName = LastName, Edad = Edad });

                App.Current.MainPage.DisplayAlert("Success", "Your data are saved", "Ok");
            });

            Sumar = new Command(() =>
            {
                PersonService service = new PersonService();
                SumaEdad = service.GetSuma();
            });

        }

    }
}
