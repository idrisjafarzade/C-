using ConsoleApp.Models;
using ConsoleApp.Utils;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groups = new List<Group>();

            while (true)
            {
                Extensions.Print("1 - Group yaratmaq, 2 - Telebe elave etmek, " +
                "3 - Telebeni silmek, 4 - Telebelerin siyahisi, " +
                "5 - Axtarish etmek, 6 - Chixish", ConsoleColor.Yellow);

                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                        break;

                    switch (menu)
                    {
                        case 1:
                            Extensions.Print("Groupun adini daxil edin", ConsoleColor.Yellow);
                            string groupName = Console.ReadLine();

                            if (groups.Exists(x => x.Name.ToLower() == groupName.ToLower()))
                            {
                                Extensions.Print("Bu adda group movcuddur", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputMaxCount:
                            Extensions.Print("Groupda telebelerin sayini daxil edin", ConsoleColor.Yellow);
                            string maxCountString = Console.ReadLine();
                            isInt = int.TryParse(maxCountString, out int maxCount);
                            if (!isInt)
                            {
                                Extensions.Print("Telebe sayini duzgun daxil edin", ConsoleColor.Red);
                                goto inputMaxCount;
                            }

                            Group group = new Group(groupName, maxCount);
                            groups.Add(group);

                            Extensions.Print($"{groupName} elave olundu", ConsoleColor.Green);
                            break;
                        case 2:
                            if (groups.Count == 0)
                            {
                                Extensions.Print("Movcud olan qrupunuz yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }

                            Extensions.Print("Telebenin adini daxil edin", ConsoleColor.Yellow);
                            string name = Console.ReadLine();
                            Extensions.Print("Telebenin soyadini daxil edin", ConsoleColor.Yellow);
                            string surname = Console.ReadLine();

                            inputGroupName:
                            Extensions.Print("Movcud olan grouplarin siyahisi", ConsoleColor.Yellow);
                            foreach (var item in groups)
                            {
                                Extensions.Print(item.ToString(), ConsoleColor.Green);
                            }

                            Extensions.Print("Group adini daxil edin", ConsoleColor.Yellow);
                            groupName = Console.ReadLine();
                            Group existGroup = groups.Find(x => x.Name.ToLower() == groupName.ToLower());
                            if (existGroup == null)
                            {
                                Extensions.Print("Movcud qruplardan sechin", ConsoleColor.Red);
                                goto inputGroupName;
                            }

                            Student student = new Student(name, surname);
                            if (!existGroup.AddStudent(student))
                            {
                                Extensions.Print("Limiti ashirsiz", ConsoleColor.Red);
                                goto inputGroupName;
                            }

                            Extensions.Print($"{student} {existGroup}-na elave olundu", ConsoleColor.Green);

                            break;
                        case 3:
                            if (groups.Count == 0)
                            {
                                Extensions.Print("Movcud olan qrupunuz yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputGroupName2:
                            Extensions.Print("Movcud olan grouplarin siyahisi", ConsoleColor.Yellow);
                            foreach (var item in groups)
                            {
                                Extensions.Print(item.ToString(), ConsoleColor.Green);
                            }

                            Extensions.Print("Group adini daxil edin", ConsoleColor.Yellow);
                            groupName = Console.ReadLine();
                            existGroup = groups.Find(x => x.Name.ToLower() == groupName.ToLower());
                            if (existGroup == null)
                            {
                                Extensions.Print("Movcud qruplardan sechin", ConsoleColor.Red);
                                goto inputGroupName2;
                            }

                            inputStudentId:

                            existGroup.ShowStudents();

                            Extensions.Print("Telebenin id-sini daxil edin", ConsoleColor.Yellow);
                            isInt = int.TryParse(Console.ReadLine(), out int id);
                            if (!isInt)
                            {
                                Extensions.Print("Duzgun id daxil edin", ConsoleColor.Red);
                                goto inputStudentId;
                            }

                            if (!existGroup.RemoveStudent(id))
                            {
                                Extensions.Print("Bu id-de telebe yoxdur", ConsoleColor.Red);
                                goto inputStudentId;
                            }

                            Extensions.Print($"{id} id-li telebe silindi", ConsoleColor.Green);

                            break;

                        case 4:
                            if (groups.Count == 0)
                            {
                                Extensions.Print("Movcud olan qrupunuz yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }

                            foreach (var item in groups)
                            {
                                item.ShowStudents();
                            }

                            break;

                        case 5:
                            if (groups.Count == 0)
                            {
                                Extensions.Print("Movcud olan qrupunuz yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputGroupName3:
                            Extensions.Print("Movcud olan grouplarin siyahisi", ConsoleColor.Yellow);
                            foreach (var item in groups)
                            {
                                Extensions.Print(item.ToString(), ConsoleColor.Green);
                            }

                            Extensions.Print("Group adini daxil edin", ConsoleColor.Yellow);
                            groupName = Console.ReadLine();
                            existGroup = groups.Find(x => x.Name.ToLower() == groupName.ToLower());
                            if (existGroup == null)
                            {
                                Extensions.Print("Movcud qruplardan sechin", ConsoleColor.Red);
                                goto inputGroupName3;
                            }

                        inputSearchedStudentName:
                            Extensions.Print("Axtarish etmek istediyiniz telebenin adini daxil edin", ConsoleColor.Yellow);
                            name = Console.ReadLine();
                            if (!existGroup.Search(name))
                            {
                                goto inputSearchedStudentName;
                            }

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Extensions.Print("Gosterilmish ededlerden sechin", ConsoleColor.Red);
                }
            }
        }
    }
}
