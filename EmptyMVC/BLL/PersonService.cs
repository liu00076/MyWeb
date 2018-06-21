using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmptyMVC.Abstract;
using EmptyMVC.IBLL;
using EmptyMVC.Models;

namespace EmptyMVC.BLL
{
    public class PersonService:IPersonService
    {
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        private readonly IPersonRepository _repository;


        public IQueryable<Person> GetPersons()
        {
            return _repository.Persons;
        }
    }
}