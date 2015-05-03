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

namespace CCreditLine
{
    public static class Output
    {
        public static void lineCommand()
        {
            Console.Write("\ncredit > branch : {0} $ ", User.currBranch);
        }

        public static void showCommandError(string _str)
        {
            Console.WriteLine("Command \"" + _str + "\" is not Found!\n");
        }

        public static void about()
        {
            Console.Write(" - - Credit_linux - - \nVersion : 3.0.2.1\nMade By : Govind Sahai\nContact : gsiitbhu_at_gmail.com\n");
        }

        public static void help()
        {
            about();
            Console.WriteLine("\nTo use this software following commands\nwith proper syntax must be used : ");
            
            Console.Write("\n about \t-\t-\t-\t-\t-\t: To get the info about developer");
            Console.Write("\n add* [name] [initial Amount] [Info of Money]\t: To add a Record with [name] and [intial Amount]");
            Console.Write("\n clear \t-\t-\t-\t-\t-\t: To clear all the data");
            Console.Write("\n cls \t-\t-\t-\t-\t-\t: Clear Screen");
            Console.Write("\n delete* [name]\t-\t-\t-\t-\t: To delete a Record with [name]");
            Console.Write("\n exit** \t-\t-\t-\t-\t: Exit");
            Console.Write("\n help \t-\t-\t-\t-\t-\t: To get Help");
            Console.Write("\n show* [name]\t-\t-\t-\t-\t: Show all the data associated with [name]");
            Console.Write("\n showall \t-\t-\t-\t-\t: Show all Records with Total Balance");
            Console.Write("\n showdate [date]\t-\t-\t-\t: Show all Records on current Date");
            Console.Write("\n total \t-\t-\t-\t-\t-\t: Total Balance with ALL");
            Console.Write("\n update* [name] [amount] [Info of Money]-\t: Add [amount] to Record [name]\n");

            Console.WriteLine("\n*Any input extra to the command format will be neglected!");
            Console.WriteLine("**Double Enter at main Line To Exit");
        }
    }
}