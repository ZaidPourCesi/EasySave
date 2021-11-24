    using System;
using System.Collections.Generic;
using System.Text;
using EasySaveApp.controller;
using EasySaveApp.model;


namespace EasySaveApp.view
{
    class View
    {
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
        //Display on the console when you enter the name of the save
        public void NameScreen()
        {
            Console.WriteLine("Please enter the name of your backup : ");
        }
        //Display on the console when you have to enter the path of the folder that you want to back up
        public void SourceRepositoryScreen()
        {
            Console.WriteLine("Please enter the path of the folder you want to back up. [ DRAG AND DROP YOUR FOLDER ] :");
        }
        //Display on the console when you have to enter the path of the folder that you want to back up
        public void TargetRepository()
        {
            Console.WriteLine("Please enter the destination path for the backup. [ DRAG AND DROP YOUR FOLDER ] :");
        }

        public void MirrorRepository()
        {
            Console.WriteLine("Please enter the path of the folder mirror backup. [ DRAG AND DROP YOUR FOLDER ] :");
        }
        //Display on the console an error message
        public void Error(string result)
        {
            Console.WriteLine(result);
        }
        //Display on the console when you have to enter the name of backup
        public void FileScreen()
        {
            Console.Write("Please enter the name of your backup : ");
        }
        //Display on the console when you have to enter the name of backups
        public void NameFileScreen()
        {
            Console.Clear();
            Console.WriteLine("Here are the names of your backups : ");
        }
    }
}