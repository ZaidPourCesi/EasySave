using System;
using System.Collections.Generic;
using System.Text;
using EasySaveApp.controller;
using EasySaveApp.model;


namespace EasySaveApp.view
{
    class View
    {
        // Display on the start of the application welcoming the user
        public void Start()
        {
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.WriteLine("|---|         - Welcome to EasySave V1.0 -         |---|");
            Console.WriteLine("|---|----------------------------------------------|---|");
        }
        // Display of the main menu with the different options possible to access (loading a backup, doing a backup, quiting)
        public void MenuScreen()
        {
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.WriteLine("|---|               - MAIN MENU -                  |---|");
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.WriteLine("|---|                                              |---|");
            Console.WriteLine("|---|          0 : Quit EasySave                   |---|");
            Console.WriteLine("|---|          1 : Load a backup job               |---|");
            Console.WriteLine("|---|          2 : Create a backup job             |---|");
            Console.WriteLine("|---|                                              |---|");
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.Write("Enter a number with your keyboard to the corresponding action you want (0/1/2) : ");
        }
        // Display of the submenu when choosing to create a backup job
        public void SubMenu()
        {
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.WriteLine("|---|         - Backup job creating menu -         |---|");
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.WriteLine("|---|                                              |---|");
            Console.WriteLine("|---|          0 : Quit backup menu                |---|");
            Console.WriteLine("|---|          1 : Complete Backup                 |---|");
            Console.WriteLine("|---|          2 : Differential Backup             |---|");
            Console.WriteLine("|---|                                              |---|");
            Console.WriteLine("|---|----------------------------------------------|---|");
            Console.Write("Choose which type of backup you want (1/2) or go back to main menu (0) : ");
        }
        // Display of the first instruction when creating a backup (asking for the name of the backup)
        public void NameScreen()
        {
            Console.WriteLine("What will be the name of the backup job ? (type with keyboard, no special character) : ");
        }
        // Display of the second instruction when creating a backup (asking for the path of the folder that you want to back up)
        public void SourceRepositoryScreen()
        {
            Console.WriteLine("What is the path to the folder you want to backup ? (type or drag and drop your folder into the console) : ");
        }
        // Display of the third instruction when creating a backup (asking for the path of the folder that you want to back up
        public void MirrorRepository()
        {
            Console.WriteLine("What is the path to the mirror folder backup ? (type or drag and drop your folder into the console) : ");
        }
        // Display of the fourth instruction when creating a backup (asking for the path of the folder that you want to back up
        public void TargetRepository()
        {
            Console.WriteLine("What is the path where you want the backup to be saved ? (type or drag and drop your folder into the console) : ");
        }
        // Display of an error occuring
        public void Error(string result)
        {
            Console.WriteLine(result);
        }
        // Display of the instruction of naming an already existing backup file
        public void FileScreen()
        {
            Console.Write("What is the name of the backup job ? (type with keyboard) : ");
        }
        // Display of the instruction when you chose to load a backup file, listing all the existing backups
        public void NameFileScreen()
        {
            Console.Clear();
            Console.WriteLine("Showing the list of all your already existing backups : ");
        }
    }
}
