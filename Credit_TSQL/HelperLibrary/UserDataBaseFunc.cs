/*
 *  HelperLibrary for CCreditLine and Credit
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */

using System;

namespace HelperLibrary
{
    public static class User
    {
        public static UserDataBase.UserDBDataTable mainData;
        public static UserDataBase.UserDBDataTable currData;
        public static UserNameDB.UserNameDataTable nameData;

        public static void ReadDataFromDataBase()
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                mainData = main.GetData();
                var nameMain = new UserNameDBTableAdapters.UserNameTableAdapter();
                nameData = nameMain.GetData();
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }            
        }

        public static void AddNewUser(String _Name, double _Amu = 0.0)
        {
            try
            {
                var name = new UserNameDBTableAdapters.UserNameTableAdapter();
                name.InsertNameIntoUserName(_Name);
                AddData(_Name, _Amu);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public static void AddData(String _Name, double _Amu)
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                main.InsertQuery(_Name, _Amu, DateTime.Now);
                ReadDataFromDataBase();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }            
        }

        public static void DeleteUser(String _Name)
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                var nameMain = new UserNameDBTableAdapters.UserNameTableAdapter();
                main.DeleteAllDataWithName(_Name);
                nameMain.DeleteUserWithName(_Name);
                ReadDataFromDataBase();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public static void GetDataWithName(String _Name)
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                currData = main.GetDataByName(_Name);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public static Double GetSumWithUser(String _Name)
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                var Total = main.GetSumWithUser(_Name);
                return Total.Value;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return 0.0;
        }

        public static Double GetSumAll()
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                var Total = main.GetSumAllUser();
                return Total.Value;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return 0.0;
        }

        public static Int32 GetTotalRecords()
        {
            try
            {
                var main = new UserDataBaseTableAdapters.UserDBTableAdapter();
                var Total = main.GetNoOfRecords();
                return Total.Value;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return 0;
        }

        public static bool Search(String _Name)
        {
            try
            {
                var name = new UserNameDBTableAdapters.UserNameTableAdapter();
                var isPresent = name.IsNamePresent(_Name);
                if (isPresent.Value == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return false;
        }   
    }
}
