/*
 *  Credit
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */

using HelperLibrary;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Credit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            User.ReadDataFromDataBase();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)           // Exits the current window
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Something is stopping to close the application.\nPlease try Again.","Error!");
            }
            finally
            {
               
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)         // About
        {
            try
            {
                MessageBox.Show("Made By  :  Govind Sahai\n\nGitHub     :  mafiya69\n\nIndian Institute of Technology\nBanaras Hindu University", "About Credit");
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void checkUser_Click(object sender, RoutedEventArgs e)          // Check User if Present
        {
            try
            {
                if (check0_data0())
                    if(check1_data0())
                        MessageBox.Show("The is some record present\nwith Name : " + RuntimeData.Name, "Found");
            }
            catch
            {
                MessageBox.Show("It seems like you haven`t set any data!", "Error Occurred!");
            }
            finally
            {

            }
        }

        private void saveUser_Click(object sender, RoutedEventArgs e)           // Create User
        {
            try
            {
                if (check0_data0())
                {
                    if (check1_data0(false))                                    // Returns true if User Record Found
                    {
                        MessageBox.Show("User Record Already Present", "Attention!");
                        return;
                    }
                    else
                        User.AddNewUser(RuntimeData.Name);
                }

            }
            catch
            {
                User.AddNewUser(RuntimeData.Name);
            }
            finally
            {

            }
        }

        private void updateUser_Click(object sender, RoutedEventArgs e)         // Update/Add the Current Data of User
        {
            try
            {
                if(check0_data0())
                    if (check1_data0())
                    {
                        boolChildGrid13(true);
                        boolChildGrid0and2(false);
                    }
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void data0_TextChanged(object sender, TextChangedEventArgs e)   // Called if text is changed in data0
        {
            try
            {
                RuntimeData.Name = data0.Text.ToString();
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void data1_TextChanged(object sender, TextChangedEventArgs e)   // Called if text is changed in data1
        {
            try
            {
                if (data1.IsEnabled)
                {
                    if (data1.Text.ToString().Length != 0)
                        RuntimeData.Amu = double.Parse(data1.Text.ToString());
                    else
                    {
                        RuntimeData.Amu = 0;
                        data1.Text = "0";
                    }
                }
            }
            catch
            {
                data1.Text = RuntimeData.Amu.ToString();
            }
            finally
            {

            }
        }

        private void getAmu0_Click(object sender, RoutedEventArgs e)            // OK Button
        {
            try
            {
                User.AddData(RuntimeData.Name, RuntimeData.Amu);
                data1.Text = "0";
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void totalAll_Click(object sender, RoutedEventArgs e)           // Total Button
        {
            try
            {
                MessageBox.Show("Your Current Balance is : " + User.GetSumAll().ToString() + ".", "Total Credit");
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void doneAmu0_Click(object sender, RoutedEventArgs e)           // Done Button
        {
            try
            {
                boolChildGrid0and2(true);
                boolChildGrid13(false);
                data1.Text = "0";
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void totalUser_Click(object sender, RoutedEventArgs e)          // Get Balance of Particular User
        {
            try
            {
                if(check0_data0())
                    if (check1_data0())
                    {
                        double temp = User.GetSumWithUser(RuntimeData.Name); 
                        MessageBox.Show("Current Balance With " + RuntimeData.Name + " is : " + temp.ToString(), RuntimeData.Name);
                    }
            }
            catch
            {
                MessageBox.Show("It seems like you haven`t set any data!", "Error Occurred!");
            }
            finally
            {

            }
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (check0_data0())
                {
                    if(check1_data0())
                    {
                        User.DeleteUser(RuntimeData.Name);
                        return;
                    }                    
                }
            }
            catch
            {

            }
            finally
            {

            }

        }

        private void totalList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder toPrint = new StringBuilder("");
                toPrint.Append("Name\t\t\tAmount\n\n");
                foreach (var temp in User.nameData)
                {
                    var xx = User.GetSumWithUser(temp.Name);
                    toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", temp.Name.TrimEnd(), xx.ToString());
                }
                MessageBox.Show(toPrint.ToString(), "Current List");                  
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void userList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (check0_data0())
                {
                    if (check1_data0())
                    {
                        StringBuilder toPrint = new StringBuilder("");
                        toPrint.Append("Amount\t\t\tDate Added\n\n");
                        User.GetDataWithName(RuntimeData.Name);
                        foreach (var xx in User.currData)
                            toPrint.AppendFormat("\t{0}\t\t:\t{1}\n", xx.Amount.ToString(), xx.DateTime.ToString());
                        MessageBox.Show(toPrint.ToString(), "User : " + RuntimeData.Name.ToString()); 
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }

        }

        private void deleteAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = MessageBox.Show("Are your are you Want to Clear All Your Data?", "Attention!", MessageBoxButton.OKCancel);
                if(x==MessageBoxResult.OK)
                {
                    foreach (var temp in User.nameData)
                        User.DeleteUser(temp.Name);
                }
            }
            catch
            {

            }
            finally
            {

            }
        }
    }
}