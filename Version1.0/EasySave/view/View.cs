using System;
using System.Collections.Generic;
using System.Text;
using EasySaveV1.controller;
using EasySaveV1.model;
using DictionaryLangue;

namespace EasySaveV1.view
{
    class View
    {
        // Display on the start of the application welcoming the user
        public void Start()
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.WriteLine("|---|              - Welcome to EasySave V1.0 -              |---|");
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            
        }
        // Display of the main menu with the different options possible to access (loading a backup, doing a backup, quiting)
        public void MenuScreen(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.WriteLine("|---|                                                        |---|");
            Console.WriteLine(dico.p2[numLang]);
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.WriteLine(dico.p3[numLang]);
            Console.WriteLine(dico.p4[numLang]);
            Console.WriteLine(dico.p5[numLang]);
            Console.WriteLine("|---|                                                        |---|");
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.Write(dico.p6[numLang]);
        }
        // Display of the submenu when choosing to create a backup job
        public void SubMenu(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.WriteLine("|---|                                                        |---|");
            Console.WriteLine(dico.p7[numLang]);
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.WriteLine("|---|                                                        |---|");
            Console.WriteLine(dico.p8[numLang]);
            Console.WriteLine(dico.p9[numLang]);
            Console.WriteLine(dico.p10[numLang]);
            Console.WriteLine("|---|                                                        |---|");
            Console.WriteLine("|---|--------------------------------------------------------|---|");
            Console.Write(dico.p11[numLang]);
        }
        // Display of the first instruction when creating a backup (asking for the name of the backup)
        public void NameScreen(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine(dico.p12[numLang]);
        }
        // Display of the second instruction when creating a backup (asking for the path of the folder that you want to back up)
        public void SourceRepositoryScreen(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine(dico.p13[numLang]);
        }
        // Display of the third instruction when creating a backup (asking for the path of the folder that you want to back up
        public void MirrorRepository(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine(dico.p14[numLang]);
        }
        // Display of the fourth instruction when creating a backup (asking for the path of the folder that you want to back up
        public void TargetRepository(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine(dico.p15[numLang]);
        }
        // Display of an error occuring
        public void Error(string result)
        {
            Console.WriteLine(result);
        }
        // Display of the instruction of naming an already existing backup file
        public void FileScreen(int numLang)
        {
            Dictionary dico = new Dictionary();
            Console.WriteLine(dico.p16[numLang]);
        }
        // Display of the instruction when you chose to load a backup file, listing all the existing backups
        public void NameFileScreen(int numLang)
        {
            Console.Clear();
            Dictionary dico = new Dictionary();
            Console.WriteLine(dico.p17[numLang]);
        }
    }
}
