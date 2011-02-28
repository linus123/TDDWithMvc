using System;
using System.Web.Mvc;
using Core.Domain;
using Core.Services;
using DataAccess;
using UI.Helpers;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private IndexModelHydrator _indexModelHydrator;
        private IOrderRepository _orderRepository;

        public HomeController()
        {
            _orderRepository = new OrderRepository();

            _indexModelHydrator = new IndexModelHydrator(
                _orderRepository);
        }

        public HomeController(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            _indexModelHydrator = new IndexModelHydrator(
                orderRepository);
        }

        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            _indexModelHydrator.HydrateIndexModel(indexModel);

            return View(indexModel);
        }

        [HttpPost]
        public ActionResult Index(
            IndexModel indexModel)
        {
            if (!ModelState.IsValid)
            {
                _indexModelHydrator.HydrateIndexModel(indexModel);

                return View(indexModel);
            }

            var membershipOrderFactory = new MembershipOrderFactory();

            var membershipOrder = membershipOrderFactory.CreateMembershipOrder();

            membershipOrder.FirstName = indexModel.FirstName;
            membershipOrder.LastName = indexModel.LastName;
            membershipOrder.EmailAddress = indexModel.EmailAddress;

            if (indexModel.DateOfBirth.HasValue)
                membershipOrder.DateOfBirth = (DateTime) indexModel.DateOfBirth;

            membershipOrder.CreditCardNumber = indexModel.CreditCardNumber;
            membershipOrder.CreditCardType = CreditCardType.FromCode(indexModel.SelectedCreditCardType);
            membershipOrder.MembershipOffer =
                _orderRepository.GetMembershipOfferById(Convert.ToInt32(indexModel.SelectedMembershipOption));

            _orderRepository.SaveMembershipOrder(membershipOrder);

            return RedirectToAction("OrderSaved");
        }

        public ViewResult OrderSaved()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}

/* 002
 * using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            indexModel.MembershipOptions = GetMembershipOptionModels();

            return View(indexModel);
        }

        private MembershipOptionModel[] GetMembershipOptionModels()
        {
            var membershipOptionModels1 = new MembershipOptionModel[3];

            membershipOptionModels1[0] = new MembershipOptionModel { Id = 0, Name = "Highfaluting Membership 1 Year - $99" };
            membershipOptionModels1[1] = new MembershipOptionModel { Id = 1, Name = "Highfaluting Membership 2 Years - $198" };
            membershipOptionModels1[2] = new MembershipOptionModel { Id = 2, Name = "Highfaluting Membership 3 Year - $259" };
            return membershipOptionModels1;
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
*/

/* 001
 * 
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            var membershipOptionModels1 = new MembershipOptionModel[3];

            membershipOptionModels1[0] = new MembershipOptionModel { Id = 0, Name = "Highfaluting Membership 1 Year - $99" };
            membershipOptionModels1[1] = new MembershipOptionModel { Id = 1, Name = "Highfaluting Membership 2 Years - $198" };
            membershipOptionModels1[2] = new MembershipOptionModel { Id = 2, Name = "Highfaluting Membership 3 Year - $259" };

            var membershipOptionModels = membershipOptionModels1;

            indexModel.MembershipOptions = membershipOptionModels;

            return View(indexModel);
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
 * 
*/