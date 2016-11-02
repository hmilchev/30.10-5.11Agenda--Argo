using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* TODO
1.Bugs(V-fixed;)
200 Двеста и; V
101 Едноста и едно V
310 Триста и еднодесет V
20-100 including - empty V


Optional - check if its a number X  
*/
namespace Champter5_Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter you number [0-999] , numbers only(else throws exception).");
            Console.WriteLine("If input out of range, the program will use only the first 3 digits!");
            while (true)
            {

                int n = int.Parse(Console.ReadLine());
                ConvertNumToBulgarian(n);
            }


        }
        static void ConvertNumToBulgarian(int num)
        {
            string result = "";
            bool oneDigitNum = false;
            if (num < 10) //numbers under 10
            {
                oneDigitNum = true;
                result = ConvertSingleDigitToBulgarian(num, oneDigitNum);

            }

            //else if (num < 20)
            //{
            //    int secondDigit = num % 10;
            //    result = ConvertSingleDigitToBulgarian(secondDigit, oneDigitNum) + "надесет";
            //}
            else if (num > 9)
            {
                oneDigitNum = false;
                //get an int for every digit:
                string numString = num + "";
                if (num < 100)
                {
                    numString = ("0" + numString);
                }
                int firstDigit = int.Parse(numString[0] + "");//added +"", parse can't use a char,needs a string.
                int secondDigit = int.Parse(numString[1] + "");
                int thirdDigit = int.Parse(numString[2] + "");

                string firstDigitResult = "";
                string secondDigitResult = "";
                string thirdDigitResult = "";

                string hungredsInBulgarian;
                if (firstDigit < 4)  // we say "две-ста" and "три-ста" , but "четири-стотин" and "пет-стотин"
                {
                    hungredsInBulgarian = "ста";
                }
                else
                {
                    hungredsInBulgarian = "стотин";
                }
                //FIRST Digit result work:
                //if the numbers is below 100 , we leave the firstDigitResult an empty string
                if (firstDigit > 0)
                {
                    firstDigitResult = ConvertSingleDigitToBulgarian(firstDigit, true) + hungredsInBulgarian;
                }
                //SECOND digit result work:
                if (secondDigit > 0)
                {
                    secondDigitResult = ConvertSingleDigitToBulgarian(secondDigit, false).ToLower() + "десет";
                }
                //THIRD digit result work:
                if (thirdDigit > 0)
                {
                    thirdDigitResult = ConvertSingleDigitToBulgarian(thirdDigit, true).ToLower();

                }

                //Connection work - whats between the digit representation starts here:
                string connection1 = "";
                string connection2 = "";
                string active = " и ";
                string space = " ";
                //000 - both conncetions empty - Нула
                //001 <n <21 - both conncetions empty - Седемнадесет
                //021 <n <100 -connection1 - empty; conncetion 2 active;
                if (firstDigit == 0 && secondDigit != 0 && thirdDigit != 0)
                { connection1 = ""; connection2 = active; } // - Осемдесет и две
                //20,30,50 etc -connection1 - empty; conncetion 2 empty;
                //100,200,300 etc - both conncetions empty - Триста
                //110,220 etc - connection1 active
                else if (firstDigit != 0 && secondDigit != 0 && thirdDigit == 0)
                { connection1 = active; connection2 = ""; }  //Двеста и тридесет
                //101,202 etc - connection 2 active
                else if (firstDigit != 0 && secondDigit == 0 && thirdDigit != 0)
                { connection1 = ""; connection2 = active; } //Двеста И шест
                //345,555 etc
                else if (firstDigit != 0 && secondDigit != 0 && thirdDigit != 0)
                { connection1 = space; connection2 = active; } //Двеста седемдесет И шест

                //exception 100
                if (firstDigit == 1)
                {
                    firstDigitResult = "Сто";
                }

                //exception x10 - (10,210,610 etc.)
                if (secondDigit == 1 && thirdDigit == 0)
                {
                    secondDigitResult = "десет";
                    if (firstDigit != 0) //we add " и " if the nubmer is 210, 310, but not if its 10
                    {
                        connection1 = active;
                    }
                    thirdDigitResult = "";
                    connection2 = "";


                }
                //exception [x11 - x19] (14,217,912 etc.) we dont say "Десет и седем", but "Седемнадесет"
                if (secondDigit == 1 && thirdDigit != 0)
                {
                    secondDigit = num % 10;
                    secondDigitResult = ConvertSingleDigitToBulgarian(secondDigit, oneDigitNum).ToLower() + "надесет";
                    if (firstDigit != 0) //we add " и " if the nubmer is 215, 316, but not if its 17,18,20
                    {
                        connection1 = active;
                    }
                    thirdDigitResult = "";
                    connection2 = "";
                }


                result = firstDigitResult + connection1 + secondDigitResult + connection2 + thirdDigitResult;

                //making the first letter to upper manualy ( Qustion? Cant find simple method to do it.)
                string firstLetter = result[0] + "";
                string upperFirstLetter = firstLetter.ToUpper();
                string otherLetters = result.Substring(1);
                result = upperFirstLetter + otherLetters;
            }
            Console.WriteLine(result);
        }
        static string ConvertSingleDigitToBulgarian(int input, bool oneDigitNum)
        {
            string result = "";
            switch (input)
            {
                case 0: result = "Нула"; break;
                case 1:
                    if (oneDigitNum) { result = "Едно"; break; } //we say "Едно" , but we also say "Еди-надесет"
                    else { result = "Еди"; break; }

                case 2:   // we say "две"  but we also say "два-десет"
                    if (oneDigitNum) { result = "Две"; break; }
                    else { result = "Двa"; break; }


                case 3: result = "Три"; break;
                case 4: result = "Четири"; break;
                case 5: result = "Пет"; break;
                case 6: result = "Шест"; break;
                case 7: result = "Седем"; break;
                case 8: result = "Осем"; break;
                case 9: result = "Девет"; break;
            }
            return result;
        }
    }
}
