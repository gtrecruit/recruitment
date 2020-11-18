using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();

            var preproc = new Preprocess(data);
            var calc = new Calculate(data);
            var display = new Display(data);

            //TODO: start all stuff in new threads
            //Display should wait for calculate to calculate, and calculate needs to wait for preprocess to finish preprocessing
            preproc.Start();
            calc.Start();
            display.Start();
            //TODO: wait for all threads to finish


            Console.WriteLine("Press any key to exit");
            Console.WriteLine("\t\twhich one is any?!");
            Console.ReadKey();
        }
    }
}
