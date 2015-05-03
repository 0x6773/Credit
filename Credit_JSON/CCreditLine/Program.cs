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

        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Type \"help\" for getting help.\nAnd \"exit\" to exit.\n");

            User.getBranch();
            Console.WriteLine("Currently on branch : {0}", User.currBranch);

            User.ReadDataFromFile();

            Input.getUserInput(args);

            Console.ReadKey();
        }

    }
}
