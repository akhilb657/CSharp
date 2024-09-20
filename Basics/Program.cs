using System;

namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intsToCompress = new int[] {1, 2, 3, 4, 5, 6, 45, 11, 22, 31};

            int totalValue = 0;

            foreach (int intForCompression in intsToCompress)
            {
                if(intForCompression > 40)
                {
                    totalValue += intForCompression;
                }
            }

            Console.WriteLine(totalValue);


            DateTime startTime = DateTime.Now;

            totalValue = intsToCompress[0] + intsToCompress[1] + intsToCompress[2] + intsToCompress[3] + intsToCompress[4] + intsToCompress[5] + intsToCompress[6] + intsToCompress[7] + intsToCompress[8] + intsToCompress[9];

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue); // 129

            totalValue = 0;

            startTime = DateTime.Now;

            for(int i = 0; i<intsToCompress.Length; i++)
            {
                totalValue += intsToCompress[i];
            }
            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue);

           

            startTime = DateTime.Now;

            

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue);

            totalValue = 0;

            startTime = DateTime.Now;

            int index = 0;

            while(index  < intsToCompress.Length)
            {
                totalValue += intsToCompress[index];
                index++;
            }

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue);

            totalValue = 0;

             

            index = 0;

            do
            {
                totalValue += intsToCompress[index];

                index++;
            } 
            while(index  < intsToCompress.Length);

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue);

            startTime = DateTime.Now;

            totalValue = intsToCompress.Sum();

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue);

            startTime = DateTime.Now;

            totalValue = GetSum(intsToCompress);

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

            Console.WriteLine(totalValue);

            int[] nums = new int[] { 10, 20, 30, 40 , 50 , 60};

            totalValue = GetSum(nums);

            Console.WriteLine(totalValue);


        }

        static private int GetSum(int[] intsToCompress)
        {
            // int[] intsToCompress = new int[] {1, 2, 3, 4, 5, 6, 45, 11, 22, 31};
            int totalValue = 0;
            foreach (int intForCompression in intsToCompress)
            {  
                totalValue += intForCompression; 
            }
            return totalValue;
        }
    }
}