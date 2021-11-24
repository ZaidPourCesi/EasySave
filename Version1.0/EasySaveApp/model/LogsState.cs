using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveApp.model
{
   class LogsState
    {
        // The class LogsState is used to take note of few informations about the backups to write it into a JSON file :
        // target path, source path, name, date, duration, state,  and size
        public string nameToSave { get; set; } // Declaration of the setter/getter for the name of the backup file
        public string backupDate { get; set; } // Declaration of the setter/getter for the date when the backup occured
        public bool saveState { get; set; } // Declaration of the setter/getter for the savestate (active/inactive)
        public string sourceRepository { get; set; } // Declaration of the setter/getter for the source repository path
        public string targetRepository { get; set; } // Declaration of the setter/getter for the target repository path
        public float totalRepository { get; set; } // Declaration of the setter/getter for total repository
        public long totalSize { get; set; } // Declaration of the setter/getter for the total size of the backup
        public float progress { get; set; } // Declaration of the setter/getter for the progression while a backup is in creation
        public long repositoryRest { get; set; } // Declaration of the setter/getter for the target repository path
        public long totalSizeLeft { get; set; } // Declaration of the setter/getter for the total size left to do for the backup
        // The fction below serve the purpose of setting the backup name of the LogsState attribute
        public LogsState(string nameToSave)
        {
            nameToSave = nameToSave;
        }
    }
}
