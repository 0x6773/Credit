/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */

using System;
using System.Collections.Generic;

namespace HelperLibrary
{
	public class UserData
	{
		public string Name;

		public Dictionary<DateTime,double> userData;

		public UserData(string s)
		{
			this.userData = new Dictionary<DateTime, double> ();
			this.Name = s;
		}

		public void InsertData(double _Amu)
		{
			try
			{
				this.userData.Add(DateTime.Now,_Amu);
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
			double toReturn = 0.0;
			foreach (var temp in this.userData)
				toReturn += temp.Value;
			return toReturn;
		}
	}
}

