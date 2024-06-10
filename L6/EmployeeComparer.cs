namespace EmployeeComparer
{
    public class Employee
    {
        public string Name { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public class Comparer : IEqualityComparer<Employee>
        {
            public static Comparer Instance { get; } = new Comparer();

            private Comparer() { }

            public bool Equals(Employee x, Employee y)
            {
                if (x == null || y == null)
                    return false;

                return x.Name == y.Name && x.Salary == y.Salary;
            }

            public int GetHashCode(Employee obj)
            {
                if (obj == null)
                    return 0;

                return HashCode.Combine(obj.Name, obj.Salary);
            }
        }
    }
}