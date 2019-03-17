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
        }

        public void ReadData()
        {
            _streamReader = new StreamReader( _filePath);
            string line;

            while ((line = _streamReader.ReadLine()) != null)
            {
                var words = line.StringSplit();

                foreach (var word in words)
                {
                    _queue.Enqueue(word.ToLower());
                }

                Task.Run(() => ProcessData()).Wait();
            }
        }

        public void ProcessData()
        {
            try
            {
                while (_queue.Count() > 0)
                {
                    string word = _queue.Dequeue();
                    if (_dict.ContainsKey(word) && word != null)
                    {
                        ++_dict[word];
                    }
                    else
                    {
                        _dict[word] = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //Exceptions can be logged
            }
        }

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
