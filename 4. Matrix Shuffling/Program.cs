using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //rows and cols
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //fill matrix
            string[,] matrix = new string[dimentions[0], dimentions[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] element = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < element.GetLength(0); col++)
                {
                    matrix[row, col] = element[col];
                }
            }
            //read command
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd.Length != 5 || cmd[0] != "swap" || int.Parse(cmd[1])<0 || int.Parse(cmd[2]) <0 || int.Parse(cmd[3]) <0 || int.Parse(cmd[4]) <0 || int.Parse(cmd[1]) > matrix.GetLength(0) || int.Parse(cmd[2]) > matrix.GetLength(1) || int.Parse(cmd[3]) > matrix.GetLength(0) || int.Parse(cmd[4]) > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string temp = matrix[int.Parse(cmd[1]), int.Parse(cmd[2])];
                matrix[int.Parse(cmd[1]), int.Parse(cmd[2])] = matrix[int.Parse(cmd[3]), int.Parse(cmd[4])];
                matrix[int.Parse(cmd[3]), int.Parse(cmd[4])] = temp;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        Console.Write($"{matrix[r, c]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
