namespace Core.Domain
{
    public class CreditCardType
    {
        public static CreditCardType Visa = new CreditCardType("VISA", "Visa");
        public static CreditCardType AmericanExpress = new CreditCardType("AMEX", "American Express");

        private string _code;
        private string _name;

        private CreditCardType(
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

        public static CreditCardType[] GetAll()
        {
            return new []
            {
                Visa,
                AmericanExpress
            };
        }
    }
}