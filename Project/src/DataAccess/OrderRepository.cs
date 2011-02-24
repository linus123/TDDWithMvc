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

            membershipOffer000.Id = 2023;
            membershipOffer000.InternalName = "MEM53158813";
            membershipOffer000.ExternalName = "Standard Membership 1 Year";
            membershipOffer000.DiscountPrice = 59;
            membershipOffer000.Price = 99;
            membershipOffer000.IsActive = true;
            membershipOffer000.TermInMonths = 12;
            membershipOffer000.TermInYears = 1;

            var membershipOffer001 = new MembershipOffer();

            membershipOffer001.Id = 2589;
            membershipOffer001.InternalName = "MEM0876443";
            membershipOffer001.ExternalName = "Standard Membership 3 Years";
            membershipOffer001.DiscountPrice = 209;
            membershipOffer001.Price = 259;
            membershipOffer001.IsActive = true;
            membershipOffer001.TermInMonths = 36;
            membershipOffer001.TermInYears = 3;

            var membershipOffer002 = new MembershipOffer();

            membershipOffer002.Id = 3502;
            membershipOffer002.InternalName = "MEM6235499";
            membershipOffer002.ExternalName = "Gold Membership 1 Year";
            membershipOffer002.DiscountPrice = 209;
            membershipOffer002.Price = 259;
            membershipOffer002.IsActive = true;
            membershipOffer002.TermInMonths = 12;
            membershipOffer002.TermInYears = 1;

            var membershipOffer003 = new MembershipOffer();

            membershipOffer003.Id = 3502;
            membershipOffer003.InternalName = "MEM6235499";
            membershipOffer003.ExternalName = "Gold Membership 3 Year";
            membershipOffer003.DiscountPrice = 900;
            membershipOffer003.Price = 989;
            membershipOffer003.IsActive = true;
            membershipOffer003.TermInMonths = 36;
            membershipOffer003.TermInYears = 3;

            var membershipOffers = new MembershipOffer[4];

            membershipOffers[0] = membershipOffer000;
            membershipOffers[1] = membershipOffer001;
            membershipOffers[2] = membershipOffer002;
            membershipOffers[3] = membershipOffer003;

            return membershipOffers;
        }

        public MembershipOffer[] SerachMembershipOffers(string searchString)
        {
            return null;
        }
    }
}