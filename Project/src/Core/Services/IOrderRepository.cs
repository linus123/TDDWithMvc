using Core.Domain;

namespace Core.Services
{
    public interface IOrderRepository
    {
        MembershipOffer[] GetAllActiveMembershipOffers();

        int SaveMembershipOrder(MembershipOrder membershipOrder);
    }
}