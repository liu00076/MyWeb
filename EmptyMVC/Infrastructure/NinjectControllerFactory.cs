using System;
using System.Web.Mvc;
using System.Web.Routing;
using EmptyMVC.Abstract;
using EmptyMVC.Concrete;
using Ninject;

namespace EmptyMVC.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        /// <summary>
        /// 实现control 的实例化
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        /// <summary>
        /// 实现control的ninject的绑定
        /// </summary>
        private void AddBindings()
        {
            ninjectKernel.Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}