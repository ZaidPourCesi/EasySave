using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Timers;
using CryptoSoftware;

namespace CryptoSoftware
{
    class View
    {
        public long UserWriteIncriptionKey()
        {
            Console.Write("Saisissez un entier correspondant à la clé d'incription : ");
            return (Int64.Parse(Console.ReadLine()));
        }

        public void ShowErrorPath()
        {
            Console.Write("ERROR : File path incorrect");
        }

        public void ShowErrorInitializing()
        {
            Console.Write("ERROR : Initializing failed");
        }

        public void ShowTimeElapsed(Stopwatch stpwtch)
        {
            Console.WriteLine("temps ecoulé {0}", stpwtch.ElapsedMilliseconds);
        }

        public char AskInputConfigFile()
        {
            char c = ' ';
            Console.Write("Do you have a config file containing you encryption key ? ");
            while ((c != 'y') && ((c != 'n')))
            {
                Console.Write("Please write 'y' if you have or 'n' if you don't : ");
                c = (Console.ReadLine())[0]; 
            }
            return c;
        }

        public string GetConfigFileName()
        {
            Console.Write("Type your config file name with its extension : ");
            return (Console.ReadLine());
        }

        public void PauseProgram()
        {
            Console.ReadLine();
        }

        public void ShowEndProgram()
        {
            Console.Write("We made it to the end.");
            Console.ReadLine();
        }
    }
}
