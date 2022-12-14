using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;
using System.Drawing;
using System.Drawing.Printing;
using IronPdf.Forms;
using IronPdf.Pages;


using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using Assignment3A.Service.Data;
using Assignment3A.Models;
using Crud.AdminServices;

namespace Crud.CandidateServices
{
    internal class PDFGenerator
    {
        public static void createPdfFromId()
        {
            AppContextDikoMou context = new AppContextDikoMou();
            while (true)
            {
                Console.WriteLine($"Enter an Id for a Candidate");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    var exams = context.Examinations.Where(x => x.Candidate_Id.Id == result);
                    var name = context.Candidates.Where(x => x.Id == result).FirstOrDefault();
                    if (exams != null)
                    {
                        foreach (var exam in exams)
                        {
                            var path = "..\\..\\..\\newPdfFile.pdf"; // goes to folder Assignment3A/newPdfFile.pdf
                            System.IO.FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

                            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                            PdfWriter writer = PdfWriter.GetInstance(document, fs);

                            // Meta Data for the document 
                            document.AddAuthor("Andreas Gkzis's Awesome Program");
                            document.AddKeywords("certificate");
                            document.AddTitle("Certificate");

                            //Console.WriteLine($"{prop.Name} = {prop.GetValue(certificate)}");
                            document.Open();
                            // Add text
                            document.Add(new Paragraph($"CONGRATULATIONS {name.FirstName}, {name.LastName}"));

                            //document.Add(new Paragraph(st.ToString()));
                            var examID = exam.Id;
                            var props = exam.GetType().GetProperties();
                            foreach (var prop in props)
                            {
                                if (prop.PropertyType == typeof(Candidate))
                                {
                                }
                                else if (prop.PropertyType == typeof(Certificate))
                                {
                                    var some1 = context.Certificates.Where(x => x.Id == examID).FirstOrDefault();
                                    //var some = context.Examinations.Join(context.Certificates, p => p.Certificate_Id.Id, j => j.Id, 
                                    //    (p, j) => new { Certificate_Title = j.Name , cerId = j.Id }).ToList();
                                    Console.WriteLine($"{prop.Name} = {some1.Name}");
                                    document.Add(new Paragraph($" FOR GETTING THE CERTIFICATE"));
                                    document.Add(new Paragraph($"{some1.Name}"));

                                }
                                else
                                {
                                    document.Add(new Paragraph($"{prop.Name}  ---===>    {prop.GetValue(exam)}"));

                                    Console.WriteLine($"{prop.Name} = {prop.GetValue(exam)}");

                                }
                            }
                            Console.WriteLine("----------------------------------------------");
                            document.Close();
                            writer.Close();
                            fs.Close();

                            Process.Start(path);
                            Console.WriteLine("your certificate has been generated, please save it somewhere and proceed for the next one if available ");
                            Console.ReadKey();
                        }

                        break;

                    }
                    else
                    {
                        Console.WriteLine("No Certificates for this Candidate \nplease try again and enter a Number");
                    }
                }
                else
                {
                    Console.WriteLine("please try again and enter Number");
                }
            }
            Console.ReadKey();

            //var path = "..\\..\\..\\newPdfFile.pdf"; // goes to folder Assignment3A/newPdfFile.pdf
            //System.IO.FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            //Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            //PdfWriter writer = PdfWriter.GetInstance(document, fs);

            //// Meta Data for the document 
            //document.AddAuthor("Andreas Gkzis's Awesome Program");
            //document.AddKeywords("certificate");
            //document.AddTitle("Certificate");

            ////Console.WriteLine($"{prop.Name} = {prop.GetValue(certificate)}");
            //document.Open();
            //// Add text
            ////document.Add(new Paragraph(st.ToString()));
            //document.Add(new Paragraph($"{prop.Name} \t\t\t-----------------------> {prop.GetValue(certificate)}"));

            // Close the document what I opened
            //document.Close();
            //writer.Close();
            //fs.Close();

            //Process.Start(path);



            /*
                        // Set the output dir and file name
                        //        string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        //        string file = "CreatedByCSharp.pdf";

                        //        PrintDocument pDoc = new PrintDocument()
                        //        {
                        //            PrinterSettings = new PrinterSettings()
                        //            {
                        //                PrinterName = "Microsoft Print to PDF",
                        //                PrintToFile = true,
                        //                PrintFileName = System.IO.Path.Combine(directory, file),
                        //            }
                        //        };

                        //        pDoc.PrintPage += new PrintPageEventHandler(Print_Page);
                        //        //pDoc.
                        //        pDoc.Print();
                        //    void Print_Page(object sender, PrintPageEventArgs e)
                        //    {
                        //        // Here you can play with the font style 
                        //        // (and much much more, this is just an ultra-basic example)
                        //        Font fnt = new Font("Courier New", 12);

                        //        // Insert the desired text into the PDF file
                        //        e.Graphics.DrawString
                        //          ("When nothing goes right, go left", fnt, System.Drawing.Brushes.Black, 0, 0);
                        //        e.Graphics.DrawString("When nothing goes right, go left", fnt, System.Drawing.Brushes.Black, 0, 0);

                        //        e.Graphics.DrawString()
                        //    }
            */
        }
    }
}

