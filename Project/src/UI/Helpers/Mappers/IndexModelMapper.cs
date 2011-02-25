using System.Collections.Generic;
using Core.Domain;
using UI.Models;

namespace UI.Helpers.Mappers
{
    public class IndexModelMapper
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
    }
}