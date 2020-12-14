using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    class Program
    {   
        static void Main(string[] args)
        {
            TaskFactory taskFactory = new TaskFactory();
            List<Task> taskList = new List<Task>();
            for(int i = 0; i < 5; i++)
            {
                taskList.Add(taskFactory.StartNew(() =>
                {
                    Singleton singleton = Singleton.CreateInstance();
                }));
            }

        }
 
    }
    public class Singleton
    {
        private static Singleton _Singleton = null;
        private static object Singleton_Lock = new object();
        public static Singleton CreateInstance()
        {
            if (_Singleton == null) //双if +lock
            {
                lock (Singleton_Lock)
                {
                    Console.WriteLine("路过。");
                    if (_Singleton == null)
                    {
                        Console.WriteLine("被创建。");
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
        }
    }

}
