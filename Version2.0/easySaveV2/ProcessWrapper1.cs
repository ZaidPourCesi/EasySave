using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ProcessWrapperBETA
{
    public class ProcessWrapper
    {
        private ProcessStartInfo startingInfo;
        private Process processToRun;

        private string GetProcessPath()
        {
            return ("C:\\TESTZONE\\CryptoSoftProsit\\CryptoSoftware\\CryptoSoftware\\bin\\Debug\\netcoreapp3.1"); // rendre modulable
        }                                                                                                    // algo de recherche de path ?
                                                                                                             // lecture dans un fichier dédié ?
        private string GetProcessExe()
        {
            return ("CryptoSoftware.exe"); // rendre modulable
        }                                  // lecture dans un fichier dédié ?

        private string GetProcessArguments()
        {
            return ("Cible.txt Reverse.txt Config.txt"); // rendre modulable
        }                                                // lecture dans un fichier dédié ?

        // Idée : Fichier config.txt contenant les infos necessaires (chemin_exe = C:\dossier\sousdossier\ ; nom_exe =  abc.exe)
        // une ligne = un renseignement, parcourir ligne par ligne
        // identifier chaque info par une chaine de caractère la définissant (chemin_exe)
        // copier la chaine correspondante et l'enregistrer dans l'objet processWrapper (abc.exe)

        public void InitializeStartInfoProcess()
        {
            startingInfo = new ProcessStartInfo(GetProcessExe()); // chopper le non de l'exe
            startingInfo.UseShellExecute = true;
            startingInfo.WorkingDirectory = GetProcessPath(); // chopper le path de l'executable
            startingInfo.Arguments = GetProcessArguments(); // chopper les arguments : input.txt output.txt (config.txt)
        }

        public void InitializeProcess()
        {
            processToRun = new Process();
            processToRun.StartInfo = startingInfo;
            processToRun.EnableRaisingEvents = true;
            processToRun.Start();
        }

        public void EndingProcess()
        {
            processToRun.Close();
            processToRun.Dispose();
        }

        public void ProcessRoutine()
        {
            InitializeStartInfoProcess();
            InitializeProcess();
            EndingProcess();
        }
    }
}






    /*
    static void Main(string[] args)
    {
        string stringDeTchoin = "C:\\TESTZONE\\CryptoSoftProsit\\CryptoSoftware\\CryptoSoftware\\bin\\Debug\\netcoreapp3.1\\CryptoSoftware.exe";
        LancerProcessusWithEvent(stringDeTchoin);
    }

    static void LancerProcessusWithEvent(string processName)
    {
        ProcessStartInfo startingInfo = new ProcessStartInfo(processName);
        startingInfo.WorkingDirectory = "C:\\TESTZONE\\CryptoSoftProsit\\CryptoSoftware\\CryptoSoftware\\bin\\Debug\\netcoreapp3.1";
        startingInfo.UseShellExecute = true;
        string a = "Source.txt";
        string b = "Cible.txt";
        string c = "Config.txt";
        startingInfo.Arguments = a + " " + b + " " + c;
        Console.WriteLine(startingInfo.Arguments);
        Console.WriteLine(startingInfo.WorkingDirectory);

        using (Process processFils = new Process())
        {
            processFils.StartInfo = startingInfo;
            processFils.EnableRaisingEvents = true;

            // processFils.Exited += ProcessusFils_Exited;

            processFils.Start();
            Console.WriteLine("Processus {0} n°{1} est lancé", processFils.ProcessName, processFils.Id);
        }
    }
}
}
    */
