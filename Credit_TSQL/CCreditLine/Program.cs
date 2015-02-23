/*
 *  CCreditLine
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */


using HelperLibrary;
using System;
using System.Collections.Generic;

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

            Console.WriteLine("Type \"help\" for getting help.\nAnd \"exit\" to exit.");
            User.ReadDataFromDataBase();

            Input.getUserInput();
            
            Console.ReadKey();
        }

    }
}
