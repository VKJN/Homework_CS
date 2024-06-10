namespace CityComparer
{
    public class City
    {
        public string Name { get; private set; }
        public int Population { get; private set; }

        public City(string name, int population)
        {
            Name = name;
            Population = population; 
        }

        public class Comparer : IEqualityComparer<City>
        {
            public static Comparer Instance { get; } = new Comparer();
            private Comparer() { }

            public bool Equals(City x, City y)
            {
                if (x == null || y == null)
                    return false;

                return x.Name == y.Name && x.Population == y.Population;
            }

            public int GetHashCode(City obj)
            {
                if (obj == null)
                    return 0;

                return HashCode.Combine(obj.Name, obj.Population);
            }
        }
    }
}