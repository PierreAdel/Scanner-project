using System;

namespace scanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner scan = new Scanner("INT X  := 54 /**EDFSBGDR**/=");
            scan.Start_Scan();
        }
    }
}
