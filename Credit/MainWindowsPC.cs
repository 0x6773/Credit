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

        private bool check1_data0()                                              // Checks if RuntimeData.Name exits in Records
        {
            try
            {
                var isFound = User.Search(RuntimeData.Name);
                if (!isFound)
                {
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
    }
}
