using Ninject;
using GlobalSignConsoleApp.Interfaces;
using System;

namespace GlobalSignConsoleApp
{
    public class Program
    {
        static IInputSource _inputSource;
        static IOptions _ioptions;

        static void Main(string[] args)
        {
            NinjectInitialise();
            _inputSource.ReadData();
            _inputSource.OutputData();

            Console.ReadLine();
        }

        //Function to initialise Ninject module and inject dependencies
        public static void NinjectInitialise()
        {
            var kernel = new StandardKernel(new Startup());
            _inputSource = kernel.Get<IInputSource>();
            _ioptions = kernel.Get<IOptions>();
        }
    }
}
