using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Win 8.1");
            Console.WriteLine(comp.OS.Name);

            comp.OS = OS.getInstance("Win 10");
            Console.WriteLine(comp.OS.Name);

            Console.ReadKey();

        }
    }

    class Computer
    {
        public OS OS { get; set; }

        public void Launch(string OSName)
        {
            OS = OS.getInstance(OSName);
        }
    }

    class OS  
    {
        private static OS instance;
        public string Name { get; private set; }
        private static object syncRoot = new Object();

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null) instance = new OS(name);
                }
            }
            return instance;
        }
    }
}
