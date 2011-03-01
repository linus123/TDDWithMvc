using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Core.Services;
using DataAccess;
using Microsoft.Practices.Unity;
using UI.Helpers.Mappers;

namespace UI.Helpers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private UnityContainer _unityContainer;

        public UnityDependencyResolver()
        {
            _unityContainer = new UnityContainer();
        }

        public void SetupDependencies()
        {
            _unityContainer.RegisterType<IOrderRepository, OrderRepository>();
            _unityContainer.RegisterType<OrderRepository>();
            _unityContainer.RegisterType<IndexModelMapper>();
            _unityContainer.RegisterType<CreditCardListItemMapper>();
            _unityContainer.RegisterType<IndexModelRepository>();
        }

        public object GetService(Type serviceType)
        {
            object service;

            try
            {
                service = _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                service = null;
            }

            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> resolveAll;
            try
            {
                resolveAll = _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                resolveAll = new List<object>();
            }

            return resolveAll;
        }
    }
}