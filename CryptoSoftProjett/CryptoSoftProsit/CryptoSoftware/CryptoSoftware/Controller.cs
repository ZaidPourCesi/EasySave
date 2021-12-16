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
    class Controller
    {
        // public bool menu = true ;
        public char choice = 'a';
        /*
        public void DoesFileExist(Chiffrement a, View b)
        {
            if (!File.Exists(a.sourceFileName) || !File.Exists(a.targetFileName))
            {
                b.ShowErrorPath();
            }
        }
        */
        public void GetFileContent(Chiffrement a)
        {
            String line;
            // Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(a.sourceFileName);
            // Read the first line of text
            line = sr.ReadLine();
            // Continue to read until you reach end of file
            while (line != null)
            {
                // Write the line to input string
                a.inpoute = a.inpoute + line;
                // Read the next line
                line = sr.ReadLine();
                a.inpoute = a.inpoute + "\n";
            }
            // Close the file
            sr.Close();
        }

        public void WriteInFile(Chiffrement a)
        {
            // Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter(a.targetFileName);
            for (int i = 0; i < a.outpoute.Length-1; i++)
            {
                sw.Write(a.outpoute[i]);
            }
            // Close the file
            sw.Close();
        }
        /*
        public void AskForConfigFile(Chiffrement a, View b)
        {
            choice = b.AskInputConfigFile();
            if (choice == 'y')
            {
                a.configFileName = b.GetConfigFileName();
                a.key = GetKeyInFile(a);
            }
            else if (choice == 'n')
            {
                a.key = GetIncriptionKeyThroughUser(a,b);
            }
        }
        */
        /*
        public long GetKeyInFile(Chiffrement a)
        {
            String line;
            String temp="";
            StreamReader sre = new StreamReader(a.configFileName);
            line = sre.ReadLine();
            while (line != null)
            {
                temp = temp + line;
                line = sre.ReadLine();
            }
            sre.Close();
            return (a.key = Int64.Parse(temp));
        }
        */
        /*
        public long GetIncriptionKeyThroughUser(Chiffrement a, View b)
        {
            return (a.key = b.UserWriteIncriptionKey());
        }
        */
        public void EncryptionRoutine(Chiffrement a, View b)
        {
            try
            {
                a.stopwatch.Start();
                GetFileContent(a);
                a.EncryptDecrypt();
                WriteInFile(a);
            }
            catch
            {
                b.ShowErrorInitializing();
            }
            finally
            {
                a.stopwatch.Stop();
                b.ShowTimeElapsed(a.stopwatch); // Il faudra rediriger ça vers la sortie standard
                b.ShowEndProgram();
            }
        }
    }
}
// args = "" pour constructeur ? (argument optionnel)