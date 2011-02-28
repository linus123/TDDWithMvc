using Core.Domain;

namespace Core.Services
{
    public interface IOrderRepository
    {
        MembershipOffer[] GetAllActiveMembershipOffers();

        MembershipOffer GetMembershipOfferById(int id);

        int SaveMembershipOrder(MembershipOrder membershipOrder);
    }
}