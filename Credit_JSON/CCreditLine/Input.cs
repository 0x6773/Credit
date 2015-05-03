/*
 *  CCreditLine
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CCreditLine
{
    public static class Input
    {
        private static bool doubleEnter = false;
        public static List<String> words = new List<string>();

        /*
         * All User Input Handled Here
         */
        public static void getUserInput(string[] args)
        {
            if (args.Length == 0)
            {
                while (true)
                {
                    Output.lineCommand();
                    string inn = Console.ReadLine();

                    // Check if input is Ctrl + Z
                    if (inn == null)
                    {
                        Console.Beep();
                        Environment.Exit(0);
                    }

                    // Double Enter exit
                    if (inn != "")
                        doubleEnter = false;
                    else if (inn == "" && !doubleEnter)
                        doubleEnter = true;
                    else if (inn == "" && doubleEnter)
                        Environment.Exit(0);

                    words.Clear();

                    var temp1 = inn.Split(' ');         //  Split input into words
                    var temp2 = temp1.Where(s => s != "");

                    foreach (var temp in temp2)
                        words.Add(temp);

                    if (words.Count == 0)
                        continue;

                    switching(words[0].ToLower());
                }
            }
            else
            {

                foreach (var temp in args)
                    words.Add(temp);

                switching(words[0].ToLower());

                Environment.Exit(0);
            }	// if -else
        }//getUserInput

        /*
         * Helper Function
         */
        private static void switching(string _cc)
        {
            switch (_cc)
            {
                case "about":
                    Commands.about();
                    break;

                case "add":
                    Commands.add();
                    break;

                case "branch":
                    Commands.branch();
                    break;

                case "clear":
                    Commands.clear();
                    break;

                case "cls":
                    Commands.cls();
                    break;

                case "delete":
                    Commands.delete();
                    break;

                case "exit":
                    Commands.exit();
                    break;

                case "help":
                    Commands.help();
                    break;

                case "show":
                    Commands.show();
                    break;

                case "showafterdate":
                    Commands.showafterdate();
                    break;

                case "showall":
                    Commands.showall();
                    break;

                case "showdate":
                    Commands.showdate();
                    break;

                case "total":
                    Commands.total();
                    break;

                case "update":
                    Commands.update();
                    break;

                default:
                    Output.showCommandError(words[0]);
                    break;
            }
        }
    }
}