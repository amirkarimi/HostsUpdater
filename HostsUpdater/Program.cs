using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostsUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("HostsUpdater (C) 2013 by Amir Karimi | www.dev-frame.com");
            Console.ResetColor();

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: HostsUpdater [ip-address] [name]");
                return;
            }

            var updater = new FileUpdater();
            updater.UpdateHostRecord(args[0], args[1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Host file has been updated successfully.");

            Console.ResetColor();
        }
    }
}
