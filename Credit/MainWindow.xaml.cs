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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Made By : \nGovind Sahai\nmafiya69");
        }

        private void checkUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var isFound = User.Search(data0.Text.ToString());
                if(isFound)
                {
                    MessageBox.Show("The is some record present\nwith Name : " + data0.Text.ToString(), "Found"); 
                }
                else
                {
                    MessageBox.Show("No record is present\nwith Name : " + data0.Text.ToString(), "Not Found"); 
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
                User.AddUser(data0.Text.ToString());
                /*var isFound = User.Search(data0.Text.ToString());
                if(isFound)
                {
                    MessageBox.Show("User Record Already Present","Attention!");
                    return;
                }*/
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