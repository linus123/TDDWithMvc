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
        private CreditCardListItemMapper _creditCardListItemMapper;

        public IndexModelRepository(
            IOrderRepository orderRepository,
            IndexModelMapper indexModelMapper,
            CreditCardListItemMapper creditCardListItemMapper)
        {
            _creditCardListItemMapper = creditCardListItemMapper;
            _indexModelMapper = indexModelMapper;

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
            var membershipOrder = _indexModelMapper.GetIndexModelForOrder(indexModel, _orderRepository);

            _orderRepository.SaveMembershipOrder(membershipOrder);            
        }

        private SelectListItem[] GetCreditCardTypes()
        {
            var creditCards = CreditCardType.GetAll();

            var listItems = _creditCardListItemMapper.MapCreditCardsToListItems(creditCards);

            return listItems;
        }

        private MembershipOptionModel[] GetMembershipOptionModels()
        {
            var allActiveMembershipOffers = _orderRepository.GetAllActiveMembershipOffers();

            return _indexModelMapper.MapDomainToModels(allActiveMembershipOffers);
        }
    }
}