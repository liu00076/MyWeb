using System;
using System.Web.Mvc;
using EmptyMVC.Abstract;

namespace EmptyMVC.Controllers
{
    public class HomeController : Controller
    {
        #region 使用Nject实现数据注入

        private IPersonRepository repositoryByPerson;
        public HomeController(IPersonRepository personRepository)
        {
            repositoryByPerson = personRepository;
        }

        #endregion

        [OutputCache(Duration = 5)]
        public ActionResult Index()
        {
            ViewBag.DateTime = DateTime.Now;
            return View(repositoryByPerson.Persons);
        }

        /// <summary>
        /// 使用rezar 模板
        /// </summary>
        /// <returns></returns>
        public ActionResult Razer()
        {
            ViewBag.myName = "<h3>刘道阳</h3>";
            return View();
        }

        /// <summary>
        /// 要请求的分布视图
        /// </summary>
        /// <returns></returns>
        public ActionResult PartView()
        {
            ViewBag.partName = "刘凯";
            return View();
        }

        /// <summary>
        /// 返回Json对象
        /// </summary>
        /// <returns></returns>
        public JsonResult JsView()
        {
            object obj = new object();
            //第一种方式返回 Json对象,默认 只接受 post方式 请求
            //return Json(obj,JsonRequestBehavior.AllowGet);

            //这种方式没有浏览器请求方式的区别
            return new JsonResult
            {
                Data = obj
            };
        }

    }
}
