using System;
using System.Collections.Generic;
using System.Text;

namespace scanner
{
    class helper
    {
        public static string CharCombine(string my_code, int start,int end)
        {int j=0;
            // Combine chars into array
            char[] arr = new char[end-start];
            for (int i = start; end <= start; i++)
            {
                arr[j++] = my_code[i];
            }
           
            // Return new string key
            return new string(arr);
        }
    }
}

