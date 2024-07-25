using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class Student
    {
        private double GPA;

        public string Name { get; set; }

        public double GPA
        {
            get { return GPA; }
            set
            {
                if (value < 0 || value > 4)
                    throw new ArgumentException("GPA must be between 0 and 4.");
                GPA = value;
            }
        }

        public Student(string name)
        {
            this.Name = name;
        }

        public Student(string name, double gpa)
        {
            this.Name = name;
            this.GPA = gpa;
        }
    }
}