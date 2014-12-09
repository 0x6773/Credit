using HelperLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            User.mainData = new List<UserData>();
            User.ReadDataFromFile();
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
                        User.AddUser(RuntimeData.Name);
                }

            }
            catch
            {
                User.AddUser(RuntimeData.Name);
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
                foreach (var temp in User.mainData.Where(s => s.Name == RuntimeData.Name))
                    temp.InsertData(RuntimeData.Amu);
                User.WriteReadData();
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
                MessageBox.Show("Your Current Balance is : " + User.GetSumOfUser().ToString() + ".", "Total Credit");
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
                        double temp = 0.0; 
                        foreach (var x in User.mainData.Where(s => s.Name == RuntimeData.Name))
                            temp = x.GetSumAll();
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
            User.WriteReadData();
            try
            {
                if (check0_data0())
                {
                    if(check1_data0())
                    {
                        List<UserData> temp = new List<UserData>(); 
                        foreach (var x in User.mainData.Where(s => s.Name != RuntimeData.Name))
                            temp.Add(x);
                        User.mainData.Clear();
                        User.mainData = temp;
                        User.WriteReadData();
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
                foreach (var temp in User.mainData)
                    toPrint.AppendFormat("{0}\t\t:\t{1}\n", temp.Name, temp.GetSumAll().ToString());
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
                        foreach (var temp in User.mainData.Where(s => s.Name == RuntimeData.Name))
                            foreach (var xx in temp.userData)
                                toPrint.AppendFormat("{0}\t\t:\t{1}\n", xx.Value.ToString(), xx.Key.ToString());
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
    }
}