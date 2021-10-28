using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    partial class Group
    {
        public string Name { get; }

        public int MaxCount { get; }

        public int Id { get; }

        private static int _counter = 0;

        //private List<Student> _students = new List<Student>();
        private List<Student> _students;

        public Group(string name, int maxCount)
        {
            Name = name;
            MaxCount = maxCount;
            _counter++;
            Id = _counter;
            _students = new List<Student>();
        }
    }
}
