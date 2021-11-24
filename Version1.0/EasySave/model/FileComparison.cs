using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV1.model
{
    // FileComparison is the class used for the differential backup
    // It uses Equality Comparer interface for the System.IO.FileInfo class that is in System.Collections.Generic library.
    // It helps comparing objects (here files) to see if they are equal.
    // It also permits the hash comparison of the backup files.

    class FileComparison : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
    {
        public FileComparison() { } // Default constructor
        public int GetHashCode(System.IO.FileInfo file) // GetHashCode is used to get the hash code info from the file we want
        {
            string hashFile = $"{file.Name}{file.Length}";
            return hashFile.GetHashCode(); // Return of the hash code to compare  
        }

        public bool Equals(System.IO.FileInfo file1, System.IO.FileInfo file2) // Test if the two files are equals
        {
            return (file1.Name == file2.Name &&
                    file1.Length == file2.Length); // Returns 1 if files 1 and 2 names and size are equals, 0 if not
        }
    }
}
