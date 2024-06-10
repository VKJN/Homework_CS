using EmployeeComparer;
using MatrixComparer;
using CityComparer;
using CredCard;
namespace L6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (taskNumber)
            {
                case 1: SolveTask1(); break;
                case 2: SolveTask2(); break;    
                case 3: SolveTask3(); break;
                case 4: SolveTask4(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }        

        private static void SolveTask1()
        {
            Employee employee1 = new Employee("John", 50000);
            Employee employee2 = new Employee("Jane", 60000);
            Employee employee3 = new Employee("John", 50000);

            var employeeComparer = Employee.Comparer.Instance;

            Console.WriteLine($"employee1 equals employee2: {employeeComparer.Equals(employee1, employee2)}"); 
            Console.WriteLine($"employee1 equals employee3: {employeeComparer.Equals(employee1, employee3)}"); 
        }

        private static void SolveTask2()
        {
            Matrix matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1.0;
            matrix1[0, 1] = 2.0;
            matrix1[1, 0] = 3.0;
            matrix1[1, 1] = 4.0;

            Matrix matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 1.0;
            matrix2[0, 1] = 2.0;
            matrix2[1, 0] = 3.0;
            matrix2[1, 1] = 4.0;

            Matrix matrix3 = new Matrix(2, 2);
            matrix3[0, 0] = 5.0;
            matrix3[0, 1] = 6.0;
            matrix3[1, 0] = 7.0;
            matrix3[1, 1] = 8.0;

            var matrixComparer = Matrix.Comparer.Instance;

            Console.WriteLine($"matrix1 equals matrix2: {matrixComparer.Equals(matrix1, matrix2)}"); 
            Console.WriteLine($"matrix1 equals matrix3: {matrixComparer.Equals(matrix1, matrix3)}");
        }

        private static void SolveTask3()
        {
            City city1 = new City("New York", 8419000);
            City city2 = new City("Los Angeles", 3980000);
            City city3 = new City("New York", 8419000);

            var cityComparer = City.Comparer.Instance;

            Console.WriteLine($"city1 equals city2: {cityComparer.Equals(city1, city2)}");
            Console.WriteLine($"city1 equals city3: {cityComparer.Equals(city1, city3)}");
        }

        private static void SolveTask4()
        {
            CreditCard card1 = new CreditCard("1234567890123456", 1000);
            CreditCard card2 = new CreditCard("2345678901234567", 2000);
            CreditCard card3 = new CreditCard("1234567890123456", 1000);

            var cardComparer = CreditCard.Comparer.Instance;

            Console.WriteLine($"card1 equals card2: {cardComparer.Equals(card1, card2)}"); 
            Console.WriteLine($"card1 equals card3: {cardComparer.Equals(card1, card3)}");
        }
    }
}