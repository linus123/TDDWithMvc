using System;
using NUnit.Framework;
using UI.Helpers.Mappers;
using UI.Models;

namespace UnitTests.UI.Helpers.Mappers
{
    [TestFixture]
    public class IndexModelMapperTests
    {
        private IndexModelMapper _indexModelMapper;
        private OrderRepositoryFake _orderRepositoryFake;

        [SetUp]
        public void Init()
        {
            _indexModelMapper = new IndexModelMapper();
            _orderRepositoryFake = new OrderRepositoryFake();
        }

        [Test]
        public void MapDomainToModelsShouldReturnValidListOfModels()
        {

            var allActiveMembershipOffers = _orderRepositoryFake.GetAllActiveMembershipOffers();

            var mapDomainToModels = _indexModelMapper.MapDomainToModels(
                allActiveMembershipOffers);

            AssertThatModelHasCorrectMemberships(mapDomainToModels);
        }

        [Test]
        public void GetMembershipOrderForIndexModelShouldReturnValidOrder()
        {
            var indexModel = new IndexModel();

            indexModel.FirstName = "firstname";
            indexModel.LastName = "lastname";
            indexModel.EmailAddress = "test@test.com";
            indexModel.DateOfBirth = new DateTime(2000, 1, 10);
            indexModel.CreditCardNumber = "9999999999";
            indexModel.SelectedCreditCardType = "VISA";
            indexModel.SelectedMembershipOption = 1;

            var membershipOrder = _indexModelMapper.GetMembershipOrderForIndexModel(
                indexModel,
                _orderRepositoryFake);

            Assert.That(indexModel.FirstName, Is.EqualTo(membershipOrder.FirstName));
            Assert.That(indexModel.LastName, Is.EqualTo(membershipOrder.LastName));
            Assert.That(indexModel.EmailAddress, Is.EqualTo(membershipOrder.EmailAddress));
            Assert.That(indexModel.DateOfBirth, Is.EqualTo(membershipOrder.DateOfBirth));
            Assert.That(indexModel.CreditCardNumber, Is.EqualTo(membershipOrder.CreditCardNumber));
            Assert.That(indexModel.SelectedCreditCardType, Is.EqualTo(membershipOrder.CreditCardType.Code));
            Assert.That(indexModel.SelectedMembershipOption, Is.EqualTo(membershipOrder.MembershipOffer.Id));
        }

        private void AssertThatModelHasCorrectMemberships(
            MembershipOptionModel[] membershipOptionModels)
        {
            Assert.That(membershipOptionModels, Is.Not.Null);

            Assert.That(membershipOptionModels[0].Id, Is.EqualTo(1));
            Assert.That(membershipOptionModels[0].Name, Is.EqualTo("Highfaluting Membership 1 Year - $99"));

            Assert.That(membershipOptionModels[1].Id, Is.EqualTo(2));
            Assert.That(membershipOptionModels[1].Name, Is.EqualTo("Highfaluting Membership 2 Years - $198"));

            Assert.That(membershipOptionModels[2].Id, Is.EqualTo(3));
            Assert.That(membershipOptionModels[2].Name, Is.EqualTo("Highfaluting Membership 3 Years - $259"));
        }
    }
}