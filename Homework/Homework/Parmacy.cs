using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{ // Pharmacy - aptek classi. Name, Unikal Id, Drug list olacaq.ToString - Id, Name qaytarmalidir.
  // AddDrug - methodu Drug gebul etmeli Drug listine add etmelidir.
  // InfoDrug - name qebul etmelidir ve uygun derman haqqinda melumatlari chixarmalidir.
  // ShowDrugItems - methodu olmalidir, dermanlarin siyahisini vermelidr.SaleDrug - methodu olmalidir,
  // derman adi - derman sayi - pul qebul etmelidir, eger bu dermandan varsa ve istenilen say qederdise ve
  // pulda chatirsa satish bash versin. Eks halda uygun xeberdarliq chixarsin.
   partial class Parmacy
    {
        public int  Id { get;}
        public string Name { get; }

        private static  int _counter=0;

        private List<Drug> drugs;

        List<DrugType> drugTypes;
        public Parmacy(string name)
        {
            Name = name;
            _counter++;
            Id = _counter;
            drugs = new List<Drug>();
            drugTypes = new List<DrugType>();
        }
      
    }
}
