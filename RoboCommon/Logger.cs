using RoboInfra;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace RoboCommon
{
    [Export(typeof(ILogger))]
    public class Logger : ILogger
    {
        private const string _logFileName = "Robots.log";

        private readonly object _syncObject = new object();

        private static readonly StreamWriter _streamWriter;

        static Logger()
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, _logFileName);
            _streamWriter = new StreamWriter(filePath);
        }

        #region ILogger implementation
        //todo: check log file for all methods
        public void LogException(string message)
        {
            lock(_syncObject)
            {
                _streamWriter.WriteLine(DateTime.Now.ToLongDateString() + " ERROR " + message);
            }
        }

        public void LogInfo(string message)
        {
            lock(_syncObject)
            {
                _streamWriter.WriteLine(DateTime.Now.ToLongDateString() + " INFO " + message);
            }
        }

        public void LogWarn(string message)
        {
            lock(_syncObject)
            {
                _streamWriter.WriteLine(DateTime.Now.ToLongDateString() + " WARN " + message);
            }
        }

        #endregion
    }
}
