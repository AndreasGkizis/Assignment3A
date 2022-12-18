using System;
using Services.AdminServices;
using Services.CandidateServices;
using ConsoleTools;

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
                .Add("Go to the previous screen", ConsoleMenu.Close)
                .Configure(config => { config.ItemForegroundColor = ConsoleColor.Green; }); ;

            ConsoleMenu candidateResultsSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Show all results for a Candidate", () => CRUD.CertificateRead())
                .Configure(config => { config.ItemForegroundColor = ConsoleColor.Green; }); ;

            ConsoleMenu adminSubMenu = new ConsoleMenu(args, level: 1)
                .Add("CRUD actions", crudSubmenu.Show)
                .Add("All Results for a Candidate (Pass && Fail)", () => CRUD.CertificateRead())
                .Add("Go to the previous screen", ConsoleMenu.Close)
                .Configure(config => { config.ItemForegroundColor = ConsoleColor.Green; }); ;

            ConsoleMenu candidateSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List of Certificates", () => ListCertificates.CertificateRead())
                .Add("Export Certifaicates to a PDF", () => MyExportPdf.createPdfFromId())
                .Add("Go to the previous screen", ConsoleMenu.Close)
                .Configure(config => { config.ItemForegroundColor = ConsoleColor.Green; }); ;

            ConsoleMenu menu = new ConsoleMenu(args, level: 0)
                .Add("Admin's Service", adminSubMenu.Show)
                .Add("Candidate's UI", candidateSubmenu.Show)
                .Add("Tree.....", () => Tree.SomeTree())
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config => { config.ItemForegroundColor = ConsoleColor.Green; });

            menu.Show();
        }
    }
}
