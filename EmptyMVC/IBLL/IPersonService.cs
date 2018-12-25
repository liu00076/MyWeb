using System.Collections.Generic;
using System.Linq;
using EmptyMVC.Models;

namespace EmptyMVC.IBLL
{
    public interface IPersonService
    {
        IQueryable<Person> GetPersons();
    }
}