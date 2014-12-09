using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public static partial class User
    {
        public static string filePath = @"C:/Credit/data.json";
        
        public static void ReadDataFromFile()        // Read the data from File
        {
            try
            {
                using (var streamRead = new StreamReader(filePath))
                {
                    string json = streamRead.ReadToEnd();
                    mainData = JsonConvert.DeserializeObject<List<UserData>>(json);
                }
            }
            catch
            {
                if (!File.Exists(filePath))
                    File.Create(filePath);
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
                File.WriteAllText(filePath, json);
            }
            catch
            {

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
    }
}
