using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCreditLine
{
    public static class Commands
    {
        //public static List<string> commandsList = new List<string> { 
        //    "about",                            //  About Mafiya!
        //    "add",                              //  Add user to Records
        //    "clear",                            //  Clear ALL Records
        //    "cls",                              //  Clear Screen
        //    "delete",                           //  Delete User
        //    "exit",                             //  Exit CCreditLine
        //    "help",                             //  Help to CCreditLine
        //    "show",                             //  Show User Data
        //    "showall",                          //  Show All Users Data
        //    "total",                            //  Total Balance 
        //    "update"                            //  Update(Insert) User Data
        //};

        public static void about()
        {
            Output.about();
        }

        public static void add()
        {
            try
            {
                if (User.Search(Input.words[1]))
                    throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is Already Present!");

                double _initAMU = 0.0; 

                try
                {
                    _initAMU = double.Parse(Input.words[2]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write(" > Initial Amount NOT given. \n > Initializing with Zero.\n");
                    _initAMU = 0.0;
                }
                catch (FormatException)
                {
                    Console.Write(" > Initial Amount is NOT is CORRECT format. \n > Initializing with Zero.\n");
                    _initAMU = 0.0;
                }
                finally
                {
                    User.AddUser(Input.words[1], _initAMU);
                    Console.Write(" > User created with Name \"" + Input.words[1] + "\". \n > Initializing with : " + _initAMU.ToString() + "\n"); 
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to add to Records?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
                
        }

        public static void clear()
        {
            try
            {
                Console.Write("Are you Sure You Want to Delete All data(Press Y for Yes) :");
                var ans = Console.ReadLine()[0]; 
                if(ans.ToString().ToLower()=="y")
                {
                    foreach(var temp in User.mainData)
                        Console.WriteLine(" > User " + " deleted : " + temp.Name); 
                    User.mainData.Clear();
                    User.WriteReadData();
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        public static void cls()
        {
            Console.Clear();
        }

        public static void delete()
        {
            try
            {
                if (!User.Search(Input.words[1]))
                    throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");

                List<UserData> temp = new List<UserData>();
                foreach (var x in User.mainData.Where(s => s.Name != Input.words[1]))
                    temp.Add(x);
                User.mainData.Clear();
                User.mainData = temp;
                User.WriteReadData();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to Delete?");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void exit()
        {

        }

        public static void help()
        {

        }

        public static void show()
        {

        }

        public static void showall()
        {

        }

        public static void total()
        {

        }

        public static void update()
        {

        }
    }
}