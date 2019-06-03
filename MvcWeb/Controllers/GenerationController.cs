using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;

namespace MvcWeb.Controllers
{
    public class GenerationController : Controller
    {
        //
        // GET: /Generation/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateHtml()
        {
            ViewBag.Title = "输出的HTML页面";//这个变量在模板页中有声明的话就会传入模板页最终替换模板页面的变量（和mvc的razor一样用）
            ViewBag.my = "动态生成,。。。。。";
            string outHtml = RazorHtml.OutHtml(this.ControllerContext, "Title", this.ViewData, this.TempData);
            ViewBag.HtmlContent = outHtml;
            RazorHtml.SaveHtml(this.ControllerContext, "Title", this.ViewData, this.TempData, "/StaticHtml/Loui.html", "Loui.html", "html", Encoding.UTF8);//生成的HTML
            return View();
        }
         


    }
}
