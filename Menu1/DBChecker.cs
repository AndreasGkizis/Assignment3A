using Assignment3A.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu1
{
    public class DBChecker
    {
        public static void InitialiseIfnotExists()
        {
            AppContextDikoMou db = new AppContextDikoMou();
            if (!db.Database.Exists())
            {
                Console.WriteLine("Database not found on your local machine. Let me create one for you real quick");
                Console.WriteLine("I will even throw in some data so you can play around, I am a generous God ...");
                db.Database.Initialize(true);
                //db.Database.migra
                Console.WriteLine(".....Done! Press any key to continue.. =] and have fun! ");
                Console.ReadKey();
            }
        }
    }
}
