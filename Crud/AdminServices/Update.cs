using Assignment3A.Models;
using Assignment3A.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.AdminServices
{
    public class Update
    {
        public static void UpdateCandidate()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate");
                var inputId = Console.ReadLine();
                if (int.TryParse(inputId, out int result))
                {
                    var candidate = context.Candidates.Find(result);
                    if (candidate != null)
                    {
                        var props = candidate.GetType().GetProperties();
                        foreach (var prop in props)
                        {
                            if (prop.Name == "Id")
                            { }
                            else if (prop.Name == "PhotoIdType")
                            {
                                Console.WriteLine($"{prop.Name} = {prop.GetValue(candidate)}");
                                while (true)
                                {
                                    Console.WriteLine("Enter 1 for NATIONAL_ID or 2 for PASSPORT or press enter to keep it");
                                    var input = Console.ReadLine();
                                    if (input == "")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Enum.TryParse(input, out IdTypes enumResult);
                                        if (enumResult == IdTypes.PASSPORT || enumResult == IdTypes.NATIONAL_ID)
                                        {
                                            prop.SetValue(candidate, enumResult);
                                            break;
                                        }
                                        else
                                    {
                                        Console.WriteLine("---------Wrong Value Entered---------");
                                    }
                                    }
                                }
                            }
                            else if (prop.PropertyType == typeof(int))
                            {
                                Console.WriteLine($"{prop.Name} = {prop.GetValue(candidate)}");
                                while (true)
                                {
                                    Console.WriteLine($"enter a Number for field {prop.Name}");
                                    var input = Console.ReadLine();
                                    if (int.TryParse(input, out int resultInt))
                                    {
                                        prop.SetValue(candidate, resultInt);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("please try again and enter Number");
                                    }
                                }
                            }
                            else if (prop.PropertyType == typeof(string))
                            {
                                Console.WriteLine($"Please enter a value for {prop.Name}");
                                prop.SetValue(candidate, Console.ReadLine());
                            }
                            else
                            {
                                while (true)
                                {
                                    Console.WriteLine($"enter date in YYYY-MM-DD format for {prop.Name}");
                                    var input = Console.ReadLine();
                                    if (DateTime.TryParse(input, out var date))
                                    {

                                        prop.SetValue(candidate, date);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("please try again and enter date in YYYY-MM-DD format");
                                    }
                                }
                            }
                        }
                        context.SaveChanges();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("please try again and enter Number");
                    }
                }
            }
        }
    }
}
