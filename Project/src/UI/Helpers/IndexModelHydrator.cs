using System.Web.Mvc;
using Core.Domain;
using DataAccess;
using UI.Helpers.Mappers;
using UI.Models;

namespace UI.Helpers
{
    public class IndexModelHydrator
    {
        public void HydrateIndexModel(
            IndexModel indexModel)
        {
            indexModel.MembershipOptions = GetMembershipOptionModels();
            indexModel.CreditCardTypes = GetCreditCardTypes();
        }

        private SelectListItem[] GetCreditCardTypes()
        {
            var creditCards = CreditCard.GetAll();

            var creditCardListItemMapper = new CreditCardListItemMapper();
            var listItems = creditCardListItemMapper.MapCreditCardsToListItems(creditCards);

            return listItems;
        }

        private MembershipOptionModel[] GetMembershipOptionModels()
        {
            var orderRepository = new OrderRepository();
            var allActiveMembershipOffers = orderRepository.GetAllActiveMembershipOffers();

            var indexModelMapper = new IndexModelMapper();
            return indexModelMapper.MapDomainToModels(allActiveMembershipOffers);
        }
    }
}