using System;
using System.IO;
using System.Diagnostics;
using EasySaveApp.model;
using EasySaveApp.view;
using Newtonsoft.Json;

namespace EasySaveApp.controller
{
    class Controller
    {
        private Model model;
        private View view;
        private int menuNumberTyped;

        public Controller()
        {
            model = new Model();
            view = new View();
            view.Start(); //Function call
            model.userMenuInput = Menu(); //Function call

        }

        private string GetSourceDir() //Function to retrieve the input from the source
        {
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
                    view.Error("Incorect Path"); //Show error message
                }

            }
            return sourceRepository;
        }
        private string GetTargetDir() //Function to retrieve the input from the destination repesetory
        {
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
                    view.Error("Incorect Path"); //Show error message
                }

            }
            return targetRepository;
        }

        private string GetMirrorDir() //Function to retrieve folder entry from full backup
        {
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
                    view.Error("Incorect Path");//Show error message
                }

            }
            return mirrorRepository;
        }

        private string Menu() //function for menu management
        {
            Stopwatch stopwatch = new Stopwatch();
            bool menu = true;
            while (menu) //Loop for menu
            {
                model.CheckDataFile(); // Calling the function to check the number of backups
                try
                {
                    view.MenuScreen(); //Calling the function to display the menu
                    menuNumberTyped = int.Parse(Console.ReadLine()); //Retrieving user input for menu
                    switch (menuNumberTyped) // Switch of menu
                    {
                        case 0:
                            Environment.Exit(0); //Stop the programs
                            break;
                        case 1:
                            view.NameFileScreen(); //Display message introduction on the backup names

                            string jsonString = File.ReadAllText(model.backupListFile); //Function to read json file
                            Backup[] list = JsonConvert.DeserializeObject<Backup[]>(jsonString); // Function to dezerialize the json file

                            foreach (var obj in list) //Loop to display the names of the backups
                            {
                                Console.WriteLine(" - " + obj.nameToSave); //Display of backup names
                            }
                            view.FileScreen();//Calling the function to display the names of the backups
                            string inputnamebackup = Console.ReadLine(); // Recovering backup names
                            model.LoadSave(inputnamebackup); // Calling the function to start the backup
                            break;

                        case 2:
                            if (model.checkdatabackup < 5) // Check not to exceed the save limit
                            {
                                Console.Clear(); //Console cleaning
                                view.SubMenu(); // Calling the function to display the second menu
                                MenuSub(); // Calling the function for the second menu
                            }
                            else
                            {
                                Console.Clear(); //Console cleaning
                                view.Error("You already have 5 backups to create."); // Show Error Message
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

        private void MenuSub() //Function for the menu when creating backup jobs.
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
                            Menu(); //Calling up the menu function
                            break;
                        case 1: //Case 1, creating a full backup job
                            model.type = 1; //Type declaration for backup
                            view.NameScreen(); //Display for backup name
                            model.nameToSave = Console.ReadLine(); // Retrieving the name of the backup
                            view.SourceRepositoryScreen(); // Display for folder source
                            model.sourceRepository = GetSourceDir(); // Function for checking the folder path
                            view.TargetRepository(); // Display for the folder destination
                            model.targetRepository = GetTargetDir();  // Function for checking the folder path
                            Backup backup = new Backup(model.nameToSave, model.sourceRepository, model.targetRepository, model.type, "");
                            model.AddSave(backup); // Calling the function to add a backup job
                            break;

                        case 2: //Case 2, creating a differential backup job
                            model.type = 2; //Type declaration for backup
                            view.NameScreen();
                            model.nameToSave = Console.ReadLine();
                            view.SourceRepositoryScreen();
                            model.sourceRepository = GetSourceDir();
                            view.MirrorRepository();
                            model.mirrorRepository = GetMirrorDir();
                            view.TargetRepository();
                            model.targetRepository = GetTargetDir();
                            Backup backup2 = new Backup(model.nameToSave, model.sourceRepository, model.targetRepository, model.type, model.mirrorRepository);
                            model.AddSave(backup2); // Calling the function to add a backup job
                            break;
                    }

                }
                catch
                {
                    Console.Clear();
                    Menu(); //Calling up the menu function
                }

            }

        }
    }
}
