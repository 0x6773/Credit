using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCreditLine
{
    public static class Output
    {
        public static void lineCommand()
        {
            Console.Write("\ncredit $ ");
        }

        public static void showCommandError(string _str)
        {
            Console.WriteLine("Command \"" + _str + "\" is not Found!\n"); 
        }

        public static void about()
        {
            Console.WriteLine("Made By : Govind Sahai\n");
        }
    }
}