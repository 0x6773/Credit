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

            }
            finally
            {
               
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)         // About
        {
            try
            {
                MessageBox.Show("Made By : \nGovind Sahai\nmafiya69");
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
                {
                    var isFound = User.Search(RuntimeData.Name);
                    if (isFound)
                    {
                        MessageBox.Show("The is some record present\nwith Name : " + RuntimeData.Name, "Found");
                    }
                    else
                    {
                        MessageBox.Show("No record is present\nwith Name : " + RuntimeData.Name, "Not Found");
                    }
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

        private void saveUser_Click(object sender, RoutedEventArgs e)           // Create User
        {
            try
            {
                if (check0_data0())
                {
                    var isFound = User.Search(RuntimeData.Name);
                    if (isFound)
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
                {
                    var isFound = User.Search(RuntimeData.Name);
                    if (!isFound)
                    {
                        MessageBox.Show("User Record Not Found.\nPlease Enter Name With Active User Record.", "Attention!");
                        return;
                    }
                    else
                    {
                        data1.IsEnabled = true;
                        getAmu0.IsEnabled = true;
                        doneAmu0.IsEnabled = true;
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
                data1.IsEnabled = false;
                data1.Text = "0";
                getAmu0.IsEnabled = false;
                doneAmu0.IsEnabled = false;
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
                var isFound = User.Search(RuntimeData.Name);
                if (isFound)
                {
                    double theValue = 0.0; ;
                    foreach (var temp in User.mainData.Where(s => s.Name == RuntimeData.Name))
                        theValue += temp.GetSumAll();
                    MessageBox.Show("Current Balance With " + RuntimeData.Name + " is : " + theValue.ToString()); 
                }
                else
                {
                    MessageBox.Show("No record is present\nwith Name : " + RuntimeData.Name, "Not Found");
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
                    var isFound = User.Search(RuntimeData.Name);
                    if (!isFound)
                    {
                        MessageBox.Show("User Record Not Found.\nPlease Enter Name With Active User Record.", "Attention!");
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
    }
}