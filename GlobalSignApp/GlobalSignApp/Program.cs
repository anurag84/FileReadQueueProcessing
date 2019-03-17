//using Ninject;
using Ninject;
using GlobalSignConsoleApp.Implementations;
using GlobalSignConsoleApp.Interfaces;
using System;
using System.ComponentModel;
using System.Reflection;

namespace GlobalSignConsoleApp
{
    public class Program
    {
        static IInputSource _inputSource;
        static IOptions _ioptions;

        static void Main(string[] args)
        {
            NinjectInitialise();

           // _ioptions.NumberofRecords = 20;
            _inputSource.ReadData();
            _inputSource.OutputData();

            Console.ReadLine();
        }

        public static void NinjectInitialise()
        {
            var kernel = new StandardKernel(new Startup());
            _inputSource = kernel.Get<IInputSource>();
            _ioptions = kernel.Get<IOptions>();
        }
    }
}
