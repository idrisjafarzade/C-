using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Parmacy> parmacies = new List<Parmacy>();
            while (true)
            {
                Helper.Color("1-Create Pharmacy, 2-Add to drug, 3-Info drugs, 4-Show drugs list, 5-Sale drug, 6-Exit", ConsoleColor.Yellow);
                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                      //  Helper.Color("Thanks", ConsoleColor.Blue);
                        break;
                    switch (menu)
                    {
                        case 1:
                            Helper.Color("Enter pharmacy name", ConsoleColor.Green);
                            string aptekName = Console.ReadLine();
                            if (parmacies.Exists(x => x.Name.Trim().ToLower() == aptekName.Trim().ToLower()))
                            {
                                Helper.Color("This pharmacy name is already creat", ConsoleColor.Red);
                                goto case 1;
                            }

                            Parmacy parmacy1 = new Parmacy(aptekName);
                            parmacies.Add(parmacy1);
                            Helper.Color($"{parmacy1} pharmacy created", ConsoleColor.Yellow);
                            break;
                        case 2:
                            if (parmacies.Count == 0)
                            {
                                Helper.Color("Create pharmacy", ConsoleColor.Red);
                                goto case 1;
                            }
                         //   Helper.ParmciesCount(parmacies);
                         //   goto case 1;
                            List<Drug> drugs = new List<Drug>();
                            inputDrugTypeName:
                            Helper.Color("Enter the drugs type", ConsoleColor.Green);
                            string drugType = Console.ReadLine();
                            DrugType drugTypes = new DrugType(drugType);
                            isInt = int.TryParse(drugType, out int typname);
                            if (isInt)
                            {
                                Helper.Color("Enter the drugs type correctly", ConsoleColor.Red);
                                goto inputDrugTypeName;
                            }
                           inputDrugName2:
                            Helper.Color("Enter the drug name", ConsoleColor.Green);
                            string drugName = Console.ReadLine();
                            isInt = int.TryParse(drugName, out int name);
                            if (isInt)
                            {
                                Helper.Color("Enter the drugs name correctly", ConsoleColor.Red);
                                goto inputDrugName2;
                            }
                        inputDrugName:
                            Helper.Color("Enter the drug number", ConsoleColor.Green);
                            string maxCount1 = Console.ReadLine();
                            isInt = int.TryParse(maxCount1, out int maxCount);
                            if (!isInt)
                            {
                                Helper.Color("Enter the drugs number correctly", ConsoleColor.Red);
                                goto inputDrugName;
                            }
                        inputPrice:
                            Helper.Color("Enter the drug price", ConsoleColor.Green);
                            string price = Console.ReadLine();
                            isInt = int.TryParse(price, out int Price);
                            if (!isInt)
                            {
                                Helper.Color("Enter the drugs price correctly", ConsoleColor.Red);
                                goto inputPrice;
                            }
                        inputParmacyName:
                            Helper.Color("List of Pharmacy", ConsoleColor.Yellow);
                            foreach (var item in parmacies)
                            {
                                Helper.Color(item.ToString(), ConsoleColor.Yellow);
                            }
                            Helper.Color("Enter the pharmacy name", ConsoleColor.Green);
                            string parmacyName = Console.ReadLine();
                            parmacy1 = parmacies.Find(X => X.Name.Trim().ToLower() == parmacyName.Trim().ToLower());
                            if (parmacy1 == null)
                            {
                                Helper.Color("Enter the pharmacy name correctly", ConsoleColor.Red);
                                goto inputParmacyName;
                            }
                            Drug drug = new Drug(drugName, Price, maxCount, drugTypes);
                            if (!parmacy1.AddDrugType(drugTypes))
                            {
                                Helper.Color("not enough space", ConsoleColor.Red);
                            }
                            parmacy1.AddDrug(drug);
                            Helper.Color($"{drugName} drug {parmacy1} added to the pharmacy", ConsoleColor.Green);
                            break;
                        case 3:
                            // Helper.ParmciesCount(parmacies);
                            // goto case 1;
                            if (parmacies.Count == 0)
                            {
                                Helper.Color("Create pharmacy", ConsoleColor.Red);
                                goto case 1;
                            }
                        inputParmacy:
                            Helper.Color("List of Pharmacy ", ConsoleColor.Yellow);
                            foreach (var item in parmacies)
                            {
                                Helper.Color(item.ToString(), ConsoleColor.Yellow);
                            }
                            Helper.Color("Enter the pharmacy name", ConsoleColor.Green);
                            aptekName = Console.ReadLine();
                            parmacy1 = parmacies.Find(X => X.Name.Trim().ToLower() == aptekName.Trim().ToLower());
                            if (parmacy1 == null)
                            {
                                Helper.Color("Enter the pharmacy name correctly", ConsoleColor.Red);
                                goto inputParmacy;
                            }
                        inputinfo:
                            Helper.Color("List of drug", ConsoleColor.Yellow);
                            foreach (var item in parmacy1.ShowDrugItems())
                            {
                                Helper.Color($"{item.Name}", ConsoleColor.Yellow);
                            }
                            Helper.Color("Enter the drug name", ConsoleColor.Yellow);
                            string drugName5 = Console.ReadLine();
                            var drugName4 = parmacy1.InfoDrug(drugName5);
                            if (drugName4 == null)
                            {
                                Helper.Color("Choose the right drug", ConsoleColor.Red);
                                goto inputinfo;
                            }
                            Helper.Color("İnfo drug", ConsoleColor.Yellow);
                            Helper.Color($"Name {drugName4.Name} ,type {drugName4.Type}", ConsoleColor.Green);
                            break;

                        case 4:
                            // Helper.ParmciesCount(parmacies);
                            //  goto case 1;
                            if (parmacies.Count == 0)
                            {
                                Helper.Color("Create pharmacy", ConsoleColor.Red);
                                goto case 1;
                            }
                        inputParmacy1:
                            Helper.Color("List of pharmacy", ConsoleColor.Yellow);
                            foreach (var item in parmacies)
                            {
                                Helper.Color(item.ToString(), ConsoleColor.Yellow);
                            }
                            Helper.Color("Enter the pharmacy", ConsoleColor.Green);
                            aptekName = Console.ReadLine();
                            parmacy1 = parmacies.Find(X => X.Name.Trim().ToLower() == aptekName.Trim().ToLower());
                            if (parmacy1 == null)
                            {
                                Helper.Color("Choose the right pharmacy", ConsoleColor.Red);
                                goto inputParmacy1;
                            }
                            Helper.Color("Lidt of drugs", ConsoleColor.Yellow);
                            foreach (var item in parmacy1.ShowDrugItems())
                            {
                                Helper.Color($"{item}", ConsoleColor.Green);
                            }

                            break;
                        case 5:
                            // Helper.ParmciesCount(parmacies);
                            //  goto case 1;
                            if (parmacies.Count == 0)
                            {
                                Helper.Color("Create pharmacy", ConsoleColor.Red);
                                goto case 1;
                            }
                            Helper.Color("List of pharmacy", ConsoleColor.Green);
                            foreach (var item in parmacies)
                            {
                                Helper.Color(item.ToString(), ConsoleColor.Green);
                            }
                        inputaptek:
                            Helper.Color("Enter the pharmacy name ", ConsoleColor.Green);
                            aptekName = Console.ReadLine();
                            parmacy1 = parmacies.Find(X => X.Name.Trim().ToLower() == aptekName.Trim().ToLower());
                            if (parmacy1 == null)
                            {
                                Helper.Color("Choose the right pharmacy", ConsoleColor.Red);
                                goto inputaptek;
                            }
                        inputDrugName3:
                            Helper.Color("Enter the drug name", ConsoleColor.Green);
                            string drugName1 = Console.ReadLine();
                            isInt = int.TryParse(drugName1, out int name1);
                            if (isInt)
                            {
                                Helper.Color("Choose the right drug", ConsoleColor.Red);
                                goto inputDrugName3;
                            }
                        inputDrugCount:
                            Helper.Color("Enter the drugs number", ConsoleColor.Green);
                            string drugCount1 = Console.ReadLine();
                            isInt = int.TryParse(drugCount1, out int count1);
                            if (!isInt)
                            {
                                Helper.Color("Choose the right drug number", ConsoleColor.Red);
                                goto inputDrugCount;
                            }
                        inputDrugCash:
                            Helper.Color("Enter the Cash", ConsoleColor.Green);
                            string drugCash = Console.ReadLine();
                            isInt = double.TryParse(drugCash, out double cash);
                            if (!isInt)
                            {
                                Helper.Color("Choose the right cash", ConsoleColor.Red);
                                goto inputDrugCash;
                            }
                            parmacy1.Saledrug(drugName1, count1, cash);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Helper.Color("Choose the right numbers", ConsoleColor.Red);
                }
            }
        }
    }

}
