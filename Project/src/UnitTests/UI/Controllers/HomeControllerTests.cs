using System.Web.Mvc;
using NUnit.Framework;
using UI.Controllers;
using UI.Models;

namespace UnitTests.UI.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void IndexShouldReturnTheMembershipOptions()
        {
            var viewResult = _homeController.Index();

            Assert.That(viewResult.ViewName, Is.EqualTo(""));
            Assert.That(viewResult.Model, Is.TypeOf(typeof(IndexModel)));

            var indexModel = (IndexModel)viewResult.Model;

            Assert.That(indexModel.MembershipOptions, Is.Not.Null);

            Assert.That(indexModel.MembershipOptions[0].Id, Is.EqualTo(0));
            Assert.That(indexModel.MembershipOptions[0].Name, Is.EqualTo("Highfaluting Membership 1 Year - $99"));

            Assert.That(indexModel.MembershipOptions[1].Id, Is.EqualTo(1));
            Assert.That(indexModel.MembershipOptions[1].Name, Is.EqualTo("Highfaluting Membership 2 Years - $198"));

            Assert.That(indexModel.MembershipOptions[2].Id, Is.EqualTo(2));
            Assert.That(indexModel.MembershipOptions[2].Name, Is.EqualTo("Highfaluting Membership 3 Year - $259"));
        }

        [Test]
        public void IndexShouldReturnCreditCardTypes()
        {
            var viewResult = _homeController.Index();

            var indexModel = (IndexModel)viewResult.Model;

            Assert.That(indexModel.MembershipOptions.Length, Is.EqualTo(3));

            Assert.That(indexModel.CreditCardTypes[0].Value, Is.EqualTo(""));
            Assert.That(indexModel.CreditCardTypes[0].Text, Is.EqualTo("-- Select Item --"));
            Assert.That(indexModel.CreditCardTypes[0].Selected, Is.EqualTo(true));

            Assert.That(indexModel.CreditCardTypes[1].Value, Is.EqualTo("VISA"));
            Assert.That(indexModel.CreditCardTypes[1].Text, Is.EqualTo("Visa"));
            Assert.That(indexModel.CreditCardTypes[1].Selected, Is.EqualTo(false));

            Assert.That(indexModel.CreditCardTypes[2].Value, Is.EqualTo("AMEX"));
            Assert.That(indexModel.CreditCardTypes[2].Text, Is.EqualTo("American Express"));
            Assert.That(indexModel.CreditCardTypes[2].Selected, Is.EqualTo(false));
        }

        [Test]
        public void IndexShouldRedirectToTheOrderSavedViewWhenModelIsValid()
        {
            var indexModel = new IndexModel();

            var actionResult = _homeController.Index(indexModel);

            Assert.That(actionResult, Is.TypeOf(typeof(RedirectToRouteResult)));

            var redirectResult = (RedirectToRouteResult)actionResult;

            Assert.That(redirectResult.RouteValues["action"],
                Is.EqualTo("OrderSaved"));
        }

        [Test]
        public void OrderSavedShouldReturnTheDefaultView()
        {
            var viewResult = _homeController.OrderSaved();

            Assert.That(viewResult.ViewName, Is.EqualTo(""));
        }
    }
}

/* 001
 * using System.Web.Mvc;
using NUnit.Framework;
using UI.Controllers;
using UI.Models;

namespace UnitTests.UI.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexShouldReturnTheMembershipOptions()
        {
            var homeController = new HomeController();

            var viewResult = homeController.Index();

            Assert.That(viewResult.ViewName, Is.EqualTo(""));
            Assert.That(viewResult.Model, Is.TypeOf(typeof(IndexModel)));

            var indexModel = (IndexModel)viewResult.Model;

            Assert.That(indexModel.MembershipOptions, Is.Not.Null);

            Assert.That(indexModel.MembershipOptions[0].Id, Is.EqualTo(0));
            Assert.That(indexModel.MembershipOptions[0].Name, Is.EqualTo("Highfaluting Membership 1 Year - $99"));

            Assert.That(indexModel.MembershipOptions[1].Id, Is.EqualTo(1));
            Assert.That(indexModel.MembershipOptions[1].Name, Is.EqualTo("Highfaluting Membership 2 Years - $198"));

            Assert.That(indexModel.MembershipOptions[2].Id, Is.EqualTo(2));
            Assert.That(indexModel.MembershipOptions[2].Name, Is.EqualTo("Highfaluting Membership 3 Year - $259"));
        }
    }
}
*/