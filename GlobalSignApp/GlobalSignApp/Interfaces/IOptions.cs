using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSignConsoleApp.Interfaces
{
    public interface IOptions
    {
        int NumberofRecords { get; }
        bool FrequentFirstOrder { get; }
    }
}
