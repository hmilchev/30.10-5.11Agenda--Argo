using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaper6_Task18
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {


                int side = int.Parse(Console.ReadLine());
                bool movingRight = true;
                bool movingDown = false;
                bool movingLeft = false;
                bool movingUp = false;
                int x = 0;
                int y = 0;
                int cellCounter = 2;
                int decreaseCounter = 0; //once it reaches 3, decrese of cells-adding must start, to not override old cells
                int maxTurnsCounter = side; //once it reach 0, the matrix is done
                int currentTurnsCounter = side;
                bool fixedLastMove = false;
                int[,] matrix = new int[side, side];
                while (maxTurnsCounter != 0)
                {
                    for (int i = 1; i < maxTurnsCounter; i++) //fill a cell cycle
                    {
                        if (movingRight)
                        {
                            x++;
                            matrix[y, x] = cellCounter;

                        }
                        if (movingDown)
                        {
                            y++;
                            matrix[y, x] = cellCounter;

                        }
                        if (movingLeft)
                        {
                            x--;
                            matrix[y, x] = cellCounter;


                        }
                        if (movingUp)
                        {
                            y--;
                            matrix[y, x] = cellCounter;

                        }
                        cellCounter++;
                    }
                    if (movingRight) //change direction ifs
                    {
                        movingRight = false;
                        movingDown = true;
                        // x--;
                    }
                    else if (movingDown)
                    {
                        movingDown = false;
                        movingLeft = true;
                        // y--;
                    }
                    else if (movingLeft)
                    {
                        movingLeft = false;
                        movingUp = true;
                        // y++;

                    }
                    else if (movingUp)
                    {
                        movingUp = false;
                        movingRight = true;
                        //  y++;

                    }

                    if (decreaseCounter < 3)
                    {
                        decreaseCounter++;
                    }
                    if (decreaseCounter == 3)

                    {
                        if (fixedLastMove == false)
                        {
                            maxTurnsCounter--;
                            fixedLastMove = true;
                        }
                        else
                        {
                            fixedLastMove = false;
                        }
                    }
                }
                matrix[0, 0] = 1;
                for (int row = 0; row < side; row++)
                {
                    for (int col = 0; col < side - 1; col++)
                        Console.Write(matrix[row, col] + "   ");
                    Console.WriteLine(matrix[row, side - 1]);
                }
            }
        }
    }
}
