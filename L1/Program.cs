using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace L1
{
    internal class Program
    {
        // 3, 6 и 7 i don't know how do this
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (taskNumber)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;

                default: Console.WriteLine("Unknown task"); break;  
            }
        }

        private static void Task1()
        {
            // Инициализация
            int[] A = new int[5];
            float[][] B = new float[3][];

            for(int i=0;i<B.Length;i++)
            {
                B[i] = new float[4];
            }

            // Заполнение
            Console.WriteLine("Enter values for the array: ");
            for(int i = 0; i < A.Length; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }

            Random rnd = new Random();
            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < B[i].Length; j++)
                {
                    B[i][j] = rnd.NextSingle() * 100;
                }
            }

            // Вывод Массивов на экран
            Console.WriteLine("A: ");
            for(int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine("\n\nB: ");
            for(int i = 0; i < B.Length; i++)
            {
                for(int j = 0; j < B[i].Length; j++)
                {
                    Console.Write(B[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Все то, что нужно вывести
            float[] maxValues = new float[B.Length];
            float[] minValues = new float[B.Length];
            for (int i=0;i<B.Length; i++)
            {
                maxValues[i] = B[i].Max();
                minValues[i] = B[i].Min();
            }
            Console.Write("Max value: ");
            Console.WriteLine(A.Max() > maxValues.Max() ? A.Max() : maxValues.Max() + "\n");



            Console.Write("Min value: ");
            Console.WriteLine(A.Min() < minValues.Min() ? A.Min() : minValues.Min() + "\n");



            Console.Write("Sum of all values: ");
            float sumB = 0;
            for(int i=0;i<B.Length;i++)
            {
                sumB += B[i].Sum();
            }
            Console.WriteLine(A.Sum() + sumB + "\n");

            

            Console.Write("Product of all values: ");
            float result = 1;

            for(int i=0;i<A.Length;i++)
            {
                result *= A[i];
            }

            for(int i = 0; i < B.Length; i++)
            {
                for(int j = 0; j < B[i].Length; j++)
                {
                    result *= B[i][j];
                }
            }
            Console.WriteLine(result + "\n");



            Console.Write("Sum of even elements: ");
            int smA = 0;
            for(int i = 0; i < A.Length; i++)
            {
                if(i % 2 == 0)
                {
                    smA += A[i];
                }
            }
            Console.WriteLine(smA + "\n");



            Console.Write("Sum of odd columns: ");
            float smB = 0;
            for(int i = 0; i < B.Length; i++)
            {
                for(int j = 0; j < B[i].Length; j++)
                {
                    if(j % 2 != 0)
                    {
                        smB += B[i][j];
                    }
                }
            }
            Console.WriteLine(smB + "\n");

            Console.ReadKey();
        }

        private static void Task2()
        {
            //В условии не сказано, что делать, если минимальных или максимальных несколько, тогда какие брать

            // Инициализация и заполнение
            Random rnd = new Random();

            int[][] arr = new int[5][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[5];
                for(int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(-100, 101);
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Поиск min и max
            int mn = 101, mx = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if (mn > arr[i][j]) mn = arr[i][j];

                    else if (mx < arr[i][j]) mx = arr[i][j];

                }
            }

            Console.WriteLine("min: " + mn + " Max: " + mx + "\n");
            
            // Подсчет суммы
            int sm = 0;
            bool flag = false;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j=0;j< arr[i].Length; j++)
                {
                    if (flag) sm += arr[i][j];

                    if (arr[i][j] == mn || arr[i][j] == mx) flag = !flag;
                }
            }
            Console.WriteLine("Sum: " + sm);

            Console.ReadKey();
        }

        private static void Task3()
        {
            
        }

        private static void Task4()
        {

            int[,] arr1 = new int[5, 5];
            int[,] arr2 = new int[5, 5];

            // заполняем массивы
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr1[i, j] = rnd.Next(20);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr2[i, j] = rnd.Next(20);
                }
            }

            // выводим массивы на экран
            Console.WriteLine("First array:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(arr1[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nSecond array:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(arr2[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // умножение на число
            Console.WriteLine("\nMultiplying the first array by 2:");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write((arr1[i, j] * 2) + "\t");
                }
                Console.WriteLine();
            }

            // сложение матриц
            Console.WriteLine("\nSum of first and second array:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write((arr1[i, j] + arr2[i, j]) + "\t");

                }
                Console.WriteLine();
            }

            // умножение матриц
            Console.WriteLine("Product:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write((arr1[i, j] * arr2[i, j]) + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Task5()
        {
            Console.WriteLine("Enter an arithmetic expression: ");
            string str = Console.ReadLine();
            char operation = ' ';
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-')
                {
                    operation = str[i];
                    break;
                }
            }
            string[] numbers = str.Split(operation);
            
            Console.WriteLine(operation == '+' ? int.Parse(numbers[0]) + int.Parse(numbers[1]) : int.Parse(numbers[0]) - int.Parse(numbers[1]));

            Console.ReadKey();
        }

        private static void Task6()
        {
            
        }

        private static void Task7()
        {

        }
    }
}
