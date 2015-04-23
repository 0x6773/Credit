/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace HelperLibrary
{
	public static partial class User
	{
		public static List<UserData> mainData;

		public static bool Search(string _Name)
		{
			try
			{
				if(mainData.Count == 0)
					return false;
				foreach(var temp in mainData)
					if(temp.Name.ToUpper()==_Name.ToUpper())
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

		public static void AddUser(string _Name, double _Amu = 0.0)
		{
			var temp = new UserData (_Name);
			try
			{
				temp.InsertData(_Amu);
				mainData.Add(temp);
				WriteReadData();
			}
			catch 
			{
				mainData = new List<UserData> ();
				mainData.Add (temp);
				WriteReadData ();
			}
			finally 
			{

			}
		}

		public static void UpdateUser(string _Name, double _Amu)
		{
			try
			{
				ReadDataFromFile();
				foreach(var temp in mainData.Where(w => w.Name == _Name))
					temp.InsertData(_Amu);
				WriteReadData();
			}
			catch 
			{

			}
			finally 
			{

			}
		}

		public static double GetSumOfUser()
		{
			try
			{
				double toReturn =0.0;
				foreach(var item in mainData)
					toReturn+=item.GetSumAll();
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

