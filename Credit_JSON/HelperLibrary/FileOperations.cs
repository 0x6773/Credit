﻿/*
 *  HelperLibrary for CCreditLine and Credit
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace HelperLibrary
{
    public static partial class User
    {
        public static string folderPath = @"C:/Credit";
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
                try
                {
                    if (!File.Exists(filePath))
                        File.Create(filePath);
                }
                catch(DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(folderPath);
                }
                finally
                {
                    if (!File.Exists(filePath))
                        File.Create(filePath);
                }
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
