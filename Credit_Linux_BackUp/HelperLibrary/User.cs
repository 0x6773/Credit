/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */

using System.Collections.Generic;
using System.Linq;

namespace HelperLibrary
{
	public static partial class User
	{
		public static List<UserData> mainData;

		/*
		 * Find presence of any user
		 */
		public static bool Search(string _Name)
		{
			mainData = mainData ?? new List<UserData>();
			return mainData.Any(x => x.Name.ToUpper() == _Name.ToUpper());
		}

		/*
		 * AddUser with current information 
		 */
		public static void AddUser (string _Name, double _Amu = 0.0, string _note = "--Nil--")
		{
			_Name = _Name.Substring (0, 1).ToUpper () + _Name.Substring (1).ToLower ();
			var temp = new UserData (_Name);
			mainData = mainData ?? new List<UserData>();
			try	
			{
				temp.InsertData(_Amu, _note);
				mainData.Add(temp);
			}
			catch 
			{
				throw;
			}
			finally 
			{
				WriteReadData();
			}
		}

		/*
		 * Update User
		 */
		public static void UpdateUser(string _Name, double _Amu, string _note="--Nil--")
		{
			ReadDataFromFile ();
			mainData.Where(w => w.Name.ToUpper() == _Name.ToUpper()).ElementAt(0).InsertData(_Amu,_note);
			WriteReadData ();
		}
	}
}