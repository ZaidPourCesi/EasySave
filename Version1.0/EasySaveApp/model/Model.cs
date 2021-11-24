using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace EasySaveV1.model
{
    class Model
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Declaration of all variables and properties
        public int checkdatabackup;
        private string serializeObj;
        public string backupListFile = System.Environment.CurrentDirectory + @"\Works\";
        public string stateFile = System.Environment.CurrentDirectory + @"\State\";
        public LogsState LogsState { get; set; }
        public string nameStateFile { get; set; }
        public string backupNameState { get; set; }
        public string sourceRepository { get; set; }
        public int nbfilesmax { get; set; }
        public int nbfiles { get; set; }
        public long size { get; set; }
        public float progs { get; set; }
        public string targetRepository { get; set; }
        public string nameToSave { get; set; }
        public int type { get; set; }
        public string sourceFile { get; set; }
        public string typeString { get; set; }
        public long totalSize { get; set; }
        public TimeSpan timeTransfert { get; set; }
        public string userMenuInput { get; set; }
        public string mirrorRepository { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Model()
        {
            userMenuInput =  " ";

            if (!Directory.Exists(backupListFile)) //Check if the folder is created
            {
                DirectoryInfo di = Directory.CreateDirectory(backupListFile); //Function that creates the folder
            }
            backupListFile += @"backupList.json"; //Create a JSON file

            if (!Directory.Exists(stateFile))//Check if the folder is created
            {
                DirectoryInfo di = Directory.CreateDirectory(stateFile); //Function that creates the folder
            }
            stateFile += @"state.json"; //Create a JSON file


        }

        public void CompleteSave(string inputpathsave, string inputDestToSave, bool copyDir, bool verif) //Function for full folder backup
        {
            LogsState = new LogsState(nameStateFile);
            this.LogsState.saveState = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //Starting the timed for the log file

            DirectoryInfo dir = new DirectoryInfo(inputpathsave);  // Get the subdirectories for the specified directory.

            if (!dir.Exists) //Check if the file is present
            {
                 throw new DirectoryNotFoundException("ERROR : Directory Not Found ! " + inputpathsave);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(inputDestToSave); // If the destination directory doesn't exist, create it.  

            FileInfo[] files = dir.GetFiles(); // Get the files in the directory and copy them to the new location.

            if (!verif) //  Check for the status file if it needs to reset the variables
            {
                totalSize = 0;
                nbfilesmax = 0;
                size = 0;
                nbfiles = 0;
                progs = 0;

                foreach (FileInfo file in files) // Loop to allow calculation of files and folder size
                {
                    totalSize += file.Length;
                    nbfilesmax++;
                }
                foreach(DirectoryInfo subdir in dirs) // Loop to allow calculation of subfiles and subfolder size
                {
                    FileInfo[] Maxfiles = subdir.GetFiles();
                    foreach(FileInfo file in Maxfiles)
                    {
                        totalSize += file.Length;
                        nbfilesmax++;
                    }
                }

            }

            //Loop that allows to copy the files to make the backup
            foreach (FileInfo file in files) 
            {
                string tempPath = Path.Combine(inputDestToSave, file.Name);

                if(size > 0)
                {
                    progs = ((float)size / totalSize) * 100;
                }

                //Systems which allows to insert the values ​​of each file in the report file.
                LogsState.sourceRepository = Path.Combine(inputpathsave, file.Name);
                LogsState.targetRepository = tempPath;
                LogsState.totalSize = nbfilesmax;
                LogsState.totalRepository = totalSize;
                LogsState.totalSizeLeft = totalSize - size;
                LogsState.repositoryRest = nbfilesmax - nbfiles;
                LogsState.progress = progs;

                UpdateStatefile(); //Call of the function to start the state file system

                file.CopyTo(tempPath, true); //Function that allows you to copy the file to its new folder.
                nbfiles++;
                size += file.Length;

            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copyDir)  
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(inputDestToSave, subdir.Name);
                    CompleteSave(subdir.FullName, tempPath, copyDir, true);
                }   
            }
            //System which allows the values ​​to be reset to 0 at the end of the backup
            LogsState.totalSize = totalSize;
            LogsState.sourceRepository = null;
            LogsState.targetRepository = null;
            LogsState.totalRepository = 0;
            LogsState.totalSize = 0;
            LogsState.totalSizeLeft = 0;
            LogsState.repositoryRest = 0;
            LogsState.progress = 0;
            LogsState.saveState = false;

            UpdateStatefile(); //Call of the function to start the state file system

            stopwatch.Stop(); //Stop the stopwatch
            this.timeTransfert = stopwatch.Elapsed; // Transfer of the chrono time to the variable
        }

        public void DifferentialSave(string pathA, string pathB, string pathC) // Function that allows you to make a differential backup
        {
            LogsState = new LogsState(nameStateFile); //Instattation of the method
            Stopwatch stopwatch = new Stopwatch(); // Instattation of the method
            stopwatch.Start(); //Starting the stopwatch

            LogsState.saveState = true;
            totalSize = 0;
            nbfilesmax = 0;

            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(pathA);
            System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(pathB);

            // Take a snapshot of the file system.  
            IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //A custom file comparer defined below  
            FileComparison myFileCompare = new FileComparison();

            var queryList1Only = (from file in list1 select file).Except(list2, myFileCompare);
            size = 0;
            nbfiles = 0;
            progs = 0;

            foreach (var v in queryList1Only)
            {
                totalSize += v.Length;
                nbfilesmax++;

            }

            //Loop that allows the backup of different files
            foreach (var v in queryList1Only)
            {
                string tempPath = Path.Combine(pathC, v.Name);
                //Systems which allows to insert the values ​​of each file in the report file.
                LogsState.sourceRepository = Path.Combine(pathA, v.Name);
                LogsState.targetRepository = tempPath;
                LogsState.totalSize = nbfilesmax;
                LogsState.totalRepository = totalSize;
                LogsState.totalSizeLeft = totalSize - size;
                LogsState.repositoryRest = nbfilesmax - nbfiles;
                LogsState.progress = progs;

                UpdateStatefile();//Call of the function to start the state file system
                v.CopyTo(tempPath, true); //Function that allows you to copy the file to its new folder.
                size += v.Length;
                nbfiles++;
            }

            //System which allows the values ​​to be reset to 0 at the end of the backup
            LogsState.sourceRepository = null;
            LogsState.targetRepository = null;
            LogsState.totalRepository = 0;
            LogsState.totalSize = 0;
            LogsState.totalSizeLeft = 0;
            LogsState.repositoryRest = 0;
            LogsState.progress = 0;
            LogsState.saveState = false;
            UpdateStatefile();//Call of the function to start the state file system

            stopwatch.Stop(); //Stop the stopwatch
            this.timeTransfert = stopwatch.Elapsed; // Transfer of the chrono time to the variable
        }

        private void UpdateStatefile()//Function that updates the status file.
        {
            List<LogsState> stateList = new List<LogsState>();
            this.serializeObj = null;
            if (!File.Exists(stateFile)) //Checking if the file exists
            {
                File.Create(stateFile).Close();
            }

            string jsonString = File.ReadAllText(stateFile);  //Reading the json file

            if (jsonString.Length != 0) //Checking the contents of the json file is empty or not
            {
                LogsState[] list = JsonConvert.DeserializeObject<LogsState[]>(jsonString); //Derialization of the json file

                foreach (var obj in list) // Loop to allow filling of the JSON file
                {
                    if(obj.nameToSave == this.nameStateFile) //Verification so that the name in the json is the same as that of the backup
                    {
                        obj.sourceRepository = this.LogsState.sourceRepository;
                        obj.targetRepository = this.LogsState.targetRepository;
                        obj.totalRepository = this.LogsState.totalRepository;
                        obj.totalSize = this.LogsState.totalSize;
                        obj.repositoryRest = this.LogsState.repositoryRest;
                        obj.totalSizeLeft = this.LogsState.totalSizeLeft;
                        obj.progress = this.LogsState.progress;
                        obj.backupDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        obj.saveState = this.LogsState.saveState;
                    }

                    stateList.Add(obj); //Allows you to prepare the objects for the json filling

                }

                this.serializeObj = JsonConvert.SerializeObject(stateList.ToArray(), Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file

                File.WriteAllText(stateFile, this.serializeObj); //Function to write to JSON file
            }


        }

        public void UpdateLogFile(string savename, string sourcedir, string targetdir)//Function to allow modification of the log file
        {
            Stopwatch stopwatch = new Stopwatch();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeTransfert.Hours, timeTransfert.Minutes, timeTransfert.Seconds, timeTransfert.Milliseconds / 10); //Formatting the stopwatch for better visibility in the file
            
            Logs datalogs = new Logs //Apply the retrieved values ​​to their classes
            {
                nameToSave = savename,
                sourceRepository = sourcedir,
                targetRepository = targetdir,
                backupDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                totalSize = totalSize,
                transactionTime = elapsedTime
            };

            string path = System.Environment.CurrentDirectory; //Allows you to retrieve the path of the program environment
            var directory = System.IO.Path.GetDirectoryName(path); // This file saves in the project: \EasySaveApp\bin

            string serializeObj = JsonConvert.SerializeObject(datalogs, Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.AppendAllText(directory + @"DailyLogs_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json", serializeObj); //Function to write to log file

            stopwatch.Reset(); // Reset of stopwatch
        }
       
        public void AddSave(Backup backup) //Function that creates a backup job
        {
            List<Backup> backupList = new List<Backup>();
            this.serializeObj = null; 

            if (!File.Exists(backupListFile)) //Checking if the file exists
            {
                File.WriteAllText(backupListFile, this.serializeObj);
            }

            string jsonString = File.ReadAllText(backupListFile); //Reading the json file

            if (jsonString.Length != 0) //Checking the contents of the json file is empty or not
            {
                Backup[] list = JsonConvert.DeserializeObject<Backup[]>(jsonString); //Derialization of the json file
                foreach ( var obj in list) //Loop to add the information in the json
                {
                    backupList.Add(obj);
                }
            }
            backupList.Add(backup); //Allows you to prepare the objects for the json filling

            this.serializeObj = JsonConvert.SerializeObject(backupList.ToArray(), Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.WriteAllText(backupListFile, this.serializeObj); // Writing to the json file

            LogsState = new LogsState(this.nameToSave); //Class initiation

            LogsState.backupDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); //Adding the time in the variable
            AddState(); //Call of the function to add the backup in the report file.
        }

        public void AddState() //Function that allows you to add a backup job to the report file.
        {
            List<LogsState> stateList = new List<LogsState>();
            this.serializeObj = null;

            if (!File.Exists(stateFile)) //Checking if the file exists
            {
                File.Create(stateFile).Close();
            }

            string jsonString = File.ReadAllText(stateFile); //Reading the json file

            if (jsonString.Length != 0)
            {
                LogsState[] list = JsonConvert.DeserializeObject<LogsState[]>(jsonString); //Derialization of the json file
                foreach (var obj in list) //Loop to add the information in the json
                {
                    stateList.Add(obj);
                }
            }
            this.LogsState.saveState = false;
            stateList.Add(this.LogsState); //Allows you to prepare the objects for the json filling

            this.serializeObj = JsonConvert.SerializeObject(stateList.ToArray(), Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.WriteAllText(stateFile, this.serializeObj);// Writing to the json file


        }

        public void LoadSave(string backupname) //Function that allows you to load backup jobs
        {
            Backup backup = null;
            this.totalSize = 0;
            backupNameState = backupname;

            string jsonString = File.ReadAllText(backupListFile); //Reading the json file


            if (jsonString.Length != 0) //Checking the contents of the json file is empty or not
            {
                Backup[] list = JsonConvert.DeserializeObject<Backup[]>(jsonString);  //Derialization of the json file
                foreach (var obj in list)
                {
                    if(obj.nameToSave == backupname) //Check to have the correct name of the backup
                    {
                        backup = new Backup(obj.nameToSave, obj.sourceRepository, obj.targetRepository, obj.type, obj.mirrorRepository); //Function that allows you to retrieve information about the backup
                    }
                }
            }

            if(backup.type == 1) //If the type is 1, it means it's a full backup
            {
                nameStateFile = backup.nameToSave;
                CompleteSave(backup.sourceRepository, backup.targetRepository, true, false); //Calling the function to run the full backup
                UpdateLogFile(backup.nameToSave, backup.sourceRepository, backup.targetRepository); //Call of the function to start the modifications of the log file
                Console.WriteLine("Saved Successfull !"); //Satisfaction message display
            }
            else //If this is the wrong guy then, it means it's a differential backup
            {
                nameStateFile = backup.nameToSave;
                DifferentialSave(backup.sourceRepository, backup.mirrorRepository, backup.targetRepository); //Calling the function to start the differential backup
                UpdateLogFile(backup.nameToSave, backup.sourceRepository, backup.targetRepository); //Call of the function to start the modifications of the log file
                Console.WriteLine("Saved Successfull !"); //Satisfaction message display
            }

        }

        public void CheckDataFile()  // Function that allows to count the number of backups in the json file of backup jobs
        {
            checkdatabackup = 0;

            if (File.Exists(backupListFile)) //Check on file exists
            {
                string jsonString = File.ReadAllText(backupListFile);//Reading the json file
                if (jsonString.Length != 0)//Checking the contents of the json file is empty or not
                {
                    Backup[] list = JsonConvert.DeserializeObject<Backup[]>(jsonString); //Derialization of the json file
                    checkdatabackup = list.Length; //Allows to count the number of backups
                }
            }
        }

    }

}
