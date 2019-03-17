using Ninject.Modules;
using GlobalSignConsoleApp.Implementations;
using GlobalSignConsoleApp.Interfaces;

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
