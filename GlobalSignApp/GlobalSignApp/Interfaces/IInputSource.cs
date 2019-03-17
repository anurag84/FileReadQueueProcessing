using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSignConsoleApp.Interfaces
{
    public interface IInputSource
    {
        void ReadData();
        void ProcessData();
        void OutputData();
    }
}
