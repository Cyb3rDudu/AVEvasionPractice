using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _04_NonExistingURL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest req = WebRequest.Create("http://www.notdetectedmaliciouscode.com/");
            WebResponse res;
            try
            {
                res = req.GetResponse();
            }
            catch
            {
                Environment.Exit(0);
            }
            runner();
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
