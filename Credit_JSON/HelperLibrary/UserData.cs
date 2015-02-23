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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelperLibrary
{
    public class UserData
    {
        public string Name;
        
        public Dictionary<DateTime, double> userData;
        
        public UserData(string s)
        {
            this.userData = new Dictionary<DateTime, double>();
            this.Name = s;
        }

        public void InsertData(double _Amu)      // Inserting User Data
        {
            try
            {
                this.userData.Add(DateTime.Now, _Amu);
            }
            catch
            {
                
            }
            finally
            {

            }
        }   

        public double GetSumAll()
        {
            double toReturn=0.0;
            foreach (var temp in this.userData)
                toReturn += temp.Value;
            return toReturn;
        }
    
    }
}
