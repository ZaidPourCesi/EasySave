using System;


namespace CryptoSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Chiffrement encryption = new Chiffrement(args[0], args[1], Int64.Parse(args[2]));
                 Controller controllero = new Controller();
                 View lavue = new View();
                 controllero.EncryptionRoutine(encryption, lavue);
            }
            catch
            {
                View lavue = new View();
                lavue.ShowErrorInitializing();
            }

            //Environment.Exit(0);

            //return (encryption.stopwatch.ElapsedMilliseconds);
            //}
            //catch
            //{
            //return (-1);
            //}    
        }
    }
}
