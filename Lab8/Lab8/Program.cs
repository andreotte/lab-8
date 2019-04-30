using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        public static string[] names = new string[100];
        public static string[] foods = new string[100];
        public static string[] towns = new string[100];

        static void Main(string[] args)
        {
            AddStudent("Andre", "veggie burgers", "St. Catherines", 0);
            AddStudent("Tom", "chicken curry", "Raleigh, NC", 1);
            string studentInfo = GetInput();
            Console.WriteLine(studentInfo);
        }

        // Add info to arrays.
        public static void AddStudent(string name, string food, string town, int index)
        {
            names[index] = name;
            foods[index] = food;
            towns[index] = town;
        }

        // Pull info from arrays of student info.
        public static string GetStudent(int index)
        {
            try
            {
                return ($"Name: {names[index]}, Favorite Food: {foods[index]}, Hometown: {towns[index]}");
            }
            catch (System.IndexOutOfRangeException)
            {
                return ("Student not found, try another index");
            }        
        }

        // Prints all students.
        public static void PrintMenu()
        {
            Console.WriteLine("Who would you like to learn about?");
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                if(name != null)
                {
                    Console.WriteLine(i + 1 + ") " + names[i]);
                }
            }

        }

        // Get input from the user and pass to other methods
        public static string GetInput()
        {
            PrintMenu();
            Console.WriteLine("Please select index of the student you want to learn about.");
            string input = Console.ReadLine();

            try
            {
                int index = int.Parse(input);

                if (names[index - 1] == null)
                {
                    Console.WriteLine("Student not found, try another index.");
                    return GetInput();
                }
                else
                {
                    return GetStudent(index - 1);
                }

            }
            catch(System.FormatException)
            {
                return GetInput();
            }             
        }

        // 
        public static void LearnMore(int index)
        {
            Console.WriteLine($"{names[index]} - Info available: Hometown, Favorite Food");
            Console.WriteLine($"What would you like to learn more about {names[index]}? Hometown or favorite food?");
            string input = Console.ReadLine().ToLower().Trim().Replace(" ", "");

            try
            {
                if (input.Contains("home") || input.Contains("town"))
                {
                    Console.WriteLine($"{names[index]}'s hometown is {towns[index]}");
                }
                else if (input.Contains("favorite") || input.Contains("food"))
                {
                    Console.WriteLine($"{names[index]}'s favorite food is {foods[index - 1]}");
                }
                else
                {
                    LearnMore(index);
                }
            }

            catch (Exception)
            {
                Console.WriteLine("That data does not exist. Please try again.");
                LearnMore(index);
            }           
        }
    }
}
