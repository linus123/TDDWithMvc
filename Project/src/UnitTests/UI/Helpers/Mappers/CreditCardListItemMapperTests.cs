using System.Web.Mvc;
using Core.Domain;
using NUnit.Framework;
using UI.Helpers.Mappers;

namespace UnitTests.UI.Helpers.Mappers
{
    [TestFixture]
    public class CreditCardListItemMapperTests
    {
        [Test]
        public void MapCreditCardsToListItemsShouldReturnValidListOfTypes()
        {
            var creditCardListItemMapper = new CreditCardListItemMapper();

            var selectListItems = creditCardListItemMapper.MapCreditCardsToListItems(CreditCardType.GetAll());

            AsserThatModelHasCorrectCreditCardTypes(selectListItems);
        }

        private void AsserThatModelHasCorrectCreditCardTypes(
            SelectListItem[] selectListItems)
        {
            Assert.That(selectListItems.Length, Is.EqualTo(3));

            Assert.That(selectListItems[0].Value, Is.EqualTo(""));
            Assert.That(selectListItems[0].Text, Is.EqualTo("-- Select Item --"));
            Assert.That(selectListItems[0].Selected, Is.EqualTo(true));

            Assert.That(selectListItems[1].Value, Is.EqualTo("VISA"));
            Assert.That(selectListItems[1].Text, Is.EqualTo("Visa"));
            Assert.That(selectListItems[1].Selected, Is.EqualTo(false));

            Assert.That(selectListItems[2].Value, Is.EqualTo("AMEX"));
            Assert.That(selectListItems[2].Text, Is.EqualTo("American Express"));
            Assert.That(selectListItems[2].Selected, Is.EqualTo(false));
        }

    }
}