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
            User.ReadDataFromFile();
            User.mainData = new List<UserData>();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)           // Exits the current window
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)         // About
        {
            MessageBox.Show("Made By : \nGovind Sahai\nmafiya69");
        }

        private void checkUser_Click(object sender, RoutedEventArgs e)          // Check User if Present
        {
            try
            {
                var isFound = User.Search(RuntimeData.Name);
                if(isFound)
                {
                    MessageBox.Show("The is some record present\nwith Name : " + RuntimeData.Name, "Found"); 
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

        private void saveUser_Click(object sender, RoutedEventArgs e)           // Create User
        {
            try
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
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void data0_TextChanged(object sender, TextChangedEventArgs e)
        {
            RuntimeData.Name = data0.Text.ToString();
        }

        private void data1_TextChanged(object sender, TextChangedEventArgs e)
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
                data1.Text = data1.Text.ToString().Substring(0, data1.Text.ToString().Length - 1);
            }
            finally
            {

            }
        }

        private void getAmu0_Click(object sender, RoutedEventArgs e)
        {
            foreach (var temp in User.mainData.Where(s => s.Name == RuntimeData.Name))
                temp.InsertData(RuntimeData.Amu);
            User.UpdateData();
            data1.IsEnabled = false;
            data1.Text = "0";
            getAmu0.IsEnabled = false;
        }
    }
}