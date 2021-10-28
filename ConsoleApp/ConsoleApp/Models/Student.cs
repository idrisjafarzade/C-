using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    class Student
    {
        public string Name { get; }

        public string Surname { get; }

        public int Id { get; }

        private static int _counter = 0;

        public Student()
        {
            _counter++;
            Id = _counter;
        }

        public Student(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}";
        }
    }
}
