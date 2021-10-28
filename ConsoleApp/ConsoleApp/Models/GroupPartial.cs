using ConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    partial class Group
    {
        public override string ToString()
        {
            return Name;
        }

        public bool AddStudent(Student student)
        {
            if (_students.Count == MaxCount)
            {
                return false;
            }

            _students.Add(student);
            return true;
        }

        public void ShowStudents()
        {
            if (_students.Count == 0)
            {
                Extensions.Print($"{Name} groupunda telebe yoxdur", ConsoleColor.Red);
                return;
            }

            Extensions.Print($"{Name}-un Telebelerinin siyahisi", ConsoleColor.Yellow);
            foreach (var item in _students)
            {
                Extensions.Print(item.ToString(), ConsoleColor.Green);
            }
        }

        public bool RemoveStudent(int id)
        {
            Student student = _students.Find(x => x.Id == id);
            if (student == null)
                return false;

            _students.Remove(student);
            return true;
        }

        public bool Search(string name)
        {
            var students = _students.FindAll(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            if (students.Count == 0)
            {
                Extensions.Print("Hechbir melumat tapilmadi", ConsoleColor.Red);
                return false;
            }

            Extensions.Print("Axtarish verdiyiniz telebelerin siyahisi", ConsoleColor.Yellow);
            foreach (var item in students)
            {
                Extensions.Print($"{item}", ConsoleColor.Green);
            }

            return true;
        }
    }
}
