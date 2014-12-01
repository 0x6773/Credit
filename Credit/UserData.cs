using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Credit
{
    public class UserData
    {
        public string Name;
        
        public Dictionary<DateTime, int> userData;
        
        public UserData(string s)
        {
            this.userData = new Dictionary<DateTime, int>();
            this.Name = s;
        }

        public void InsertData(int _Amu)      // Inserting User Data
        {
            try
            {
                this.userData.Add(DateTime.Now, _Amu);
            }
            catch
            {
                MessageBox.Show("Error!", "Unknown Error Occurred.");
            }
            finally
            {

            }
        }   
    }
}
