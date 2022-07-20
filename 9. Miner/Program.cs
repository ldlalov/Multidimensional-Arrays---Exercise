using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int[] possition = new int[2];
            string[,] field = new string[dimentions, dimentions];//start creating the matrix
            int coalCount = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                    if (field[row,col].Equals("s"))
                    {
                        possition[0] = row;
                        possition[1] = col;
                    }
                    if (field[row,col].Equals("c"))
                    {
                        coalCount++;
                    }
                }
            }//end creating the matrix
            //start executing commands
            int collected = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "up":
                        if (possition[0]-1>=0)
                        {
                        possition[0] -= 1;
                        }
                        if (field[possition[0], possition[1]].Equals("c"))
                        {
                            collected++;
                            field[possition[0], possition[1]] = "*";
                        }
                            break;
                    case "down":
                        if (possition[0] + 1 < field.GetLength(0))
                        {
                            possition[0] += 1;
                        }
                        if (field[possition[0], possition[1]].Equals("c"))
                        {
                            collected++;
                            field[possition[0], possition[1]] = "*";
                        }
                        break;
                    case "left":
                        if (possition[1] - 1 >= 0)
                        {
                            possition[1] -= 1;
                        }
                        if (field[possition[0], possition[1]].Equals("c"))
                        {
                            collected++;
                            field[possition[0], possition[1]] = "*";
                        }
                        break;
                    case "right":
                        if (possition[1] + 1 < field.GetLength(1))
                        {
                            possition[1] += 1;
                        }
                        if (field[possition[0], possition[1]].Equals("c"))
                        {
                            collected++;
                            field[possition[0], possition[1]] = "*";
                        }
                        break;

                }
                if (field[possition[0], possition[1]].Equals("e"))
                {
                    Console.WriteLine($"Game over! ({possition[0]}, {possition[1]})");
                    return;
                }

            }
            if (collected == coalCount)
            {
                Console.WriteLine($"You collected all coals! ({possition[0]}, {possition[1]})");
            }
            else
            {
                Console.WriteLine($"{coalCount-collected} coals left. ({possition[0]}, {possition[1]})");
            }
        }
    }
}
