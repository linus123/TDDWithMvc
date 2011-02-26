using DataAccess;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class OrderRepositoryTests
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
    }
}