using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Timers;
using CryptoSoftware;

namespace CryptoSoftware
{
    class Chiffrement
    {
        public string inpoute;
        public string outpoute;
        public string sourceFileName;
        public string targetFileName;
        public string configFileName;
        public long key;
        public Stopwatch stopwatch;
        /*
        public Chiffrement(String a, String b)
        {
            stopwatch = new Stopwatch();
            sourceFileName = a;
            targetFileName = b;
            configFileName = string.Empty;
            inpoute = "";
            outpoute = "";
            key = 0;
        }
        */
        public Chiffrement(String a, String b, long c)
        {
            stopwatch = new Stopwatch();
            sourceFileName = a;
            targetFileName = b;
            configFileName = string.Empty;
            inpoute = "";
            outpoute = "";
            key = c;
        }

        public void EncryptDecrypt()
        {
            StringBuilder inSb = new StringBuilder(inpoute);
            StringBuilder outSb = new StringBuilder(inpoute.Length);
            char c;
            for (int i = 0; i < inpoute.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key);
                outSb.Append(c);
            }
            outpoute = outSb.ToString();
        }
    }
}
