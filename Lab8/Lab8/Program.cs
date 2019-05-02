using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        public static List <Student> students = new List <Student>();

        static void Main(string[] args)
        {
            AddStudent("Andre", "veggie burgers", "St. Catherines");
            AddStudent("Tom", "chicken curry", "Raleigh, NC");
            string studentInfo = GetInput();
            Console.WriteLine(studentInfo);
        }

        // Add info to arrays.
        public static void AddStudent(string name, string food, string town)
        {
            students.Add(new Student(name, food, town));

        }

        // Pull info from arrays of student info.
        public static string GetStudent(int index)
        {
            try
            {
                return ($"Name: {students[index].Name}, Favorite Food: {students[index].FavoriteFood}, Hometown: {students[index].HomeTown}");
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
            for (int i = 0; i < students.Count; i++)
            {
                string name = students[i].Name;
                if(name != null)
                {
                    Console.WriteLine(i + 1 + ") " + students[i].Name);
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

                if (students[index - 1].Name == null)
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
 
        public static void LearnMore(int index)
        {
            Console.WriteLine($"{students[index].Name} - Info available: Hometown, Favorite Food");
            Console.WriteLine($"What would you like to learn more about {students[index].Name}? Hometown or favorite food?");
            string input = Console.ReadLine().ToLower().Trim().Replace(" ", "");

            try
            {
                if (input.Contains("home") || input.Contains("town"))
                {
                    Console.WriteLine($"{students[index].Name}'s hometown is {students[index].HomeTown}");
                }
                else if (input.Contains("favorite") || input.Contains("food"))
                {
                    Console.WriteLine($"{students[index].Name}'s favorite food is {students[index - 1].FavoriteFood}");
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
