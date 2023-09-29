using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SingletonDLL;
using System.Diagnostics;

namespace ThreadingDemo
{
    public class ExerciseThreads
    {
        
        public static void ThreadLogger()
        {
            for (int nIter = 0; nIter < 100; nIter++)
            {
                string msg = String.Format("Writing Message {0}", nIter);
                SingletonLogger.Instance.LogMsg(msg);
                //Console.WriteLine("ThreadID: {0}, i: {1}", Thread.CurrentThread.ManagedThreadId, nIter);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> threadlist = new List<Thread>();

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int nThread = 0; nThread < 5; nThread++)
            {
                threadlist.Add(new Thread(ExerciseThreads.ThreadLogger));
                threadlist[nThread].Start();
            }

            foreach (Thread t in threadlist)
            {                
                t.Join();                
            }
            stopwatch.Stop();

            SingletonLogger.Instance.Close();
            Console.WriteLine("Opperation completed in " + stopwatch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }
    }
}
