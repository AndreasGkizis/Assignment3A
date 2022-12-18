using Assignment3A.Models;
using Assignment3A.Service.Data;
using System;
using System.Data.Entity;
using System.Linq;


namespace Services.CandidateServices
{
    public class ListCertificates
    {
        public static void CertificateRead()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    var exams = context.Examinations.Where(x => x.Candidate_Id.Id == result && x.Passed == true).Include(x => x.Certificate_Id);
                    if (exams.Count() != 0)
                    {
                        foreach (var exam in exams)
                        {
                            var examID = exam.Id;
                            var certID = exam.Certificate_Id.Id;
                            var props = exam.GetType().GetProperties();
                            foreach (var prop in props)
                            {
                                if (prop.PropertyType == typeof(Candidate))
                                {
                                }
                                else if (prop.PropertyType == typeof(Certificate))
                                {
                                    var some1 = context.Certificates.Where(x => x.Id == certID).FirstOrDefault();
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
                        Console.WriteLine($"Candidate with Id = {result} does not have any exams");
                        break;
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

    }
}
