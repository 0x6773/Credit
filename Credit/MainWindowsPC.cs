/*
 *  Credit
 *  https://github.com/mafiya69/Credit.git
 * 
 * Copyright (c) 2014 Govind Sahai
 * Licensed under the MIT license.
 * 
 */


using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Credit
{
    public partial class MainWindow : Window
    {
        private bool check0_data0()                                              // Checks if data0 is NULL
        {
            try
            {
                if (RuntimeData.Name.Length == 0)
                {
                    MessageBox.Show("Please Enter a Name", "Attention!");
                    return false;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Unknown exception thrown.", "Error!");
                return false;
            }
            finally
            {

            }
        }

        private bool check1_data0(bool _ToShow=true)                             // Checks if RuntimeData.Name exits in Records
        {                                                                                         // Returns true if found
            try
            {
                var isFound = User.Search(RuntimeData.Name);
                if (!isFound)
                {
                    if(_ToShow)
                        MessageBox.Show("User Record Not Found.\nPlease Enter Name With Active User Record.", "Attention!");
                    return false; 
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Unknown exception thrown.", "Error!");
                return false;
            }
            finally
            {

            }
        }

        private void boolChildGrid13(bool _Change)                               // Changes the state of ChildGrid13
        {
            try
            {
                data1.IsEnabled = _Change;
                getAmu0.IsEnabled = _Change;
                doneAmu0.IsEnabled = _Change;
            }
            catch
            {
                MessageBox.Show("Unknown exception thrown.", "Error!");
            }
            finally
            {

            }
        }

        private void boolChildGrid0and2(bool _Change)                            // Changes the state of ChildGrid0 and ChildGrid1
        {
            try
            {
                data0.IsEnabled = _Change;
                checkUser.IsEnabled = _Change;
                saveUser.IsEnabled = _Change;
                updateUser.IsEnabled = _Change;
                totalAll.IsEnabled = _Change;
                totalUser.IsEnabled = _Change;
                deleteUser.IsEnabled = _Change;
                totalList.IsEnabled = _Change;
                userList.IsEnabled = _Change;
                deleteAll.IsEnabled = _Change;
            }
            catch
            {
                MessageBox.Show("Unknown exception thrown.", "Error!");
            }
            finally
            {

            }
        }
    }
}
