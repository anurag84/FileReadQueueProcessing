using System;
using System.Collections.Generic;
using GlobalSignConsoleApp.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GlobalSignTestApp
{
    [TestClass]
    public class UnitTest1
    {
        static Queue<string> _queue;
        static Dictionary<string, int> _dict;
        FileInputSource _fileInputSource;
        private readonly GlobalSignTestOptions _globalSignTestOptions;

        public UnitTest1()
        {
            _queue = new Queue<string>();
            _dict = new Dictionary<string, int>();
            _fileInputSource = new FileInputSource(_queue, _dict,_globalSignTestOptions);
        }


        [TestMethod]
        public void All_Messages_Processed()
        {
            _queue.Enqueue("testMessage");
            _fileInputSource.ReadData();
            Assert.IsTrue(_queue.Count == 0);
        }

        [TestMethod]
        public void Queue_Not_Null()
        {
            _fileInputSource.ReadData();
            Assert.IsNotNull(_queue);
        }

        [TestMethod]
        public void Dict_Atleast_OneMessage()
        {
            _queue.Enqueue("TestMessageFromUnitTest");
            _fileInputSource.ReadData();
            Assert.IsTrue(_dict.Count > 0);
        }

        [TestMethod]
        public void Dict_Message_Added()
        {
            _queue.Enqueue("TestMessageFromUnitTest");
            _fileInputSource.ReadData();
            Assert.IsTrue(_dict.ContainsKey("TestMessageFromUnitTest"));
        }

        [TestMethod]
        public void Dict_Value_Inititalized()
        {
            _queue.Enqueue("TestMessageFromUnitTest");
            _fileInputSource.ReadData();
            Assert.IsTrue(_dict["TestMessageFromUnitTest"] == 1);
        }

        [TestMethod]
        public void Dict_Value_Updated()
        {
            _queue.Enqueue("TestMessageFromUnitTest");
            _queue.Enqueue("TestMessageFromUnitTest");
            _queue.Enqueue("TestMessageFromUnitTest");
            _queue.Enqueue("TestMessageFromUnitTest");
            _fileInputSource.ReadData();
            Assert.IsTrue(_dict["TestMessageFromUnitTest"] == 4);
        }

        [TestMethod]
        public void Dict_Not_Null()
        {
            _fileInputSource.ReadData();
            Assert.IsNotNull(_dict);
        }
    }
}
