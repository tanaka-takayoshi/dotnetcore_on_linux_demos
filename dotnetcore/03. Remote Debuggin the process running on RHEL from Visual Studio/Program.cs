using System;

namespace DotNetOnLinuxDemos.RemoteDebuggingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var os = RuntimeInformation.OSDescription;
            Console.WriteLine($"Remote Debugging Sample App on {os}");
            //Waiting for remote debugging connection
            var input = Console.ReadLine();
            Console.WriteLine($"Input text is: {input}");
        }
    }
}
