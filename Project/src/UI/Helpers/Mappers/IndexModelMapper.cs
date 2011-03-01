using System;
using System.Collections.Generic;
using Core.Domain;
using Core.Services;
using UI.Models;

namespace UI.Helpers.Mappers
{
    public interface IIndexModelMapper
    {
        MembershipOptionModel[] MapDomainToModels(
            MembershipOffer[] membershipOffers);

        MembershipOrder GetMembershipOrderForIndexModel(
            IndexModel indexModel,
            IOrderRepository orderRepository);
    }

    public class IndexModelMapper : IIndexModelMapper
    {
        public MembershipOptionModel[] MapDomainToModels(
            MembershipOffer[] membershipOffers)
        {
            var membershipOptionModels = new List<MembershipOptionModel>();

            foreach (var allActiveMembershipOffer in membershipOffers)
            {
                var membershipOptionModel = new MembershipOptionModel
                {
                    Id = allActiveMembershipOffer.Id,
                    Name = (allActiveMembershipOffer.ExternalName + " - " + allActiveMembershipOffer.Price.ToString("$###,###,##0"))
                };

                membershipOptionModels.Add(membershipOptionModel);
            }

            return membershipOptionModels.ToArray();
        }

        public MembershipOrder GetMembershipOrderForIndexModel(
            IndexModel indexModel,
            IOrderRepository orderRepository)
        {
            var membershipOrderFactory = new MembershipOrderFactory();

            var membershipOrder = membershipOrderFactory.CreateMembershipOrder();

            membershipOrder.FirstName = indexModel.FirstName;
            membershipOrder.LastName = indexModel.LastName;
            membershipOrder.EmailAddress = indexModel.EmailAddress;

            if (indexModel.DateOfBirth.HasValue)
                membershipOrder.DateOfBirth = (DateTime)indexModel.DateOfBirth;

            membershipOrder.CreditCardNumber = indexModel.CreditCardNumber;
            membershipOrder.CreditCardType = CreditCardType.FromCode(indexModel.SelectedCreditCardType);
            membershipOrder.MembershipOffer =
                orderRepository.GetMembershipOfferById(indexModel.SelectedMembershipOption);

            return membershipOrder;
        }

    }
}