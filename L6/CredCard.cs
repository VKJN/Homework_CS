namespace CredCard
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public int Balance { get; private set; }

        public CreditCard(string cardNumber, int balance)
        {
            CardNumber = cardNumber;
            Balance = balance;
        }

        public class Comparer : IEqualityComparer<CreditCard>
        {
            public static Comparer Instance { get; } = new Comparer();

            private Comparer() { }

            public bool Equals(CreditCard x, CreditCard y)
            {
                if (x == null || y == null)
                    return false;

                return x.CardNumber == y.CardNumber && x.Balance == y.Balance;
            }

            public int GetHashCode(CreditCard obj)
            {
                if (obj == null)
                    return 0;

                return HashCode.Combine(obj.CardNumber, obj.Balance);
            }
        }
    }
}