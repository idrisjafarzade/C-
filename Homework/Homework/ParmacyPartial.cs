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
        public override string ToString()

        {
            return Id+"."+ Name;
        }
        public bool AddDrug(Drug drug)
        {
            if (drugs.Count==drug.Count)
            {
                return false;
            }

            drugs.Add(drug);
            return true;
        }
        public List<Drug>  ShowDrugItems()
        {
            if (drugs.Count == 0)
            {
                return null; 
            }
            return drugs;

        }
        public Drug InfoDrug(string name)
        {
            var drug2 = drugs.Find((drug => drug.Name.Trim().ToLower() == name.Trim().ToLower()));
            if (drug2!=null)
            {
                return drug2;
            }
            
            return null;
        }
        public void Saledrug(string drugName, int count, double cash)
        {
           var drug = drugs.Find(drug => drug.Name.Trim().ToLower() == drugName.Trim().ToLower());
           
            if (drug==null)
            {
                Helper.Color("There was no medicine in the name mentioned", ConsoleColor.Red);
                return;
            }
            if (drug.Count<count)
            {
                Helper.Color("There was no medicine in the number mentioned", ConsoleColor.Red);
                return;
            }
            if (drug.Price>cash)
            {
                Helper.Color("Not enough money", ConsoleColor.Red);
                return;
            }
            drug.Count -= count;
            Helper.Color($"{drug.Count}  pieces of medicine", ConsoleColor.Green);
            Helper.Color("The sale was successful", ConsoleColor.Green);
            
        }
        public bool AddDrugType(DrugType drugType)
        {
            if (drugType!=null)
            {
                return true;
            }
            return false;
        }
    }
}
