/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */

using HelperLibrary;
using System;

namespace Credit_linux
{
	public static class Program
	{
		static void Main(string[] args)
		{

			if (args.Length == 0)
				Console.WriteLine("Type \"help\" for getting help.\nAnd \"exit\" to exit.\n");

			User.getBranch ();
			Console.WriteLine ("Currently on branch : {0}", User.currBranch);

			User.ReadDataFromFile();

			Input.getUserInput(args);

			Console.ReadKey();
		}
	}
}
 