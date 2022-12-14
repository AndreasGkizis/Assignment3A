using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3A.Models;
using Assignment3A.Service.Data;

namespace Services.AdminServices
{
    public class Create
    {
        public static Candidate CreateCandidate()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            var newCand = new Candidate();
            var ArrayOfProps = newCand.GetType().GetProperties();
            foreach(var prop in ArrayOfProps )
            {
                if (prop.Name == "Id")
                { }else if(prop.Name == "PhotoIdType")
                {
                    while (true)
                    {
                        Console.WriteLine($"enter 1 for Passport 0 for National ID for field {prop.Name}");
                        var input = int.Parse(Console.ReadLine());
                        if (input == 0 || input == 1)
                        {
                            prop.SetValue(newCand, input);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("please try again and enter 0 or 1 !");
                        }
                    }
                }
                else if (prop.PropertyType == typeof(int))
                {
                    while (true)
                    {
                        Console.WriteLine($"enter a Number for field {prop.Name}");
                        var input = Console.ReadLine();
                        if (int.TryParse(input, out int result))
                        {
                            prop.SetValue(newCand, result);
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
                    prop.SetValue(newCand, Console.ReadLine());
                }else
                {
                    while (true)
                    {
                        Console.WriteLine($"enter date in YYYY-MM-DD format for {prop.Name}");
                        var input = Console.ReadLine();
                        if(DateTime.TryParse(input, out var date))
                        {
                            
                            prop.SetValue(newCand, date);
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
            return newCand;
        }

    }
}
