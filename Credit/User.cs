using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Credit
{
    public static class User
    {
        public static List<UserData> mainData;

        public static void ReadDataFromFile()        // Read the data from File
        {
            try
            {
                using (var streamRead=new StreamReader(@"data.json"))
                {
                    string json = streamRead.ReadToEnd();
                    mainData = JsonConvert.DeserializeObject<List<UserData>>(json);
                }
            }
            catch
            {
                if(!File.Exists(@"data.json"))
                    File.Create(@"data.json");
            }
            finally
            {
                
            }
        }   

        public static void WriteDataToFile()        // Write the Data to Disk in Json Format
        {
            try
            {
                string json = JsonConvert.SerializeObject(mainData.ToArray());
                File.WriteAllText(@"data.json", json);
            }
            catch
            {
                MessageBox.Show("Error!","Error Writing Data to Disks.");
            }
            finally
            {

            }
        }

        public static bool Search(string _Name)     // Search for a specific person
        {
            try
            {
                ReadDataFromFile();
                if (mainData.Count == 0)
                    return false;
                foreach (var temp in mainData)
                    if (temp.Name == _Name)
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

        public static void AddUser(string _Name)    // Add User to Records
        {
            var temp = new UserData(_Name);
            try
            {
                temp.InsertData(0);
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

        public static void UpdateUser(string _Name,int _Amu)    //Update Account for user
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
                MessageBox.Show("Some Problem Occurred Updating the data.\nPlease Try Again.", "Unexpected Error!");
            }
            finally
            {

            }
        }

        public static void WriteReadData()             // Write data then Read it, So that updated data is in disk as well as loaded
        {
            WriteDataToFile();
            ReadDataFromFile();
        }
            
        public static double GetSumOfUser()         // Get Sum of ALl users
        {
            try
            {
                ReadDataFromFile();
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