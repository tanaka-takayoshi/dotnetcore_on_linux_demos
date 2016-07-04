using System;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jobject = new JObject{["message"]="Hello World!"};
            Console.WriteLine(jobject.ToString());
        }
    }
}
