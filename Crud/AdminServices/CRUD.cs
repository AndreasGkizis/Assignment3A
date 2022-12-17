using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3A.Models;
using Assignment3A.Service.Data;

namespace Services.AdminServices
{
    public class CRUD
    {
        #region // CREATE
        public static Candidate CreateCandidate()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            var newCand = new Candidate();
            var ArrayOfProps = newCand.GetType().GetProperties();
            foreach (var prop in ArrayOfProps)
            {
                if (prop.Name == "Id") { }
                else if (prop.Name == "PhotoIdType")
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
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine($"enter date in YYYY-MM-DD format for {prop.Name}");
                        var input = Console.ReadLine();
                        if (DateTime.TryParse(input, out var date))
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

        #endregion

        #region //READ
        public static void CandidateReadAll()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            var AllCandidates = context.Candidates.ToList();
            while (true)
            {
                foreach (var candidate in AllCandidates)
                {
                    var props = candidate.GetType().GetProperties();
                    foreach (var property in props)
                    {

                        if (property.Name == "Id" ||
                                property.Name == "FirstName" ||
                                property.Name == "middleName" ||
                                property.Name == "LastName" ||
                                property.Name == "CandidateNumber")
                        {
                            Console.WriteLine($"{property.Name} = {property.GetValue(candidate)}");
                        }
                        else
                        {

                        }
                    }
                    Console.WriteLine("\n----------------------------------------------\n");
                }
                break;
            }
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine($"Reading Finished. Total number of Candidates = {AllCandidates.Count()}");
            Console.WriteLine($"Press any button to continue .. !");
            Console.WriteLine("----------------------------------------------");

            Console.ReadKey();
        }
        public static void CandidateRead()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate below ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    var candidate = context.Candidates.Find(result);
                    if (candidate != null)
                    {
                        var props = candidate.GetType().GetProperties();
                        foreach (var prop in props)
                        {
                            Console.WriteLine($"{prop.Name} = {prop.GetValue(candidate)}");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("please try again and enter Number");
                    }
                }
                else
                {
                    Console.WriteLine("please try again and enter Number");
                }
            }
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("Reading Finished, press any button to continue");
            Console.WriteLine("----------------------------------------------");

            Console.ReadKey();
        }
        public static void CertificateRead()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    var exams = context.Examinations.Where(x => x.Candidate_Id.Id == result);
                    if (exams != null)
                    {
                        foreach (var exam in exams)
                        {
                            var examID = exam.Id;
                            var props = exam.GetType().GetProperties();
                            foreach (var prop in props)
                            {
                                if (prop.PropertyType == typeof(Candidate))
                                {
                                    //var kati = prop.GetValue(exam);
                                    //int.TryParse(kati.ToString(), out examID);
                                }
                                else if (prop.PropertyType == typeof(Certificate))
                                {
                                    var some1 = context.Certificates.Where(x => x.Id == examID).FirstOrDefault();
                                    //var some = context.Examinations.Join(context.Certificates, p => p.Certificate_Id.Id, j => j.Id, 
                                    //    (p, j) => new { Certificate_Title = j.Name , cerId = j.Id }).ToList();
                                    Console.WriteLine($"{prop.Name} = {some1.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"{prop.Name} = {prop.GetValue(exam)}");

                                }
                            }
                            Console.WriteLine("----------------------------------------------");
                        }
                        break;

                    }
                    else
                    {
                        Console.WriteLine("please try again and enter Number");
                    }
                }
                else
                {
                    Console.WriteLine("please try again and enter Number");
                }
            }
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("Reading Finished, press any button to continue");
            Console.WriteLine("----------------------------------------------");

            Console.ReadKey();
        }
        #endregion

        #region // UPDATE
        public static void UpdateCandidate()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id of the Candidate you want to update");
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
                                    Console.WriteLine($"Enter a number you wish to insert into field {prop.Name}");
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

        #endregion

        #region //DELETE
        public static void DeleteCandidate()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate to DELETE");
                Console.WriteLine($"(This will delete any results Examination records they have)");
                var inputId = Console.ReadLine();
                if (int.TryParse(inputId, out int result))
                {
                    var candidate = context.Candidates.Find(result);
                    if (candidate != null)
                    {
                        Console.WriteLine($"{candidate.FirstName} with ID = {candidate.Id} is about to be deleted, are you Sure?? [y/n]");
                        Console.WriteLine($"");
                        var consent = Console.ReadLine().ToUpper();
                        if (consent == "Y")
                        {
                            context.Candidates.Remove(candidate);
                            context.SaveChanges();
                            Console.WriteLine($"{candidate.FirstName} with ID = {candidate.Id} has been deleted!");
                        }
                        else
                        {
                            Console.WriteLine("(You can always double check the ID in the Admin Console =] )");
                            Console.WriteLine("You are being redirected to the previous menu !");
                            Console.WriteLine("Press any key to continue .. !");
                            Console.ReadKey();
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again and enter a number or a valid ID");
                    Console.WriteLine("(You can always double check the ID in the Admin Console =] )");
                    Console.WriteLine("Press any key to continue .. !");
                    Console.ReadKey();
                }
            }
        }
        #endregion
    }
}
