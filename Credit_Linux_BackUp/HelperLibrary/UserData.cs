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
	public sealed class UserData : IComparable
	{
		public string Name;

		public Dictionary <DateTime, Tuple <double, string>> userData;

		/*
		 * Constructor 
		 */
		public UserData(string s)
		{
			this.userData = new Dictionary <DateTime, Tuple <double, string>> ();
			this.Name = s;
		}

		/*
		 * Insert Data 
		 */
		public void InsertData (double _Amu, string _note)
		{
			this.userData.Add(DateTime.Now, new Tuple <double, string> (_Amu, _note));
		}

		/*
		 * Get sum of User
		 */
		public double GetSumAll()
		{
			return this.userData.Sum (x => x.Value.Item1);
		}

		/*
		 * IComparable implemented
		 */
		public int CompareTo(Object o)
		{
			if (o == null)
				return 1;
			UserData uu = o as UserData;
			if (uu != null) 
				return this.Name.CompareTo(uu.Name);
			else 
				throw new ArgumentException("Object is not a Comparable");
		}
	}
}

