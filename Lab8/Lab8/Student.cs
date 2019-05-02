using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Student
    {
        // declare global vars and Properties
        public string Name { get; set; }
        public string FavoriteFood { get; set; }
        public string HomeTown { get; set; }

        // Constructor
        public Student(string Name, string FavoriteFood, string HomeTown)
        {
            this.Name = Name;
            this.FavoriteFood = FavoriteFood;
            this.HomeTown = HomeTown;
        }
    }
}
