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
using System.Text;

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
                if (User.Search(Input.words[1].ToUpper()))
                    throw new Exception(" > User Record With Name \"" + Input.words[1].ToUpper() + "\" is Already Present!");

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
                    Console.Write(" > Initial Amount is NOT in CORRECT format. \n > Initializing with Zero.\n");
                    _initAMU = 0.0;
                }
                finally
                {
                    User.AddNewUser(Input.words[1].ToUpper(), _initAMU);
                    Console.Write(" > User created with Name \"" + Input.words[1].ToUpper() + "\". \n > Initializing with : " + _initAMU.ToString() + "\n"); 
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to add to your Records?");
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
                    foreach(var temp in User.nameData)
                    {
                        Console.WriteLine(" > User " + " deleted : " + temp.Name);
                        User.DeleteUser(temp.Name);
                    }
                    
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
                if (!User.Search(Input.words[1].ToUpper()))
                    throw new Exception(" > User Record With Name \"" + Input.words[1].ToUpper() + "\" is NOT Present!");

                User.DeleteUser(Input.words[1].ToUpper());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to Delete?");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }

        public static void exit()
        {
            Environment.Exit(0);
        }

        public static void help()
        {
            Output.help();
        }

        public static void show()
        {
            try
            {
                if (!User.Search(Input.words[1].ToUpper()))
                    throw new Exception(" > User Record With Name \"" + Input.words[1].ToUpper() + "\" is NOT Present!");

                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("\tAmount\t\t\tDate Added\n\n");
                User.GetDataWithName(Input.words[1].ToUpper());
                foreach (var xx in User.currData)
                    toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", xx.Amount.ToString(), xx.DateTime.ToString());

                Console.WriteLine(toPrint.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to Show details?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }

        public static void showall()
        {
            try
            {
                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("\tName\t\t\tAmount\n\n");
                foreach (var temp in User.nameData)
                    toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name.TrimEnd(), User.GetSumWithUser(temp.Name).ToString());
                Console.WriteLine(toPrint.ToString());
            }
            catch
            {

            }
            finally
            {

            }
        }

        public static void total()
        {
            try
            {
                double total = User.GetSumAll();
                int number = User.GetTotalRecords();
                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("\tUser\t\t\tTotal\n\n");
                foreach (var temp in User.nameData)
                {
                    var xx = User.GetSumWithUser(temp.Name);
                    toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name.TrimEnd(), xx.ToString());
                }
                toPrint.AppendFormat("\n\n\tNet Total \t: \t{0}\n", total.ToString());
                Console.WriteLine(toPrint.ToString());
                Console.WriteLine("\tTotal Number of Records : {0}", number.ToString());
            }
            catch
            {

            }
            finally
            {

            }
        }

        public static void update()
        {
            try
            {
                if (!User.Search(Input.words[1].ToUpper()))
                    throw new Exception(" > User Record With Name \"" + Input.words[1].ToUpper() + "\" is NOT Present!");


                double _update_AMU = 0.0;

                try
                {
                    _update_AMU = double.Parse(Input.words[2]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write(" > Amount NOT given. \n");
                    _update_AMU = 0.0;
                }
                catch (FormatException)
                {
                    Console.Write(" > Amount is NOT in CORRECT format.\n");
                    _update_AMU = 0.0;
                }
                finally
                {
                    User.AddData(Input.words[1].ToUpper(), _update_AMU);
                    Console.Write(" > User updated with Name \"" + Input.words[1].ToUpper() + "\". \n > Updating with : " + _update_AMU.ToString() + "\n");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to update your Records?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }
    }
}