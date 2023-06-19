# ArticPolar.Dev.libLink
First Function: Open Url in default Browser

## Example of Use
````
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticPolar.Dev;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                libLink.OpenUrlInDefaultBrowser("google.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
````
