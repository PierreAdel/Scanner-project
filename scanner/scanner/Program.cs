﻿using System;

namespace scanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner scan = new Scanner("+INT/**EFWRD**/+-");
            scan.Start_Scan();
        }
    }
}
