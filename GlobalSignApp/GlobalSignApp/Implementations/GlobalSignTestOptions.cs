using GlobalSignConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSignConsoleApp.Implementations
{
    public class GlobalSignTestOptions : IOptions
    {
        //Member variable to specify numbe of records, default 20 for test purpose.
        public int NumberofRecords  
        {
            get
            {
                return 20;
            }
        }

        //Member variable to control either Frequently used words or least used words.
        public bool FrequentFirstOrder
        {
            get
            {
                return true;
            }
        }
    }
}
