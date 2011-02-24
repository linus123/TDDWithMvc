using System;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var indexModel = new IndexModel();

            indexModel.MembershipOptions = GetMembershipOptionModels();
            indexModel.CreditCardTypes = GetCreditCardTypes();

            return View(indexModel);
        }

        //[HttpPost]
        //public ViewResult Index(IndexModel indexModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        indexModel.MembershipOptions = GetMembershipOptionModels();
        //        indexModel.CreditCardTypes = GetCreditCardTypes();
        //        return View(indexModel);
        //    }

        //    return View(indexModel);
        //}

        private SelectListItem[] GetCreditCardTypes()
        {
            var selectListItems = new SelectListItem[3];

            selectListItems[0] = new SelectListItem() { Value = "", Text = "-- Select Item --", Selected = true };
            selectListItems[1] = new SelectListItem() { Value = "VISA", Text = "Visa" };
            selectListItems[2] = new SelectListItem() { Value = "AMEX", Text = "American Express" };

            return selectListItems;
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

        public ViewResult OrderSaved()
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