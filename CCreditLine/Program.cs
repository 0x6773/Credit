using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCreditLine
{
    public static class Program
    {

        public static List<string> commandsList = new List<string> { 
            "about",                            //  About Mafiya!
            "add",                              //  Add user to Records
            "clear",                            //  Clear ALL Records
            "cls",                              //  Clear Screemn
            "delete",                           //  Delete User
            "exit",                             //  Exit CCreditLine
            "help",                             //  Help to CCreditLine
            "show",                             //  Show User Data
            "showall",                          //  Show All Users Data
            "total",                            //  Total Balance 
            "update"                            //  Update(Insert) User Data
        };

        static void Main(string[] args)
        {

            User.ReadDataFromFile();

            Input.getUserInput();
            
            Console.ReadKey();
        }

    }
}
