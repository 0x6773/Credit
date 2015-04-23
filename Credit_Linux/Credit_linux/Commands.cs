/*
 * 
 * Copyright (c) 2015 Govind Sahai
 * Licensed Under MIT License
 * 
 */
using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Credit_linux
{
	public static class Commands
	{
		//public static List<string> commandsList = new List<string> { 
		//    "about",                            //  About Mafiya!
		//    "add",                              //  Add user to Records
		//    "clear",                            //  Clear ALL Records
		//    "cls",                              //  Clear Screen
		//    "delete",                           //  Delete User
		//    "exit",                             //  Exit CCreditLine
		//    "help",                             //  Help to CCreditLine
		//    "show",                             //  Show User Data
		//    "showall",                          //  Show All Users Data
		//    "total",                            //  Total Balance 
		//    "update"                            //  Update(Insert) User Data
		//};

		public static void about()
		{
			Output.about();
		}

		public static void add()
		{
			try
			{
				if (User.Search(Input.words[1]))
					throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is Already Present!");

				double _initAMU = 0.0; 

				try
				{
					_initAMU = double.Parse(Input.words[2]);
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.Write(" > Initial Amount NOT given. \n > Initializing with Zero.\n");
					_initAMU = 0.0;
				}
				catch (FormatException)
				{
					Console.Write(" > Initial Amount is NOT in CORRECT format. \n > Initializing with Zero.\n");
					_initAMU = 0.0;
				}
				finally
				{
					User.AddUser(Input.words[1], _initAMU);
					Console.Write(" > User created with Name \"" + Input.words[1] + "\". \n > Initializing with : " + _initAMU.ToString() + "\n"); 
				}
			}
			catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine(" > Have you forget to give name to add to your Records?");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{

			}

		}

		public static void clear()
		{
			try
			{
				Console.Write("Are you Sure You Want to Delete All data(Press Y for Yes) :");
				var ans = Console.ReadLine()[0]; 
				if(ans.ToString().ToLower()=="y")
				{
					foreach(var temp in User.mainData)
						Console.WriteLine(" > User " + " deleted : " + temp.Name); 
					User.mainData.Clear();
					User.WriteReadData();
				}
			}
			catch
			{

			}
			finally
			{

			}
		}

		public static void cls()
		{
			Console.Clear();
		}

		public static void delete()
		{
			try
			{
				if (!User.Search(Input.words[1]))
					throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");

				List<UserData> temp = new List<UserData>();
				foreach (var x in User.mainData.Where(s => s.Name != Input.words[1]))
					temp.Add(x);
				User.mainData.Clear();
				Console.Write(" > User deleted with Name \"" + Input.words[1] + "\".\n"); 
				User.mainData = temp;
				User.WriteReadData();
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine(" > Have you forget to give name to Delete?");
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{

			}
		}

		public static void exit()
		{
			Environment.Exit(0);
		}

		public static void help()
		{
			Output.help();
		}

		public static void show()
		{
			try
			{
				if (!User.Search(Input.words[1]))
					throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");

				StringBuilder toPrint = new StringBuilder("");
				toPrint.Append("\tAmount\t\t\tDate Added\n\n");
				foreach (var temp in User.mainData.Where(s => s.Name == Input.words[1]))
					foreach (var xx in temp.userData)
						toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", xx.Value.ToString(), xx.Key.ToString());

				Console.WriteLine(toPrint.ToString());
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine(" > Have you forget to give name to Show details?");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{

			}
		}

		public static void showall()
		{
			try
			{
				StringBuilder toPrint = new StringBuilder("");
				toPrint.Append("\tName\t\t\tAmount\n\n");
				foreach (var temp in User.mainData){
					if(temp.Name.Length>=8)
						toPrint.AppendFormat("\t{0}\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
					else
						toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
				}
				Console.WriteLine(toPrint.ToString());
			}
			catch
			{

			}
			finally
			{

			}
		}

		public static void total()
		{
			try
			{
				double total = 0.0;
				int number = 0;
				StringBuilder toPrint = new StringBuilder("");
				toPrint.Append("\tUser\t\t\tTotal\n\n");
				foreach (var temp in User.mainData)
				{
					var xx = temp.GetSumAll();
					if(temp.Name.Length>=8)
						toPrint.AppendFormat("\t{0}\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
					else
						toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
					total += xx;
					number++;
				}
				toPrint.AppendFormat("\n\tNet Total \t: \t{0}\n", total.ToString());
				Console.WriteLine(toPrint.ToString());
				Console.WriteLine("\tTotal Number of Records : {0}", number.ToString());
			}
			catch
			{

			}
			finally
			{

			}
		}

		public static void update()
		{
			try
			{
				if (!User.Search(Input.words[1]))
					throw new Exception(" > User Record With Name \"" + Input.words[1] + "\" is NOT Present!");


				double _update_AMU = 0.0;

				try
				{
					_update_AMU = double.Parse(Input.words[2]);
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.Write(" > Amount NOT given. \n");
					_update_AMU = 0.0;
				}
				catch (FormatException)
				{
					Console.Write(" > Amount is NOT in CORRECT format.\n");
					_update_AMU = 0.0;
				}
				finally
				{
					User.UpdateUser(Input.words[1], _update_AMU);
					Console.Write(" > User updated with Name \"" + Input.words[1] + "\". \n > Updating with : " + _update_AMU.ToString() + "\n");
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine(" > Have you forget to give name to update your Records?");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{

			}
		}
	}
}