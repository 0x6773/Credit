/*
 *  HelperLibrary for CCreditLine and Credit
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */

using System;
using System.Collections.Generic;

namespace HelperLibrary
{
    public class UserData
    {
        public string Name;

        public Dictionary<DateTime, Tuple<double, string>> userData;

        /*
         * Constructor 
         */
        public UserData(string s)
        {
            this.userData = new Dictionary<DateTime, Tuple<double, string>>();
            this.Name = s;
        }

        /*
         * Insert Data 
         */
        public void InsertData(double _Amu, string _note)
        {
            try
            {
                this.userData.Add(DateTime.Now, new Tuple<double, string>(_Amu, _note));
            }
            catch
            {
            }
            finally
            {
            }
        }

        /*
         * Get sum of User
         */
        public double GetSumAll()
        {
            double toReturn = 0.0;
            foreach (var temp in this.userData)
                toReturn += temp.Value.Item1;
            return toReturn;
        }

        /*
         * IComparable implemented
         */
        public int CompareTo(Object o)
        {
            if (o == null)
                return 1;
            UserData uu = o as UserData;
            if (uu != null)
                return this.Name.CompareTo(uu.Name);
            else
                throw new ArgumentException("Object is not a Comparable");
        }
    }
}

