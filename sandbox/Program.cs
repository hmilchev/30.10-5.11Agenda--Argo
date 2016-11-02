using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the size of your array");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("create a sorted array");
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"type a num");
                }
                else
                {
                    Console.WriteLine($"type a num bigger than {arr[i - 1]} cells remaining > {n - i}");
                }
                int cell = int.Parse(Console.ReadLine());
                arr[i] = cell;

            }

            Console.WriteLine($"type the digit, which location u want to find(0<n<{n}");
            int target = int.Parse(Console.ReadLine());
            int start = 0;
            int end = arr.Length;
            int result = binarySearch(target, arr, start, end);
            if (result != -1)
            {
                Console.WriteLine($"the position of your num is {result}");
            }



        }
        static int binarySearch(int target, int[] arr, int start, int end)
        {
            while (start <= end)
            {
                int middle = (start + end) / 2;
                if (arr[middle] == target)
                {
                    return middle;
                }
                else if (arr[middle] > target)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            Console.WriteLine("Your numbers is not in the array");
            return -1;
        }
    }

}
