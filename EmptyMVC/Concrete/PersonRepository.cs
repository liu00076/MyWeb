using System;
using System.Collections.Generic;
using System.Linq;
using EmptyMVC.Abstract;
using EmptyMVC.Models;

namespace EmptyMVC.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        public IQueryable<Person> Persons 
        {
            get { return GetPersons().AsQueryable(); }
        }

        private static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person> {
                new Person{ Name = "liu", Age = 25, LastLoginTime = DateTime.Now},
                new Person{ Name = "song", Age = 42, LastLoginTime = DateTime.Now},
                new Person{ Name = "hu", Age = 25, LastLoginTime = DateTime.Now}
            };
            return persons;
        }
    }
}