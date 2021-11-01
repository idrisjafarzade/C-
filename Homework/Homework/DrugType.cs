using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{//DrugType - deye derman tipi classi olacaq. Unikal Id ve TypeName olacaq. ToString TypeName-ni qaytarmalidir.

    class DrugType
    {
        public string TypeName { get;  }
        public int Id { get;  }
        public DrugType(string typeName)
        {
            TypeName = typeName;
        }

        public override string ToString()
        {
            return TypeName; 
        }
    }
}
