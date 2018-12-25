using System.Linq;
using EmptyMVC.Models;

namespace EmptyMVC.Abstract
{
    public interface IPersonRepository
    {
        IQueryable<Person> Persons { get; }
    }
}