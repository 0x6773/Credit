using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCreditLine
{
    public static class Input
    {
        public static bool toExit = false;

        public static List<String> words = new List<string>();

        public static void getUserInput()
        {
            while (!toExit)
            {
                Output.lineCommand();
                string inn = Console.ReadLine();
                if (inn == null)
                    Console.Beep();
                words.Clear();

                var temp1 = inn.Split(' ');         //  Split input into words
                var temp2 = temp1.Where(s => s != "");                

                foreach (var temp in temp2)
                    words.Add(temp);

                if (words.Count == 0)
                    continue;

                if (inputPass(words[0]))
                {
                    switch (words[0].ToLower())
                    {
                        case "about":
                            Commands.about();
                            break;

                        case "add":
                            Commands.add();
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



                        default:
                            break;
                    }
                }
                else
                {
                    Output.showCommandError(words[0]);
                    continue;
                }
            }
        }

        private static bool inputPass(string _str)
        {
            foreach (var cmd in Program.commandsList)
                if (cmd == _str.ToLower())
                    return true;
            return false;
        }

    }
}