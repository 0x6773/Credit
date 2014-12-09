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
        private static bool doubleEnter = false;
        public static List<String> words = new List<string>();

        public static void getUserInput()
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
                        
                    case "exit":
                        Commands.exit();
                        break;
                    
                    case "help":
                        Commands.help();
                        break;
                        
                    case "show":
                        Commands.show();
                        break;
                        
                    case "showall":
                        Commands.showall();
                        break;
                    
                    case "total":
                        Commands.total();
                        break;

                    case "update":
                        Commands.update();
                        break;

                    default:
                        Output.showCommandError(words[0]);
                        continue;
                }
            }
        }
    }
}