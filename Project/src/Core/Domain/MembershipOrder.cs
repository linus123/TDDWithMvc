using System;

namespace Core.Domain
{
    public class MembershipOrder
    {
        public MembershipOrder()
        {
        }

        public int OrderId { get; set; }
        public MembershipOffer MembershipOffer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CreditCardNumber { get; set; }
        public CreditCardType CreditCardType { get; set; }

        public DateTime DateCreated { get; set; }
    }
}