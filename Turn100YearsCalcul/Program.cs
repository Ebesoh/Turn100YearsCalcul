using System.Globalization;

namespace Turn100YearsCalcul
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            runProgram();
        }
        public static void runProgram()
        {
            string name;
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose option to execute! \n" +
                    "1: Run 100 years calculation program\n" +
                    "2: Terminate program ");
                char option = Console.ReadKey().KeyChar;
                Console.Clear();

                if (option == '1')
                {
                    while (true)
                    {
                        Console.WriteLine("What is your name?");
                        name = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.Clear();
                            Console.WriteLine("Name cannot be empty or whitespace."); // check for empty or whitespace
                            continue;
                        }

                        if (name.Any(char.IsDigit))
                        {
                            Console.Clear();
                            Console.WriteLine("Name must not contain numbers.");
                            continue;
                        }

                        if (name.Any(char.IsSymbol) || name.Any(char.IsSeparator) || name.Any(char.IsPunctuation))
                        {
                            Console.Clear();
                            Console.WriteLine("Name must not contain special characters.");
                            continue;
                        }

                        Console.Clear();
                        break;

                    }

                    String inputAge = "";
                    float age;
                    while (true)
                    {
                        Console.WriteLine("What is your age?");
                        inputAge = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(inputAge))
                        {
                            Console.Clear();
                            Console.WriteLine("Age cannot be empty or whitespace.");
                            continue;
                        }

                        if (!inputAge.Any(char.IsDigit))
                        {
                            Console.Clear();
                            Console.WriteLine("Age must contain ONLY numbers.");
                            continue;
                        }

                        age = float.Parse(inputAge, CultureInfo.InvariantCulture);
                        Console.WriteLine(age);

                        if (inputAge.Contains(","))
                        {
                            Console.Clear();
                            Console.WriteLine("\"Please use a dot (.) for decimals, not a comma (,).\"");
                            continue;
                        }

                        if (age <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Age must be a positive number."); // Handle negative or zero age
                            continue;
                        }

                        if (age < 18)
                        {
                            Console.Clear();
                            Console.WriteLine("You are not yet an adult. Age must be at least 18."); // Handle underage input   
                            continue;
                        }


                        if (age >= 100)
                        {
                            Console.Clear();
                            Console.WriteLine("Age must be less than 100.");
                            continue;
                        }

                        Console.Clear();
                        break;
                    }

                    NameAgeCal person = new NameAgeCal();
                    person.SetNameAge(name, age);

                    float currentYear = DateTime.Now.Year;
                    Console.WriteLine($"Current Year: {currentYear}");

                    float yearWhen100 = (float)Math.Round(currentYear + (100 - person.Age));
                    //Console.WriteLine($"Y {yearWhen100}.");


                    Console.WriteLine($"Hello {person.Name}, you are {person.Age} years old, and you will turn 100 years old in the year {yearWhen100}.\n\n");

                }

                else if (option == '2')
                {
                    Console.WriteLine("Program terminated.");
                    Thread.Sleep(2000); // Pause for 2 seconds before closing
                    isRunning = false;
                    //return; // Exit the Main method to terminate the program
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please choose 1 or 2.");
                }

            }

        }

    }
}