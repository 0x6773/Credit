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

        public static string _Name_current;

        public static Dictionary<DateTime,int> _Amu_current;

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
            ReadDataFromFile();
            if (mainData.Count == 0)
                return false;
            foreach(var temp in mainData)
            {
                if(temp.Name==_Name)
                {
                    _Name_current = temp.Name;
                    _Amu_current = temp.userData;
                    return true;
                }
            }
            return false;
        }

        public static void AddUser(string _Name)    // Add User to Records
        {
            try
            {
                var temp = new UserData(_Name);
                temp.InsertData(0);
                mainData.Add(temp);
                UpdateData();
            }
            catch
            {
                MessageBox.Show("Some Problem Occurred Adding the Contact.\nPlease Try Again.", "Unexpected Error!");
            }
            finally
            {

            }
        }

        public static void UpdateUser(string _Name,int _Amu)
        {
            try
            {
                ReadDataFromFile();
                foreach (var s in mainData.Where(w => w.Name == _Name))
                    s.InsertData(_Amu);
                UpdateData();
            }
            catch
            {
                MessageBox.Show("Some Problem Occurred Updating the data.\nPlease Try Again.", "Unexpected Error!");
            }
            finally
            {

            }
        }

        private static void UpdateData()
        {
            WriteDataToFile();
            ReadDataFromFile();
        }

    }
}