using System;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using UI.Controllers;
using UI.Helpers;
using UI.Models;

namespace UnitTests.UI.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _homeController;
        private Mock<IIndexModelRepository> _mockIndexModelRepository;

        [SetUp]
        public void Setup()
        {
            _mockIndexModelRepository = new Mock<IIndexModelRepository>();

            _homeController = new HomeController(
                _mockIndexModelRepository.Object);
        }

        [Test]
        public void IndexShouldReturnTheMembershipOptions()
        {
            var viewResult = _homeController.Index();

            var model = (IndexModel)viewResult.Model;

            _mockIndexModelRepository.Verify(
                repos => repos.HydrateIndexModel(
                    model));
        }

        [Test]
        public void IndexShouldSaveTheOrderWhenTheModelIsValid()
        {
            var indexModel = new IndexModel();

            _homeController.Index(indexModel);

            _mockIndexModelRepository.Verify(
                repos => repos.SaveIndexModel(
                    indexModel));

        }

        [Test]
        public void IndexShouldRedirectToTheOrderSavedViewWhenModelIsValid()
        {
            var indexModel = new IndexModel();

            var actionResult = _homeController.Index(indexModel);

            var redirectResult = (RedirectToRouteResult)actionResult;

            Assert.That(redirectResult.RouteValues["action"],
                Is.EqualTo("OrderSaved"));
        }

        [Test]
        public void IndexShouldReturnTheSaveViewWhenModelIsInValid()
        {
            var indexModel = new IndexModel();

            SetModelStateOfContorllerAsInvalid();

            var actionResult = _homeController.Index(indexModel);

            _mockIndexModelRepository.Verify(
                repos => repos.HydrateIndexModel(
                    indexModel));

            Assert.That(actionResult, Is.TypeOf(typeof(ViewResult)));

            var viewResult = (ViewResult)actionResult;

            Assert.That(viewResult.ViewName, Is.EqualTo(""));
        }

        private void SetModelStateOfContorllerAsInvalid()
        {
            _homeController.ModelState.AddModelError(
                "firstError", "firstError");
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