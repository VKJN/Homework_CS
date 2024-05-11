namespace L3
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


                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void Task1()
        {
            Console.WriteLine("Choose operation:");
            Console.WriteLine("1 - Decimal to binary");
            Console.WriteLine("2 - Binary to Decimal");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: DecimalToBinary(); break;
                case 2: BinaryToDecimal(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void BinaryToDecimal()
        {
            try
            {
                Console.WriteLine("Enter the number in binary notation: ");
                string binNum = Console.ReadLine();

                bool binOrNot = true;
                foreach (char sym in binNum)
                {
                    if (sym != '0' && sym != '1')
                    {
                        binOrNot = false;
                        break;
                    }
                }

                if (binOrNot)
                {
                    Console.WriteLine(Convert.ToInt32(binNum, 2));
                }
                else
                {
                    Console.WriteLine("incorrect format");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DecimalToBinary()
        {
            try
            {
                Console.WriteLine("Input decimal:");
                int decNum = int.Parse(Console.ReadLine());

                Console.WriteLine(Convert.ToString(decNum, 2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private static void Task2()
        {
            Console.WriteLine("Enter a number using the word (Capitalized): ");
            string numberName = Console.ReadLine();
            try
            {
                switch (numberName)
                {
                    case "Zero":
                        Console.WriteLine("0");
                        break;
                    case "One":
                        Console.WriteLine("1");
                        break;

                    case "Two":
                        Console.WriteLine("2");
                        break;

                    case "Three":
                        Console.WriteLine("3");
                        break;

                    case "Four":
                        Console.WriteLine("4");
                        break;

                    case "Five":
                        Console.WriteLine("5");
                        break;

                    case "Six":
                        Console.WriteLine("6");
                        break;

                    case "Seven":
                        Console.WriteLine("7");
                        break;

                    case "Eight":
                        Console.WriteLine("8");
                        break;

                    case "Nine":
                        Console.WriteLine("9");
                        break;

                    default:
                        throw new ArgumentException("Error. Try again");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Task3()
        {
            try
            { 
                Console.WriteLine("Enter the passport number: ");
                int passportNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the full name: ");
                string fullName = Console.ReadLine();

                Console.WriteLine("Enter the issue date");
                int issueDate = int.Parse(Console.ReadLine());

                Passport passport = new Passport(passportNumber, fullName, issueDate);
                Console.WriteLine("Passport created:");
                Console.WriteLine($"Passport Number: {passport.GetPassportNumber()}");
                Console.WriteLine($"Full Name: {passport.GetFullName()}");
                Console.WriteLine($"Issue Date: {passport.GetIssueDate()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating passport: {ex.Message}");
            }
        }

        class Passport 
        {
            private int passportNumber;
            private string fullName;
            private int issueDate;

            public Passport(int passportNumber, string fullName, int issueDate)
            {
                this.passportNumber = passportNumber;
                this.fullName = fullName;
                this.issueDate = issueDate;
            }

            public int GetPassportNumber()
            {
                return passportNumber;
            }

            public string GetFullName()
            {
                return fullName; 
            }

            public int GetIssueDate()
            {
                return issueDate; 
            }
        }

        private static void Task4()
        {
            Console.WriteLine("Input equation:");
            string input = Console.ReadLine();
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] > '9' || input[i] < '0')
                {
                    try
                    {
                        string[] s = input.Split(input[i]);
                        switch (input[i])
                        {
                            case '>':
                                Console.WriteLine(int.Parse(s[0]) > int.Parse(s[1]));
                                break;

                            case '<':
                                Console.WriteLine(int.Parse(s[0]) < int.Parse(s[1]));
                                break;

                            case '=':
                                Console.WriteLine(int.Parse(s[0]) == int.Parse(s[1]));
                                break;

                            case '!':
                                Console.WriteLine(int.Parse(s[0]) != int.Parse(s[1]));
                                break;

                            default:
                                throw new Exception("Error. Try Again");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
            }
        }
    }
}