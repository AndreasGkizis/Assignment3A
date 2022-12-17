using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleTools;
using Services.AdminServices;
using Services.CandidateServices;
//using Crud.CandidateServices;

namespace Menu1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Action exitAction = () => { Environment.Exit(0); };

            var crudSubmenu = new ConsoleMenu(args, level: 2)
                .Add("Show All Candidates", () => Read.CandidateReadAll())
                .Add("Show Full details of a Candidate", () => Read.CandidateRead())
                .Add("Create a new Candidate", () => Create.CreateCandidate())
                .Add("Update a Candidate's Details", () => Update.UpdateCandidate())
                .Add("Delete a Candidate", () => Delete.DeleteCandidate())
                .Add("Go to the previous screen", ConsoleMenu.Close);

            var candidateResultsSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Show all results for a Candidate", () => Read.CertificateRead());

            var adminSubMenu = new ConsoleMenu(args, level: 1)
                .Add("CRUD actions", crudSubmenu.Show)
                .Add("All Results for a Candidate (Pass && Fail)", () => Read.CertificateRead())
                .Add("Go to the previous screen", ConsoleMenu.Close);

            var candidateSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List of Certificates", () => ListCertificates.CertificateRead())
                .Add("Export Certifaicates to a PDF", () => MyExportPdf.createPdfFromId())
                .Add("Go to the previous screen", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Admin's Service", adminSubMenu.Show)
                .Add("Candidate's UI", candidateSubmenu.Show)
                .Add("Exit", () => Environment.Exit(0)).Configure(config =>
                {
                    config.Title = "Main Menu";
                });
            menu.Show();

        }
    }

}
