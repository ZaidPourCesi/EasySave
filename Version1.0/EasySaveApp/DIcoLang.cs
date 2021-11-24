using System;


namespace DictionaryLangue
{
    //|---|                                                        |---|
    //|---|                                                        |---|

    class Dictionary
    {
        public int NombreDeLangues = 2;
        public string[] langtot = { "English", "Francais" };
        public string[] choix = { "Choose the language", "Choisisez une langue" };

        public string[] confirmLang = { "The application is in english", "L'application est en francais" };

        public string[] p1 = { "- Welcome to EasySave V1.0 -", "- Bienvenue sur EasySave V1.0 -" };
        public string[] p2 = { "|---|                      - MAIN MENU -                     |---|", "|---|                    - MENU PRINCIPAL -                  |---|" };
        public string[] p3 = { "|---|                    0 : Quit EasySave                   |---|", "|---|                   0 : Quitter EasySave                 |---|" };
        public string[] p4 = { "|---|                  1 : Load a backup job                 |---|", "|---|            1 : Charger une tâche de sauvegarde         |---|" };
        public string[] p5 = { "|---|                 2 : Create a backup job                |---|", "|---|             2 : Créer une tâche de sauvegarde          |---|" };
        public string[] p6 = { " Enter a number with your keyboard to the corresponding action you want (0/1/2) : ", " Entrez le chiffre correspondant à l'action que vous souhaitez effectuer (0/1/2) : " };
        public string[] p7 = { "|---|              - Backup job creating menu -              |---|", "|---|      - Menu de création de tâche de sauvegarde -       |---|" };
        public string[] p8 = { "|---|                 0 : Quit backup menu                   |---|", "|---|          0 : Quitter le menu de sauvegarde             |---|" };
        public string[] p9 = { "|---|                  1 : Complete Backup                   |---|", "|---|               1 : Sauvegarde complète                  |---|" };
        public string[] p10 = { "|---|                2 : Differential Backup                 |---|", "|---|            2 : Sauvegarde différentielle               |---|" };
        public string[] p11 = { " Choose which type of backup you want (1/2) or go back to main menu (0) : ", " Choisissez le type de sauvegarde que vous souhaitez (1/2) ou revenez au menu principal (0) : " };
        public string[] p12 = { " What will be the name of the backup job ? (type with keyboard, no special character) : ", " Quel sera le nom de la tâche de sauvegarde ? (tapez au clavier, pas de caractère spécial) : " };
        public string[] p13 = { " What is the path to the folder you want to backup ? (type or drag and drop your folder into the console) : ", " Quel est le chemin du dossier que vous souhaitez sauvegarder ? (tapez ou glissez-déposez votre dossier dans la console) : " };
        public string[] p14 = { " What is the path to the mirror folder backup ? (type or drag and drop your folder into the console) : ", " Quel est le chemin d'accès à la sauvegarde du dossier miroir ? (tapez ou glissez-déposez votre dossier dans la console) : " };
        public string[] p15 = { " What is the path where you want the backup to be saved ? (type or drag and drop your folder into the console) : ", " Quel est le chemin où vous voulez que la sauvegarde soit enregistrée ? (tapez ou glissez-déposez votre dossier dans la console) : " };
        public string[] p16 = { " What is the name of the backup job ? (type with keyboard) : ", " Quel est le nom de la tâche de sauvegarde ? (taper au clavier) : " };
        public string[] p17 = { " Showing the list of all your already existing backups : ", " Affichage de la liste de toutes les sauvegardes existantes : " };


        public string[] p18 = { "Incorect Path", "Chemin d'accès incorrecte" };
        public string[] p19 = { "You already have 5 backups. Please delete a backup job so you can create another one ", " Vous avez déjà 5 sauvegardes. Veuillez en supprimer une pour pourvoir en créer une autre " };
        public string[] p20 = { "  ", "  " };

        public int ChooseLanguage()
        {
            int langNum = 0;
            Dictionary Dico = new Dictionary();
            Console.WriteLine(Dico.choix[langNum]);

            for (int i = 0; i < Dico.NombreDeLangues; i++)
            {
                Console.WriteLine(i + ") : " + Dico.langtot[i]);
            }


            langNum = Int32.Parse(Console.ReadLine());

            if (langNum >= Dico.NombreDeLangues)
            {
                Console.WriteLine("ERROR : LANGUAGE NOT CORRECT, DEFAULT : ENGLISH");
                langNum = 0;

            }

            Console.WriteLine(Dico.confirmLang[langNum]);
            return (langNum);
        }

    }
}