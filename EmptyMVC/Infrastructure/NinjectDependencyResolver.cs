using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EmptyMVC.Abstract;
using EmptyMVC.BLL;
using EmptyMVC.Concrete;
using EmptyMVC.IBLL;
using Ninject;

namespace EmptyMVC.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IPersonService>().To<PersonService>();
            _kernel.Bind<IPersonRepository>().To<PersonRepository>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}