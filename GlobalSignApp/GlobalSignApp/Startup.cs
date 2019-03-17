using Ninject;
using Ninject.Modules;
using GlobalSignConsoleApp.Implementations;
using GlobalSignConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSignConsoleApp
{
    public class Startup : NinjectModule
    {
        public override void Load()
        {
            Bind<IInputSource>().To<FileInputSource>();
            Bind<IOptions>().To<GlobalSignTestOptions>();
        }
    }
}
