using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private readonly List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "Argiris", LastName = "Papageorgiou" });
            people.Add(new PersonModel { Id = 2, FirstName = "Tom", LastName = "Waits" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel person = new PersonModel { Id = people.Max(x => x.Id) + 1, FirstName = firstName, LastName = lastName };
            people.Add(person);
            return person; //return person just to check on it's id
        }
    }
}
