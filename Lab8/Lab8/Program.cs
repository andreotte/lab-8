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
            string info = GetInput();
            Console.WriteLine(info);
        }

        // Add info to arrays.
        public static void AddStudent(string name, string town, string food, int index)
        {
            names[index] = name;
            foods[index] = food;
            towns[index] = town;
        }

        // Pull info from arrays of student info.
        public static string GetStudent(int index)
        {
            return ($"{names[index]} {foods[index]} {towns[index]}");        
        }

        // Prints all students.
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to our C# class.  Which student would you like to learn more about?");
            for(int i = 0; i < names.Length; i++)
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
                    Console.WriteLine("Invalid input. That number does not correspond to a student index. Please enter an integer that corresponds to a student index.");
                    return GetInput();
                }
                else
                {
                    return GetStudent(index - 1);
                }

            }
            catch(System.FormatException)
            {
                Console.WriteLine("Invalid input. Please enter an integer that corresponds to a student index.");
                return GetInput();
            }

            

            // if int.Parse works, pass to GetStudent(). else, throw an exception, catch it, and tell the user to try again. 
            //Throw and catch a format exception
             
        }

    //// 
    //public static void LearnMore()
    //{

    //}
}
}
