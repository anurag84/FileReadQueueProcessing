using GlobalSignConsoleApp.Extensions;
using GlobalSignConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSignConsoleApp.Implementations
{
    //Concrete implmentation for the input interface, for the refrence of this test I have the file stored as part of the project.
    public class FileInputSource : IInputSource
    {
        private StreamReader _streamReader;
        private readonly string _filePath;
        static Queue<string> _queue;
        static Dictionary<string, int> _dict;
        static IOptions _options;

        public FileInputSource(Queue<string> Queue,Dictionary<string,int> Dictionary,IOptions options)
        {
            _filePath = @"./Data/mobydick.txt";
            _queue = Queue;
            _dict = Dictionary;
            _options = options;
            _streamReader = new StreamReader(_filePath);
        }

        //This function parse each line and adds each word into a queue to be processed in FIFO manner.
        public void ReadData()
        {
            string line;

            while ((line = _streamReader.ReadLine()) != null)
            {
                var words = line.StringSplit();

                foreach (var word in words)
                {
                    _queue.Enqueue(word.ToLower());
                }

                //Instead of using lock variable, performance was much better by using "Wait()"
                Task.Run(() => ProcessData()).Wait();
            }
        }

        //This funciton process each message in queue and add/update "Dictionary" collection.
        public void ProcessData()
        {
            try
            {
                while (_queue.Count() > 0)
                {
                    string word = _queue.Dequeue();
                    _dict[word] = (_dict.ContainsKey(word) ? ++_dict[word] : _dict[word] = 1);
                }
            }
            catch (Exception ex)
            {
                //Exceptions can be logged, can be implemented using ILogger,
                //Exceptions arrising from processing queue can be logged to DB and user can be notified to act upon.
            }
        }

        //This function controls output format of the data, its better to keep this in presentation layer and based on output source it can be managed.
        //For the purpose of test I have kept it here, in produciton environment I would return the result set to frontend and let it decide the format.
        public void OutputData()
        {
            if (_dict.Count() > 0)
            {
                if (_options.FrequentFirstOrder)
                {
                    var resultSet = _dict.OrderByDescending(sortOrder => sortOrder.Value).Take(_options.NumberofRecords);

                    foreach (var result in resultSet)
                    {
                        Console.WriteLine("{0} {1}", result.Value, result.Key);
                    }
                }
            }
        }
    }
}
