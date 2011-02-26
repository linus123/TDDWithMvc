namespace Core.Domain
{
    public class CreditCard
    {
        public static CreditCard Visa = new CreditCard("VISA", "Visa");
        public static CreditCard AmericanExpress = new CreditCard("AMEX", "American Express");

        private string _code;
        private string _name;

        private CreditCard(
            string code,
            string name)
        {
            _name = name;
            _code = code;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Code
        {
            get { return _code; }
        }
    }
}