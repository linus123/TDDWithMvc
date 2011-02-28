using System.Reflection;
using Core.Domain;
using NUnit.Framework;

namespace UnitTests.Core.Domain
{
    [TestFixture]
    public class CreditCardTypeTests
    {
        [Test]
        public void GetAllShouldReturnTheCorrectNumberOfItems()
        {
            var targetTypes = typeof(CreditCardType).GetFields(BindingFlags.Static | BindingFlags.Public);

            var all = CreditCardType.GetAll();

            Assert.That(all.Length, Is.EqualTo(targetTypes.Length));
        }

        [Test]
        public void FromCodeShouldReturnTheTargetValue()
        {
            var creditCardType = CreditCardType.FromCode("VISA");

            Assert.That(creditCardType, Is.EqualTo(CreditCardType.Visa));
        }
    }
}