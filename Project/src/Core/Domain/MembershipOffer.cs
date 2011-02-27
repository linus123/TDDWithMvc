namespace Core.Domain
{
    public class MembershipOffer
    {
        public int Id { get; set; }
        public string InternalName { get; set; }
        public string ExternalName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsActive { get; set; }
        public int TermInMonths { get; set; }
        public int TermInYears { get; set; }
    }
}