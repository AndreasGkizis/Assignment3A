using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Assignment3A.Service.Data;
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
         
            DBChecker.InitialiseIfnotExists();
            Menu.ConsoleMenu1(args);
        }
    }
}
