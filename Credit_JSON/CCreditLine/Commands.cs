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
using System.IO;
using System.Linq;
using System.Text;

namespace CCreditLine
{
    public static class Commands
    {
        /*
		 * About Me
		 */
        public static void about()
        {
            Output.about();
        }

        /*
         * add User
         */
        public static void add()
        {
            try
            {
                if (User.Search(Input.words[1]))
                    throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is Already Present!");

                double _initAMU = 0.0;
                string _note = "--Nil--";

                try
                {
                    _initAMU = double.Parse(Input.words[2]);
                    if (Input.words.Count > 3)
                    {
                        _note = Input.words[3];
                        _note = _note.Trim().Replace('+', ' ');
                    }
                    else
                        _note = "--Nil--";
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
                    User.AddUser(Input.words[1], _initAMU, _note);
                    Console.Write(" > User created with Name \"" + Input.words[1] + "\". \n > Initializing with : " + _initAMU.ToString() + "\n");
                }
            }
            catch (ArgumentOutOfRangeException)
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

        /*
         * Add/Switch Branch
         */
        public static void branch()
        {
            try
            {
                var bName = Input.words[1];
                if (bName.Trim().Length == 0)
                    throw new Exception();
                User.setBranch(bName);
            }
            catch
            {

            }
            finally
            {
                try
                {
                    string[] branches = Directory.GetFiles(User.folderPath, "*.json");
                    var toPrint = new StringBuilder("");
                    toPrint.AppendFormat("\tTotal Number of branches : {0}\n\tBranches : \n", branches.Length);
                    foreach (var temp in branches)
                    {
                        var fileInfo = new FileInfo(temp);
                        toPrint.AppendFormat("\t\t{0}\n", fileInfo.Name.Split('.')[0]);
                    }
                    Console.WriteLine(toPrint.ToString());
                }
                catch
                {

                }
            }
        }

        /*
         * clear all records
         */
        public static void clear()
        {
            try
            {
                Console.Write("Are you Sure You Want to Delete All data(Press Y for Yes) :");
                var ans = Console.ReadLine()[0];
                if (ans.ToString().ToLower() == "y")
                {
                    foreach (var temp in User.mainData)
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

        /*
         * Clear Screen
         */
        public static void cls()
        {
            Console.Clear();
        }

        /*
         * Delete User
         */
        public static void delete()
        {
            try
            {
                if (!User.Search(Input.words[1]))
                    throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");

                Console.WriteLine("Are you sure want to delete Account with Name : {0} on branch : {1}?(Y for Yes)", Input.words[1], User.currBranch);
                string ans = Console.ReadLine().Trim();

                if (ans.ToUpper() != "Y")
                    throw new Exception();

                List<UserData> temp = new List<UserData>();
                foreach (var x in User.mainData.Where(s => s.Name != Input.words[1]))
                    temp.Add(x);
                User.mainData.Clear();
                Console.Write(" > User deleted with Name \"" + Input.words[1] + "\".\n");
                User.mainData = temp;
                User.WriteReadData();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(" > Have you forget to give name to Delete?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }

        /*
         * Exit Console Window
         */
        public static void exit()
        {
            Environment.Exit(0);
        }

        /*
         * Get help
         */
        public static void help()
        {
            Output.help();
        }

        /*
         * Show User Details
         */
        public static void show()
        {
            try
            {
                if (!User.Search(Input.words[1]))
                    throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");

                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("\tAmount\t\t\tDate Added\t\t\tNote\n\n");
                foreach (var temp in User.mainData.Where(s => s.Name == Input.words[1]))
                {
                    foreach (var xx in temp.userData)
                        toPrint.AppendFormat("\t{0}\t\t:\t{1}\t:\t{2}\n",
                            xx.Value.Item1.ToString(), xx.Key.ToString(), xx.Value.Item2.ToString());

                    toPrint.AppendFormat("\n\tTotal Balance with {0} is {1}\n", Input.words[1], temp.GetSumAll());
                }

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

        /*
         * Show all Users
         */
        public static void showall()
        {
            try
            {
                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("\tName\t\t\tAmount\n\n");
                foreach (var temp in User.mainData)
                {
                    if (temp.Name.Length >= 8)
                        toPrint.AppendFormat("\t{0}\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
                    else
                        toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
                }
                Console.WriteLine(toPrint.ToString());
            }
            catch
            {
            }
            finally
            {
            }
        }

        /*
         * Returns Data on current Date
         * Helper Method to : showdate and showdateafter
         */
        private static StringBuilder showdatehelper(DateTime cDate, ref bool x)
        {
            StringBuilder toReturn = new StringBuilder("");
            try
            {
                toReturn.AppendFormat("\n  Your Transaction on {0}\n\n", cDate.ToLongDateString());
                if (!x)
                {
                    toReturn.AppendFormat("\tUser\t\t\tAmount\t\tNote\n\n");
                    x = false;
                }
                int num = 0;
                foreach (var pep in User.mainData)
                {
                    bool chk = false;
                    foreach (var data in pep.userData)
                    {
                        if (data.Key.Date == cDate.Date)
                        {
                            chk = true;
                            num++;
                            if (pep.Name.Length >= 8)
                                toReturn.AppendFormat("\t{0}\t:\t{1}\t:\t{2}\n",
                                    pep.Name, data.Value.Item1.ToString(), data.Value.Item2.ToString());
                            else
                                toReturn.AppendFormat("\t{0}\t\t:\t{1}\t:\t{2}\n",
                                    pep.Name, data.Value.Item1.ToString(), data.Value.Item2.ToString());
                        }
                    }
                    if (chk)
                        toReturn.AppendFormat("\n");
                }
                toReturn.AppendFormat("\n\tTotal number of transactions on {0} : {1}\n\n",
                    cDate.ToLongDateString(), num.ToString());
            }
            catch
            {

            }
            finally
            {

            }
            return toReturn;
        }

        /*
         * Show All Transaction After Date
         */
        public static void showafterdate()
        {
            try
            {
                StringBuilder toPrint = new StringBuilder("");
                DateTime cDate = DateTime.Now.AddDays(-1);
                try
                {
                    cDate = DateTime.Parse(Input.words[1]);
                }
                catch
                {
                }
                bool multiple = false;
                for (; cDate.Date <= DateTime.Now.Date; cDate = cDate.AddDays(1))
                    toPrint.AppendFormat("{0}", showdatehelper(cDate, ref multiple));
                Console.WriteLine(toPrint.ToString());
            }
            catch
            {

            }
            finally
            {

            }
        }

        /*
         * Show transactions on given date
         */
        public static void showdate()
        {
            try
            {
                StringBuilder toPrint = new StringBuilder("");
                DateTime cDate = DateTime.Now;
                try
                {
                    cDate = DateTime.Parse(Input.words[1]);
                }
                catch
                {
                }
                bool multiple = false;
                toPrint.AppendFormat("{0}", showdatehelper(cDate, ref multiple));
                Console.WriteLine(toPrint.ToString());
            }
            catch
            {

            }
            finally
            {

            }
        }

        /*
         * Show Total User-Same a showall()
         */
        public static void total()
        {
            try
            {
                double total = 0.0;
                int number = 0;
                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("\tUser\t\t\tTotal\n\n");
                foreach (var temp in User.mainData)
                {
                    var xx = temp.GetSumAll();
                    if (temp.Name.Length >= 8)
                        toPrint.AppendFormat("\t{0}\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
                    else
                        toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
                    total += xx;
                    number++;
                }
                toPrint.AppendFormat("\n\tNet Total \t: \t{0}\n", total.ToString());
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

        /*
         * Update User Details
         */
        public static void update()
        {
            try
            {
                if (!User.Search(Input.words[1]))
                    throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");

                double _update_AMU = 0.0;
                string _note = "--Nil--";

                try
                {
                    _update_AMU = double.Parse(Input.words[2]);

                    if (Input.words.Count > 3)
                    {
                        _note = Input.words[3];
                        _note = _note.Trim().Replace('+', ' ');
                    }
                    else
                        _note = "--Nil--";
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write(" > Amount NOT given. \n");
                    _update_AMU = 0.0;
                    return;
                }
                catch (FormatException)
                {
                    Console.Write(" > Amount is NOT in CORRECT format.\n");
                    _update_AMU = 0.0;
                    return;
                }
                finally
                {
                }
                User.UpdateUser(Input.words[1], _update_AMU, _note);
                Console.Write(" > User updated with Name \"" + Input.words[1] +
                    "\". \n > Updating with : " + _update_AMU.ToString() + "\n");
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
