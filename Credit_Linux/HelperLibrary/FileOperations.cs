/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HelperLibrary
{
	public static partial class User
	{
		public static string folderPath= @"/mnt/sda5/Credit";
		public static string filePath = null;
		public static string branchFile=folderPath+@"/branch.txt";
		public static string currBranch = null;

		/*
		 * Get Branch Previously at, At StartUp
		 */
		public static void getBranch()
		{
			try
			{
				using(var streamRead=new StreamReader(branchFile))
				{
					currBranch=streamRead.ReadToEnd();
					currBranch=currBranch.Trim();
					filePath=folderPath+@"/"+currBranch+@".json";
				}
			}
			catch 
			{
				try
				{
					using (var sw = new StreamWriter (branchFile)) {
						sw.Write ("main");
					}
					currBranch="main";
					filePath=folderPath+@"/"+currBranch+@".json";
				}
				catch(DirectoryNotFoundException) 
				{
					Directory.CreateDirectory (folderPath);
				}
				finally 
				{
					using (var sw = new StreamWriter (branchFile)) {
						sw.Write ("main");
					}
					currBranch="main";
					filePath=folderPath+@"/"+currBranch+@".json";
				}
			}
			finally 
			{

			}
		}

		/*
		 * Set Branch if user changes it
		 */
		public static void setBranch(string bName)
		{
			try
			{
				string tempBranchName = folderPath+@"/"+bName+@".json";
				if (!File.Exists (tempBranchName))
				{
					Console.WriteLine(" > There in no branch Named : {0}, would you like to create a new one?(Y for Yes)",bName);
					string ans=Console.ReadLine().Trim();
					if(ans.ToUpper()=="Y")
					{
						File.Create (tempBranchName);
					}
					else
					{
						Console.WriteLine(" > No new branch created.");
						throw new Exception();
					}
				}
				Console.WriteLine(" > Switched to branch : {0}.",bName);
				using (var sw = new StreamWriter (branchFile)) {
					sw.Write (bName);
				}
				filePath=tempBranchName;
				currBranch=bName;
				ReadDataFromFile();
			}
			catch 
			{

			}
			finally
			{

			}

		}

		/*
		 * Read JSON Data from file and parse & parse it
		 */
		public static void ReadDataFromFile()
		{
			try
			{
				using(var streamRead=new StreamReader(filePath))
				{
					string json=streamRead.ReadToEnd();
					mainData=JsonConvert.DeserializeObject<List<UserData>>(json);
				}
				mainData.Sort();
			}

			catch
			{
				try
				{
					if (!File.Exists (filePath))
						File.Create (filePath);
				}
				catch(DirectoryNotFoundException) 
				{
					Directory.CreateDirectory (folderPath);
				}
				finally 
				{
					if (!File.Exists (filePath))
						File.Create (filePath);
				}
			}
			finally 
			{

			}
		}

		/*
		 * Write data in memory to disk 
		 */
		public static void WriteDataToFile()
		{
			try
			{
				mainData.Sort();
				string json=JsonConvert.SerializeObject(mainData.ToArray());
				File.WriteAllText(filePath,json);
			}
			catch 
			{

			}
			finally 
			{

			}
		}

		/*
		 * Just do above operations one-by-one
		 */
		public static void WriteReadData()
		{
			WriteDataToFile ();
			ReadDataFromFile ();
		}
	}
}