using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{// Drug - derman classi.Name, Unikal Id, Type(DrugType tipinden),
 // Price, Count olacaq. ToString - Id, Name, Price ve Count qaytarmalidir.
    class Drug 
    {
        public string Name { get; }
        public int Id { get;  }
        public double Price { get; }
        public int Count { get; set; }

        public DrugType Type { get; }

        private static int _counter=0;

        public Drug(string name, double price, int count,DrugType type)
        {
            Name = name;
            Price = price;
            Count = count;
            _counter++;
            Id = _counter;
            Type = type;
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Price + " " + Count;
        }
    }
}
