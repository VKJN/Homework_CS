


using System.Net;
using System;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;

namespace L2
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
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break; 

                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void Task1()
        {
            Console.WriteLine("Enter the side length of the square: ");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the symbol: ");
            char symbol = char.Parse(Console.ReadLine());

            Console.WriteLine();

            drawSquare(length, symbol);
        }

        private static void drawSquare(int length, char symbol)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(char.ToString(symbol) + ' ');
                }
                Console.WriteLine();
            }
        }



        private static void Task2()
        {
            Console.WriteLine("Enter the value: ");
            Console.WriteLine(PalindromeOrNot(Console.ReadLine()));
        }

        private static bool PalindromeOrNot(string value)
        {
            return value.SequenceEqual(value.Reverse());
        }



        private static void Task3()
        {
            int[] arr = {1, 2, 6, -1, 88, 7, 6};
            int[] arr2 = {6, 88, 7};
            arr = Filtration(arr, arr2);
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        private static int[] Filtration(int[] arr, int[] arr2)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr[i] == arr2[j])
                    {
                        count++;
                        arr[i] = 0;
                        break;
                    }
                }
            }

            int[] newArr = new int[arr.Length - count];
            count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0) newArr[count++] = arr[i];
            }

            return newArr;
        }



        private static void Task4()
        {
            Website website = new Website();
            website.EnterData();
            Console.WriteLine();
            website.DisplayData();
        }

        class Website
        {
            private string name;
            private string url;
            private string description;
            private string ipAddress;

            public void SetName(string name)
            {
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }

            public void SetUrl(string url)
            {
                this.url = url;
            }

            public string GetUrl()
            {
                return url;
            }

            public void SetDescription(string description)
            {
                this.description = description;
            }

            public string GetDescription()
            {
                return description;
            }

            public void SetIpAddress(string ipAddress)
            {
                this.ipAddress = ipAddress;
            }

            public string GetIpAddress()
            {
                return ipAddress;
            }

            public void EnterData()
            {
                Console.Write("Введите название сайта: ");
                name = Console.ReadLine();

                Console.Write("Введите путь к сайту: ");
                url = Console.ReadLine();

                Console.Write("Введите описание сайта: ");
                description = Console.ReadLine();

                Console.Write("Введите IP-адрес сайта: ");
                ipAddress = Console.ReadLine();
            }

            public void DisplayData()
            {
                Console.WriteLine("Название сайта: " + name);
                Console.WriteLine("Путь к сайту: " + url);
                Console.WriteLine("Описание сайта: " + description);
                Console.WriteLine("IP-адрес сайта: " + ipAddress);
            }
        }



        private static void Task5()
        {
            Journal journal = new Journal();
            journal.EnterData();
            Console.WriteLine();
            journal.DisplayData();
        }

        class Journal 
        {
            private string name;
            private string yearOfFoundation;
            private string description;
            private string phoneNumber;
            private string email;

            public void SetName(string name)
            {
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }

            public void SetYearOfFoundation(string yearOfFoundation)
            {
                this.yearOfFoundation = yearOfFoundation;
            }

            public string GetYearOfFoundationl()
            {
                return yearOfFoundation;
            }

            public void SetDescription(string description)
            {
                this.description = description;
            }

            public string GetDescription()
            {
                return description;
            }

            public void SetPhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
            }

            public string GetPhoneNumber()
            {
                return phoneNumber;
            }

            public void setEmail(string email)
            {
                this.email = email;
            }

            public string getEmail()
            {
                return email;
            }

            public void EnterData()
            {
                Console.Write("Введите название журнала: ");
                name = Console.ReadLine();

                Console.Write("Введите год основания: ");
                yearOfFoundation = Console.ReadLine();

                Console.Write("Введите контактый телефон: ");
                phoneNumber = Console.ReadLine();

                Console.WriteLine("Введите описание журнала: ");
                description = Console.ReadLine();

                Console.Write("Введите контактный e-mail: ");
                email = Console.ReadLine();
            }

            public void DisplayData()
            {
                Console.WriteLine("Название журнала: " + name);
                Console.WriteLine("Год основания: " + yearOfFoundation);
                Console.WriteLine("Описание журнала: " + description);
                Console.WriteLine("Контактный телефон: " + phoneNumber);
                Console.WriteLine("Контактный e-mail: " + email);
            }
        }



        private static void Task6()
        {
            Shop shop = new Shop();
            shop.EnterData();
            Console.WriteLine();
            shop.DisplayData();
        }

        class Shop
        {
            private string name;
            private string address;
            private string description;
            private string phoneNumber;
            private string email;

            public void SetName(string name)
            {
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }

            public void SetAddress(string address)
            {
                this.address = address;
            }

            public string GetAddress()
            {
                return address;
            }

            public void SetDescription(string description)
            {
                this.description = description;
            }

            public string GetDescription()
            {
                return description;
            }

            public void SetPhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
            }

            public string GetPhoneNumber()
            {
                return phoneNumber;
            }

            public void setEmail(string email)
            {
                this.email = email;
            }

            public string getEmail()
            {
                return email;
            }

            public void EnterData()
            {
                Console.Write("Введите название магазина: ");
                name = Console.ReadLine();

                Console.Write("Введите адрес: ");
                address = Console.ReadLine();

                Console.Write("Введите контактый телефон: ");
                phoneNumber = Console.ReadLine();

                Console.WriteLine("Введите описание магазина: ");
                description = Console.ReadLine();

                Console.Write("Введите контактный e-mail: ");
                email = Console.ReadLine();
            }

            public void DisplayData()
            {
                Console.WriteLine("Название журнала: " + name);
                Console.WriteLine("Год основания: " + address);
                Console.WriteLine("Описание журнала: " + description);
                Console.WriteLine("Контактный телефон: " + phoneNumber);
                Console.WriteLine("Контактный e-mail: " + email);
            }
        }
    }
}