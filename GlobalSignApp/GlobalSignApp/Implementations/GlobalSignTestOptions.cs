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
        public int NumberofRecords  
        {
            get
            {
                return 20;
            }
        }

        public bool FrequentFirstOrder
        {
            get
            {
                return true;
            }
        }
    }
}
