using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
     static class Helper
    {
        public static void Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void ParmciesCount(List<Parmacy> parmacies)
        {
            if (parmacies.Count == 0)
            {
                Helper.Color("Create pharmacy", ConsoleColor.Red);
            }
        }
     }
}
