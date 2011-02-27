using System;
using System.Collections.Generic;
using Core.Domain;
using Core.Services;
using WebMatrix.Data;

namespace DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        public MembershipOffer[] GetAllMembershipOffers()
        {
            return null;
        }

        public MembershipOffer[] GetAllActiveMembershipOffers()
        {
            var membershipOffers = new List<MembershipOffer>();

            var database000 = Database.Open("IntegrationTests.Properties.Settings.TDDWithMVCConnectionString");

            var membershipOfferDatas = database000.Query("SELECT * FROM MembershipOffer");

            foreach (var membershipOfferData in membershipOfferDatas)
            {
                var membershipOffer = new MembershipOffer();

                membershipOffer.Id = membershipOfferData.Id;
                membershipOffer.InternalName = membershipOfferData.InternalName;
                membershipOffer.ExternalName = membershipOfferData.ExternalName;
                membershipOffer.DiscountPrice = membershipOfferData.DiscountPrice;
                membershipOffer.Price = membershipOfferData.Price;
                membershipOffer.IsActive = membershipOfferData.IsActive;
                membershipOffer.TermInMonths = membershipOfferData.TermInMonths;
                membershipOffer.TermInYears = membershipOfferData.TermInYears;

                membershipOffers.Add(membershipOffer);
            }

            database000.Close();

            return membershipOffers.ToArray();
        }

        public MembershipOffer[] SerachMembershipOffers(string searchString)
        {
            return null;
        }
    }
}