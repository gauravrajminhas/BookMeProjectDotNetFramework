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
            usersBusinessValidation usersObj = new usersBusinessValidation();
            SeedDataForTesting testObj = new SeedDataForTesting();
            //testObj.seedData();
            userPoco result = usersObj.getCompletUserProfile("completeUser@qa.com");

            Console.WriteLine(result.ecifID);

            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
