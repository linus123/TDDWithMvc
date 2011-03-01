using System;
using Core.Domain;
using NUnit.Framework;

namespace UnitTests.Core.Domain
{
    [TestFixture]
    public class MembershipOrderFactoryTests
    {
        [Test]
        public void CreateMembershipOrderShouldSetTheDateCreatedDate()
        {
            var membershipOrderFactory = new MembershipOrderFactory();

            var membershipOrder = membershipOrderFactory.CreateMembershipOrder();

            Assert.That(membershipOrder.DateCreated, Is.GreaterThanOrEqualTo(DateTime.Now));
        }
    }
}