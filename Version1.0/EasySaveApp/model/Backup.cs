using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV1.model
{
    public class Backup
    {
        public string sourceRepository { get; set; }
        public string targetRepository { get; set; }
        public int type { get; set; }
        public string mirrorRepository { get; set; }
        public string nameToSave { get; set; }

        public Backup(string nameToSave, string sourceRepository, string targetRepository, int type, string mirrorRepository)
        {
            this.nameToSave = nameToSave;
            this.sourceRepository = sourceRepository;
            this.targetRepository = targetRepository;
            this.type = type;
            this.mirrorRepository = mirrorRepository;
        }
    }

}
