using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Assignment3A.Models;
using ConsoleTools;
using Services.AdminServices;
using Services.CandidateServices;

namespace Menu1
{
    public class Menu
    {
        public static void ConsoleMenu1(string[] args)
        {
            ConsoleMenu crudSubmenu = new ConsoleMenu(args, level: 2)
                .Add("Show All Candidates", () => CRUD.CandidateReadAll())
                .Add("Show Full details of a Candidate", () => CRUD.CandidateRead())
                .Add("Create a new Candidate", () => CRUD.CreateCandidate())
                .Add("Update a Candidate's Details", () => CRUD.UpdateCandidate())
                .Add("Delete a Candidate", () => CRUD.DeleteCandidate())
                .Add("Go to the previous screen", ConsoleMenu.Close);

            ConsoleMenu candidateResultsSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Show all results for a Candidate", () => CRUD.CertificateRead());

            ConsoleMenu adminSubMenu = new ConsoleMenu(args, level: 1)
                .Add("CRUD actions", crudSubmenu.Show)
                .Add("All Results for a Candidate (Pass && Fail)", () => CRUD.CertificateRead())
                .Add("Go to the previous screen", ConsoleMenu.Close);

            ConsoleMenu candidateSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List of Certificates", () => ListCertificates.CertificateRead())
                .Add("Export Certifaicates to a PDF", () => MyExportPdf.createPdfFromId())
                .Add("Go to the previous screen", ConsoleMenu.Close);

            ConsoleMenu menu = new ConsoleMenu(args, level: 0)
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
