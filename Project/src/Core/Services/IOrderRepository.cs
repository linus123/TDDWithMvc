using Core.Domain;

namespace Core.Services
{
    public interface IOrderRepository
    {
        MembershipOffer[] GetAllMembershipOffers();

        MembershipOffer[] GetAllActiveMembershipOffers();

        MembershipOffer[] SerachMembershipOffers(
            string searchString); 
    }
}