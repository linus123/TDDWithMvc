using System;
using Core.Domain;
using Core.Services;

namespace UnitTests.UI
{
    public class OrderRepositoryFake : IOrderRepository
    {
        public bool SaveMembershipOrderWasCalled { get; set;}
        public MembershipOrder SaveMembershipOrderArgumentMembershipOrder { get; set; }

        public MembershipOffer[] GetAllActiveMembershipOffers()
        {
            var membershipOffer000 = new MembershipOffer();

            membershipOffer000.Id = 1;
            membershipOffer000.InternalName = "MEM53158813";
            membershipOffer000.ExternalName = "Highfaluting Membership 1 Year";
            membershipOffer000.DiscountPrice = 59;
            membershipOffer000.Price = 99;
            membershipOffer000.IsActive = true;
            membershipOffer000.TermInMonths = 12;
            membershipOffer000.TermInYears = 1;

            var membershipOffer001 = new MembershipOffer();

            membershipOffer001.Id = 2;
            membershipOffer001.InternalName = "MEM0876443";
            membershipOffer001.ExternalName = "Highfaluting Membership 2 Years";
            membershipOffer001.DiscountPrice = 159;
            membershipOffer001.Price = 198;
            membershipOffer001.IsActive = true;
            membershipOffer001.TermInMonths = 24;
            membershipOffer001.TermInYears = 2;

            var membershipOffer002 = new MembershipOffer();

            membershipOffer002.Id = 3;
            membershipOffer002.InternalName = "MEM6235499";
            membershipOffer002.ExternalName = "Highfaluting Membership 3 Years";
            membershipOffer002.DiscountPrice = 209;
            membershipOffer002.Price = 259;
            membershipOffer002.IsActive = true;
            membershipOffer002.TermInMonths = 36;
            membershipOffer002.TermInYears = 3;

            var membershipOffers = new MembershipOffer[3];

            membershipOffers[0] = membershipOffer000;
            membershipOffers[1] = membershipOffer001;
            membershipOffers[2] = membershipOffer002;

            return membershipOffers;
        }

        public MembershipOffer GetMembershipOfferById(int id)
        {
            if (id == 1)
            {
                var membershipOffer000 = new MembershipOffer();

                membershipOffer000.Id = 1;
                membershipOffer000.InternalName = "MEM53158813";
                membershipOffer000.ExternalName = "Highfaluting Membership 1 Year";
                membershipOffer000.DiscountPrice = 59;
                membershipOffer000.Price = 99;
                membershipOffer000.IsActive = true;
                membershipOffer000.TermInMonths = 12;
                membershipOffer000.TermInYears = 1;

                return membershipOffer000;
            }

            return null;
        }

        public int SaveMembershipOrder(
            MembershipOrder membershipOrder)
        {
            SaveMembershipOrderWasCalled = true;
            SaveMembershipOrderArgumentMembershipOrder = membershipOrder;

            return 10;
        }
    }
}