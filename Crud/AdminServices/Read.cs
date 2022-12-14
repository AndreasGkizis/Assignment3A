using Assignment3A.Models;
using Assignment3A.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Crud.AdminServices
{
    public class Read
    {
        public static void CandidateRead()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate");
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
                        //Console.WriteLine("Give the ID of the candidate you want to view the certificates");
                        //int candnumb = Convert.ToInt32(Console.ReadLine());
                        //var viewcands = appDBContext.Certificates.SqlQuery($"SELECT * FROM Certificates WHERE CandidateNumber = {candnumb}");
                        //foreach (Certificate cert in viewcands.ToList())
                        //{
                        //    Console.WriteLine(cert);
                        //}

                        foreach (var exam in exams)
                        {
                            var examID =exam.Id;
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
    }
}
