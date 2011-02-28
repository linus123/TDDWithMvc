using System;

namespace Core.Domain
{
    public class MembershipOrderFactory
    {
        public MembershipOrder CreateMembershipOrder()
        {
            var membershipOrder = new MembershipOrder();

            membershipOrder.DateCreated = DateTime.Now;

            return membershipOrder;
        }
    }
}