    using BookMeProject;
using DataAccessEFGenericRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BusinessLogicValidationLayer;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            SeedDataForTesting testObj = new SeedDataForTesting();
            testObj.seedData();
            

            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
