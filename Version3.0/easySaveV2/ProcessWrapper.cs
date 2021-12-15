using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows;

namespace easySaveV3
{
    public class ProcessWrapper
    {

        ConfigHelper ConfH = new ConfigHelper();

        //private ProcessStartInfo startingInfo;
        ProcessStartInfo startingInfoX = new ProcessStartInfo(@"D:\Visual Studio Professional 2019\projet\p1\p2 cs\v3\v3 1_0 first clone\Version3.0\crypto\Debug\netcoreapp3.1\CryptoSoftware.exe");
        private Process processToRun = new Process();
        private string _source = string.Empty;
        private string _target = string.Empty;
        private string _key = "D:\\Visual Studio Professional 2019\\projet\\p1\\p2 cs\\v3\\v3 1_0 first clone\\Version3.0\\easySaveV2";



        private string GetProcessPath()
        {
            string path = ConfH.GetParticularKeyValue("cryptoSoftWarePath");
            return (path); // rendre modulable
        }                                                                                                    // algo de recherche de path ?
                                                                                                             // lecture dans un fichier dédié ?
        private string GetProcessExe()
        {
            return ("CryptoSoftware.exe"); // rendre modulable
        }                                  // lecture dans un fichier dédié ?

        private string GetProcessArguments()
        {

            //return ('"'+ _source +"\" \"" + _target + "Michel.txt\" " + ConfH.GetParticularKeyValue("encryptionKey")); // rendre modulable
            return ('"' + _source + "\" \"" + _target + "\" \"" + _key + "\""); // rendre modulable
        }                                                // lecture dans un fichier dédié ?

        // Idée : Fichier config.txt contenant les infos necessaires (chemin_exe = C:\dossier\sousdossier\ ; nom_exe =  abc.exe)
        // une ligne = un renseignement, parcourir ligne par ligne
        // identifier chaque info par une chaine de caractère la définissant (chemin_exe)
        // copier la chaine correspondante et l'enregistrer dans l'objet processWrapper (abc.exe)

        

        public void InitializeStartInfoProcess()
        {
            // chopper le nom de l'exe
            startingInfoX.UseShellExecute = true;
            startingInfoX.WorkingDirectory = GetProcessPath(); // chopper le path de l'executable
            startingInfoX.Arguments = GetProcessArguments(); // chopper les arguments : input.txt output.txt (config.txt)
        }

        public void InitializeProcess()
        {
            processToRun = new Process();
            processToRun.StartInfo = startingInfoX;
            processToRun.EnableRaisingEvents = true;
            //MessageBox.Show();
            processToRun.Start();
        }

        public void EndingProcess()
        {
            processToRun.Close();
            processToRun.Dispose();
            //processToRun.Kill();
        }

        public void ProcessRoutine()
        {
            InitializeStartInfoProcess();
            
            InitializeProcess();
            EndingProcess();
        }


        public void FileToCrypte(string source, string target)
        {
            //MessageBox.Show(source + " : " + target + " : " + GetProcessPath() + " : " + GetProcessExe());
            _source = source;
            _target = target;
            _key = @"D:\Visual Studio Professional 2019\projet\p1\p2 cs\v3\v3 1_0 first clone\Version3.0\easySaveV2\keytest.txt";
            ProcessRoutine();
            //MessageBox.Show(GetProcessArguments());

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
