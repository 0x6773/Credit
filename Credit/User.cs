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

        public static void getDataFromFile()
        {
            try
            {
                using (var streamRead=new StreamReader(@"data.json"))
                {
                    string json = streamRead.ReadToEnd();   
                    this.mainData=JsonC
                }
            }
        }

        public static void writeDataToFile()
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
    }
}