using System;
using System.IO;
using System.Diagnostics;
using EasySaveApp.model;
using EasySaveApp.view;
using Newtonsoft.Json;
using DictionaryLangue;

namespace EasySaveApp.controller
{
    class Controller
    {
        private Model model;
        private View view;
        private int menuNumberTyped;
        public int numLang = 0;

        public Controller()
        {
            model = new Model();
            view = new View();
            view.Start(); //Function call

            Dictionary dico = new Dictionary();
            numLang=dico.ChooseLanguage();

            model.userMenuInput = Menu(numLang); //Function call /*/************************************************************************************

        }

        private string GetSourceDir() //Function to retrieve the input from the source
        {
            Dictionary dico = new Dictionary();
            string sourceRepository = "";
            bool isValid = false;

            while (!isValid) //Loop to allow verification of the path
            {
                sourceRepository = Console.ReadLine(); //Retrieving user input
                if (Directory.Exists(sourceRepository.Replace("\"", ""))) //Remplace \ for ""
                {
                    isValid = true;
                }
                else
                {
                    view.Error(dico.p18[numLang]); //Show error message
                }

            }
            return sourceRepository;
        }
        private string GetTargetDir() //Function to retrieve the input from the destination repesetory
        {
            Dictionary dico = new Dictionary();
            string  targetRepository= "";
            bool isValid = false;

            while (!isValid)//Loop to allow verification of the path
            {
                targetRepository = Console.ReadLine();// Retrieving user input
                if (Directory.Exists(targetRepository.Replace("\"", "")))  //Remplace \ for ""
                {
                    isValid = true;
                }
                else
                {
                    view.Error(dico.p18[numLang]); //Show error message
                }

            }
            return targetRepository;
        }

        private string GetMirrorDir() //Function to retrieve folder entry from full backup
        {
            Dictionary dico = new Dictionary();
            string mirrorRepository = "";
            bool isValid = false;

            while (!isValid)//Loop to allow verification of the path
            {
                mirrorRepository = Console.ReadLine();// Retrieving user input
                if (Directory.Exists(mirrorRepository.Replace("\"", "")))//Remplace \ for ""
                {
                    isValid = true;
                }
                else
                {
                    view.Error(dico.p18[numLang]);//Show error message
                }

            }
            return mirrorRepository;
        }

        private string Menu(int numLang) //function for menu management //*****************************************************************************************
        {
            Dictionary dico = new Dictionary();
            Stopwatch stopwatch = new Stopwatch();
            bool menu = true;
            while (menu) //Loop for menu
            {
                model.CheckDataFile(); // Calling the function to check the number of backups
                try
                {
                    view.MenuScreen(numLang); //Calling the function to display the menu //*************************************************************************
                    menuNumberTyped = int.Parse(Console.ReadLine()); //Retrieving user input for menu
                    switch (menuNumberTyped) // Switch of menu
                    {
                        case 0:
                            Environment.Exit(0); //Stop the programs
                            break;
                        case 1:
                            view.NameFileScreen(numLang); //Display message introduction on the backup names

                            string jsonString = File.ReadAllText(model.backupListFile); //Function to read json file
                            Backup[] list = JsonConvert.DeserializeObject<Backup[]>(jsonString); // Function to dezerialize the json file

                            foreach (var obj in list) //Loop to display the names of the backups
                            {
                                Console.WriteLine(" - " + obj.nameToSave); //Display of backup names
                            }
                            view.FileScreen(numLang);//Calling the function to display the names of the backups
                            string inputnamebackup = Console.ReadLine(); // Recovering backup names
                            model.LoadSave(inputnamebackup); // Calling the function to start the backup
                            break;

                        case 2:
                            if (model.checkdatabackup < 5) // Check not to exceed the save limit
                            {
                                Console.Clear(); //Console cleaning
                                view.SubMenu(numLang); // Calling the function to display the second menu
                                MenuSub(numLang); // Calling the function for the second menu
                            }
                            else
                            {
                                Console.Clear(); //Console cleaning
                                view.Error(dico.p19[numLang]); // Show Error Message
                            }

                            break;
                    }

                }
                catch
                {
                   Console.Clear();//Console cleaning
                }

            }  

            return "";
        }

        private void MenuSub(int numLang) //Function for the menu when creating backup jobs.
        {
            bool menusub = true;
            while (menusub) //Loop for menu
            {
                try
                {
                    int inputMenuSub = int.Parse(Console.ReadLine()); //Retrieving user input for second menu
                    switch (inputMenuSub) // Switch of menu
                    {
                        case 0:
                            Console.Clear();//Console cleaning
                            Menu(1); //Calling up the menu function
                            break;
                        case 1: //Case 1, creating a full backup job
                            model.type = 1; //Type declaration for backup
                            view.NameScreen(numLang); //Display for backup name
                            model.nameToSave = Console.ReadLine(); // Retrieving the name of the backup
                            view.SourceRepositoryScreen(numLang); // Display for folder source
                            model.sourceRepository = GetSourceDir(); // Function for checking the folder path
                            view.TargetRepository(numLang); // Display for the folder destination
                            model.targetRepository = GetTargetDir();  // Function for checking the folder path
                            Backup backup = new Backup(model.nameToSave, model.sourceRepository, model.targetRepository, model.type, "");
                            model.AddSave(backup); // Calling the function to add a backup job
                            break;

                        case 2: //Case 2, creating a differential backup job
                            model.type = 2; //Type declaration for backup
                            view.NameScreen(numLang);
                            model.nameToSave = Console.ReadLine();
                            view.SourceRepositoryScreen(numLang);
                            model.sourceRepository = GetSourceDir();
                            view.MirrorRepository(numLang);
                            model.mirrorRepository = GetMirrorDir();
                            view.TargetRepository(numLang);
                            model.targetRepository = GetTargetDir();
                            Backup backup2 = new Backup(model.nameToSave, model.sourceRepository, model.targetRepository, model.type, model.mirrorRepository);
                            model.AddSave(backup2); // Calling the function to add a backup job
                            break;
                    }

                }
                catch
                {
                    Console.Clear();
                    Menu(numLang); //Calling up the menu function
                }

            }

        }
    }
}

