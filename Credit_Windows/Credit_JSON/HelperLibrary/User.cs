/*
 *  HelperLibrary for CCreditLine and Credit
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */

using System.Collections.Generic;
using System.Linq;

namespace HelperLibrary
{
    public static partial class User
    {
        public static List<UserData> mainData;

        /*
         * Find presence of any user
         */
        public static bool Search(string _Name)
        {
            try
            {
                if (mainData.Count == 0)
                    return false;

                if (mainData.Where(x => x.Name.ToUpper() == _Name.ToUpper()).ToList().Count > 0)
                    return true;
            }
            catch
            {
                return false;
            }
            finally
            {

            }
            return false;
        }

        /*
         * AddUser with current information 
         */
        public static void AddUser(string _Name, double _Amu = 0.0, string _note = "--Nil--")
        {
            var temp = new UserData(_Name);
            try
            {
                temp.InsertData(_Amu, _note);
                mainData.Add(temp);
                WriteReadData();
            }
            catch
            {
                mainData = new List<UserData>();
                mainData.Add(temp);
                WriteReadData();
            }
            finally
            {
            }
        }

        /*
         * Update User
         */
        public static void UpdateUser(string _Name, double _Amu, string _note = "--Nil--")
        {
            try
            {
                ReadDataFromFile();
                foreach (var temp in mainData.Where(w => w.Name == _Name))
                    temp.InsertData(_Amu, _note);
                WriteReadData();
            }
            catch
            {
            }
            finally
            {
            }
        }

        /*
         * Get Sum of All Users 
         */
        public static double GetSumOfUser()
        {
            try
            {
                double toReturn = 0.0;
                foreach (var item in mainData)
                    toReturn += item.GetSumAll();
                return toReturn;
            }
            catch
            {
            }
            finally
            {
            }
            return 0.0;
        }
    }
}