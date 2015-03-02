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

        public static bool Search(string _Name)     // Search for a specific person
        {
            try
            {   
                if (mainData.Count == 0)
                    return false;
                foreach (var temp in mainData)
                    if (temp.Name.ToUpper() == _Name.ToUpper())
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

        public static void AddUser(string _Name,double _Amu = 0.0)    // Add User to Records with _Amu
        {
            var temp = new UserData(_Name);
            try
            {
                temp.InsertData(_Amu);
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

        public static void UpdateUser(string _Name,double _Amu)    //Update Account for user
        {
            try
            {
                ReadDataFromFile();
                foreach (var s in mainData.Where(w => w.Name == _Name))
                    s.InsertData(_Amu);
                WriteReadData();
            }
            catch
            {
                
            }
            finally
            {

            }
        }
            
        public static double GetSumOfUser()         // Get Sum of All users
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