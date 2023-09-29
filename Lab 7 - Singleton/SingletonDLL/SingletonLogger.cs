using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonDLL
{
    public class SingletonLogger
    {
        private const string FILE_NAME = "log.txt";

        #region Singleton
        private static SingletonLogger instance = null;
        private static object padlock = new object();

        private SingletonLogger() 
        {
            writer = new StreamWriter(File.Create(FILE_NAME));
        }

        public static SingletonLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonLogger();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Instance
        private StreamWriter writer = null;
        private object streamSync = new object();

        public void LogMsg(string msg)
        {
            lock (streamSync)
            {
                writer.WriteLine("{0} - {1}", DateTime.Now, msg);
                Thread.Sleep(10);
            }
        }

        public void Close()
        {
            writer.Close();
        }
        #endregion
    }
}
