using System;
using Core.Domain;
using Core.Services;

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
            var membershipOffer000 = new MembershipOffer();

            membershipOffer000.Id = 0;
            membershipOffer000.InternalName = "MEM53158813";
            membershipOffer000.ExternalName = "Highfaluting Membership 1 Year";
            membershipOffer000.DiscountPrice = 59;
            membershipOffer000.Price = 99;
            membershipOffer000.IsActive = true;
            membershipOffer000.TermInMonths = 12;
            membershipOffer000.TermInYears = 1;

            var membershipOffer001 = new MembershipOffer();

            membershipOffer001.Id = 1;
            membershipOffer001.InternalName = "MEM0876443";
            membershipOffer001.ExternalName = "Highfaluting Membership 2 Years";
            membershipOffer001.DiscountPrice = 159;
            membershipOffer001.Price = 198;
            membershipOffer001.IsActive = true;
            membershipOffer001.TermInMonths = 36;
            membershipOffer001.TermInYears = 3;

            var membershipOffer002 = new MembershipOffer();

            membershipOffer002.Id = 2;
            membershipOffer002.InternalName = "MEM6235499";
            membershipOffer002.ExternalName = "Highfaluting Membership 3 Years";
            membershipOffer002.DiscountPrice = 209;
            membershipOffer002.Price = 259;
            membershipOffer002.IsActive = true;
            membershipOffer002.TermInMonths = 12;
            membershipOffer002.TermInYears = 1;

            var membershipOffers = new MembershipOffer[3];

            membershipOffers[0] = membershipOffer000;
            membershipOffers[1] = membershipOffer001;
            membershipOffers[2] = membershipOffer002;

            return membershipOffers;
        }

        public MembershipOffer[] SerachMembershipOffers(string searchString)
        {
            return null;
        }
    }
}