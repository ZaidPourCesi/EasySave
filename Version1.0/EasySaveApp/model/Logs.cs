using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace EasySaveV1.model
{
    // The class log is used to take note of few informations about the backups :
    // target path, source path, name, date, duration and size
    class Logs
    {
        public string sourceRepository { get; set; } // Declaration of the setter/getter for the target repository path
        public string targetRepository { get; set; } // Declaration of the setter/getter target repository path
        public string nameToSave { get; set; } // Declaration of the setter/getter for the name of the backup
        public string backupDate { get; set; } // Declaration of the setter/getter for the date of the backup
        public string transactionTime { get; set; } // Declaration of the setter/getter for the time of the backup
        public long totalSize { get; set; } // Declaration of the setter/getter for the total size of the file
    }
}