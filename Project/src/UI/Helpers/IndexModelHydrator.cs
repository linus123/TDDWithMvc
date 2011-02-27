using System.Web.Mvc;
using Core.Domain;
using Core.Services;
using DataAccess;
using UI.Helpers.Mappers;
using UI.Models;

namespace UI.Helpers
{
    public class IndexModelHydrator
    {
        private IOrderRepository _orderRepository;

        public IndexModelHydrator(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void HydrateIndexModel(
            IndexModel indexModel)
        {
            indexModel.MembershipOptions = GetMembershipOptionModels();
            indexModel.CreditCardTypes = GetCreditCardTypes();
        }

        private SelectListItem[] GetCreditCardTypes()
        {
            var creditCards = CreditCardType.GetAll();

            var creditCardListItemMapper = new CreditCardListItemMapper();
            var listItems = creditCardListItemMapper.MapCreditCardsToListItems(creditCards);

            return listItems;
        }

        private MembershipOptionModel[] GetMembershipOptionModels()
        {
            var allActiveMembershipOffers = _orderRepository.GetAllActiveMembershipOffers();

            var indexModelMapper = new IndexModelMapper();
            return indexModelMapper.MapDomainToModels(allActiveMembershipOffers);
        }
    }
}