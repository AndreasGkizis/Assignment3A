using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.AdminServices;
using Crud.CandidateServices;

namespace Crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create.CreateCandidate();
            //Read.CandidateRead();
            //Update.UpdateCandidate();
            //Delete.DeleteCandidate();
            PDFGenerator.createPdfFromId();
            Console.WriteLine("out of function");
            Console.ReadKey();
        }
    }
}
