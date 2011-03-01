using System.Web.Mvc;
using Core.Domain;
using Core.Services;
using UI.Helpers.Mappers;
using UI.Models;

namespace UI.Helpers
{
    public class IndexModelRepository
    {
        private IOrderRepository _orderRepository;
        private IndexModelMapper _indexModelMapper;

        public IndexModelRepository(
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

        public void SaveIndexModel(
            IndexModel indexModel)
        {
            _indexModelMapper = new IndexModelMapper();

            var membershipOrder = _indexModelMapper.GetIndexModelForOrder(indexModel, _orderRepository);

            _orderRepository.SaveMembershipOrder(membershipOrder);            
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