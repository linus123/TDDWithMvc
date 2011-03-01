using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess;
using UI.Controllers;
using UI.Helpers.Mappers;

namespace UI.Helpers
{
    public class ManualDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(HomeController))
            {
                var homeController = new HomeController(
                    new IndexModelRepository(
                        new OrderRepository(),
                        new IndexModelMapper(),
                        new CreditCardListItemMapper()));

                return homeController;
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
    }
}