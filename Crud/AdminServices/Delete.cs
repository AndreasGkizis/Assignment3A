using Assignment3A.Models;
using Assignment3A.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud.AdminServices
{
    public class Delete
    {
        public static void DeleteCandidate()
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
                        context.Candidates.Remove(candidate);
                        context.SaveChanges();
                        Console.WriteLine( $"{candidate.FirstName} deleted");
                    }
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
