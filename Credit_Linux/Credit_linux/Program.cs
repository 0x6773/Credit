/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */

using HelperLibrary;
using System;
using System.Collections.Generic;

namespace Credit_linux
{
	public static class Program
	{
		public static List<string> commandsList = new List<string> { 
			"about",                            //  About Mafiya!
			"add",                              //  Add user to Records
			"clear",                            //  Clear ALL Records
			"cls",                              //  Clear Screemn
			"delete",                           //  Delete User
			"exit",                             //  Exit Credit_linux
			"help",                             //  Help to Credit_linux
			"show",                             //  Show User Data
			"showall",                          //  Show All Users Data
			"total",                            //  Total Balance 
			"update"                            //  Update(Insert) User Data
		};

		static void Main(string[] args)
		{

			if (args.Length == 0)
				Console.WriteLine("Type \"help\" for getting help.\nAnd \"exit\" to exit.");
			User.ReadDataFromFile();

			Input.getUserInput(args);

			Console.ReadKey();
		}
	}
}
 