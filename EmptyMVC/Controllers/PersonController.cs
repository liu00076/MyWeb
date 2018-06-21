using System.Linq;
using System.Web.Mvc;
using EmptyMVC.Abstract;
using EmptyMVC.IBLL;
using EmptyMVC.Models;

namespace EmptyMVC.Controllers
{
    public class PersonController : Controller
    {
        #region 使用Nject实现数据注入

        //private IPersonRepository repositoryByPerson;
        //public PersonController(IPersonRepository personRepository)
        //{
        //    repositoryByPerson = personRepository;
        //}

        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        #endregion


        public ActionResult Index()
        {
            //RouteCollection
            return View(_personService.GetPersons());
        }

    }
}
