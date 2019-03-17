using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSignConsoleApp.Interfaces
{
    //Interface to provide extensibility in future to hook up Input source
    public interface IInputSource
    {
        void ReadData();
        void ProcessData();
        void OutputData();
    }
}
