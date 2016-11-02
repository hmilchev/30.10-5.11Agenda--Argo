using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Chapter6_Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {


                //TODO: google how to convert facturiel formulas to simpler, in case really huge numbers are used
                //the current code doesnt work at above 25 000(takes around 15 seconds)

                //първите числа на Каталан са: 0 => 1 , 1 => 1 , 2 => 2 , 3 => 5 , 4 => 14 , 5 => 42 , 6 => 132 , 7 => 429
                int num = int.Parse(Console.ReadLine());
                BigInteger catalanNum = (CalcFacturiel(2 * num)) / ((CalcFacturiel(num + 1) * (CalcFacturiel(num))));
                Console.WriteLine(catalanNum);
            }
        }


        static BigInteger CalcFacturiel(int n)
        {
            BigInteger nFact = 1; //umnojnenie, ne setvai 0
            while (n > 1)
            {
                nFact *= n;
                n--;
            }
            return nFact;
        }
    }
}
