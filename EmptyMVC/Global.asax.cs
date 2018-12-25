using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using EmptyMVC.Infrastructure;

namespace EmptyMVC
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //IHttpModule
            //IHttpHandler
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            #region Ninject

            //1. 通过 Controller 工厂实现 实现依赖注入
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //2. 通过mvc自带的依赖 IDependencyResolver 实现依赖注入 优先使用这个方法
            DependencyResolver.SetResolver(new NinjectDependencyResolver());//注册Ioc容器
            #endregion
            
        }
    }
}