using System;
using Core.Domain;
using DataAccess;
using NUnit.Framework;
using WebMatrix.Data;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class OrderRepositoryTests : BaseDataTester
    {
        private OrderRepository _orderRepository;

        [SetUp]
        public void Init()
        {
            _orderRepository = new OrderRepository();
        }

        [Test]
        public void GetAllActiveMembershipOffersShouldGrabAllMemberships()
        {
            var allActiveMembershipOffers = _orderRepository.GetAllActiveMembershipOffers();

            Assert.That(allActiveMembershipOffers, Is.Not.Null);

            Assert.That(allActiveMembershipOffers[0].Id, Is.EqualTo(1));
            Assert.That(allActiveMembershipOffers[0].InternalName, Is.EqualTo("MEM53158813"));
            Assert.That(allActiveMembershipOffers[0].ExternalName, Is.EqualTo("Highfaluting Membership 1 Year"));
            Assert.That(allActiveMembershipOffers[0].DiscountPrice, Is.EqualTo(59));
            Assert.That(allActiveMembershipOffers[0].Price, Is.EqualTo(99));
            Assert.That(allActiveMembershipOffers[0].IsActive, Is.EqualTo(true));
            Assert.That(allActiveMembershipOffers[0].TermInMonths, Is.EqualTo(12));
            Assert.That(allActiveMembershipOffers[0].TermInYears, Is.EqualTo(1));

            Assert.That(allActiveMembershipOffers[1].Id, Is.EqualTo(2));
            Assert.That(allActiveMembershipOffers[1].InternalName, Is.EqualTo("MEM0876443"));
            Assert.That(allActiveMembershipOffers[1].ExternalName, Is.EqualTo("Highfaluting Membership 2 Years"));
            Assert.That(allActiveMembershipOffers[1].DiscountPrice, Is.EqualTo(159));
            Assert.That(allActiveMembershipOffers[1].Price, Is.EqualTo(198));
            Assert.That(allActiveMembershipOffers[1].IsActive, Is.EqualTo(true));
            Assert.That(allActiveMembershipOffers[1].TermInMonths, Is.EqualTo(36));
            Assert.That(allActiveMembershipOffers[1].TermInYears, Is.EqualTo(3));

            Assert.That(allActiveMembershipOffers[2].Id, Is.EqualTo(3));
            Assert.That(allActiveMembershipOffers[2].InternalName, Is.EqualTo("MEM6235499"));
            Assert.That(allActiveMembershipOffers[2].ExternalName, Is.EqualTo("Highfaluting Membership 3 Years"));
            Assert.That(allActiveMembershipOffers[2].DiscountPrice, Is.EqualTo(209));
            Assert.That(allActiveMembershipOffers[2].Price, Is.EqualTo(259));
            Assert.That(allActiveMembershipOffers[2].IsActive, Is.EqualTo(true));
            Assert.That(allActiveMembershipOffers[2].TermInMonths, Is.EqualTo(12));
            Assert.That(allActiveMembershipOffers[2].TermInYears, Is.EqualTo(1));
        }

        [Test]
        public void GetMembershipOfferByIdShouldReturnValidOffer()
        {
            var membershipOfferById = _orderRepository.GetMembershipOfferById(1);

            Assert.That(membershipOfferById.Id, Is.EqualTo(1));
            Assert.That(membershipOfferById.InternalName, Is.EqualTo("MEM53158813"));
            Assert.That(membershipOfferById.ExternalName, Is.EqualTo("Highfaluting Membership 1 Year"));
            Assert.That(membershipOfferById.DiscountPrice, Is.EqualTo(59));
            Assert.That(membershipOfferById.Price, Is.EqualTo(99));
            Assert.That(membershipOfferById.IsActive, Is.EqualTo(true));
            Assert.That(membershipOfferById.TermInMonths, Is.EqualTo(12));
            Assert.That(membershipOfferById.TermInYears, Is.EqualTo(1));
        }

        [Test]
        public void SaveMembershipOrderShouldPersistAnOrderAndReturnTheId()
        {
            var membershipOffer = new MembershipOffer();

            membershipOffer.Id = 1;

            var membershipOrder = new MembershipOrder();

            membershipOrder.FirstName = "firstname";
            membershipOrder.LastName = "lastname";
            membershipOrder.EmailAddress = "test@foo.com";
            membershipOrder.DateOfBirth = new DateTime(1980, 1, 1);
            membershipOrder.CreditCardNumber = "4444444444444";
            membershipOrder.CreditCardType = CreditCardType.Visa;
            membershipOrder.MembershipOffer = membershipOffer;
            membershipOrder.DateCreated = new DateTime(2000, 1, 1);

            var newOrderId = _orderRepository.SaveMembershipOrder(membershipOrder);

            Assert.That(newOrderId, Is.Not.EqualTo(0));
            Assert.That(newOrderId, Is.EqualTo(membershipOrder.OrderId));

            var database = Database.Open("IntegrationTests.Properties.Settings.TDDWithMVCConnectionString");

            var insertedOrder = database.QuerySingle("SELECT * FROM MembershipOrder WHERE Id = @0", newOrderId);

            Assert.AreEqual(insertedOrder.FirstName, "firstname");
            Assert.AreEqual(insertedOrder.LastName, "lastname");
            Assert.AreEqual(insertedOrder.EmailAddress, "test@foo.com");
            Assert.AreEqual(insertedOrder.DateOfBirth, new DateTime(1980, 1, 1));
            Assert.AreEqual(insertedOrder.CreditCardNumber, "4444444444444");
            Assert.AreEqual(insertedOrder.CreditCardTypeCode, CreditCardType.Visa.Code);
            Assert.AreEqual(insertedOrder.MembershipOfferId, membershipOffer.Id);
            Assert.AreEqual(insertedOrder.DateCreated, new DateTime(2000, 1, 1));
        }
    }
}