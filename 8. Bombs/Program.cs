using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            int[,] field = new int[dimentions, dimentions];//start creating the matrix
            for (int row = 0; row < field.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                }
            }//end creating the matrix
            string[] bombs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < bombs.Length; i++)
            {
                int[] currentBomb = bombs[i].Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int cellValue = field[currentBomb[0],currentBomb[1]];
                if (cellValue <= 0)
                {
                    continue;
                }
                field[currentBomb[0], currentBomb[1]] = 0;
                if (currentBomb[0] - 1 >= 0 && currentBomb[1] - 1 >= 0 && field[currentBomb[0]-1 , currentBomb[1]-1]>0)
                {
                    field[currentBomb[0] - 1, currentBomb[1] - 1] -= cellValue;
                }
                if (currentBomb[0] - 1 >= 0  && field[currentBomb[0]-1 , currentBomb[1]]>0)
                {
                    field[currentBomb[0] - 1, currentBomb[1]] -= cellValue;
                }
                if (currentBomb[0] - 1 >= 0 && currentBomb[1] + 1 < field.GetLength(1) && field[currentBomb[0] - 1 , currentBomb[1] + 1]>0)
                {
                    field[currentBomb[0] - 1, currentBomb[1] + 1] -= cellValue;
                }
                if (currentBomb[1] - 1 >= 0 && field[currentBomb[0] , currentBomb[1]- 1]>0)
                {
                    field[currentBomb[0] , currentBomb[1] - 1] -= cellValue;
                }
                if (currentBomb[1] + 1 < field.GetLength(1) && field[currentBomb[0] , currentBomb[1] + 1]>0)
                {
                    field[currentBomb[0] , currentBomb[1] + 1] -= cellValue;
                }
                if (currentBomb[1] - 1 >= 0 && currentBomb[0] + 1 < field.GetLength(0) && field[currentBomb[0] + 1 , currentBomb[1] - 1]>0)
                {
                    field[currentBomb[0] + 1, currentBomb[1] - 1] -= cellValue;
                }
                if (currentBomb[0] + 1 < field.GetLength(0) && field[currentBomb[0] + 1 , currentBomb[1]]>0)
                {
                    field[currentBomb[0] + 1, currentBomb[1]] -= cellValue;
                }
                if (currentBomb[0] + 1 < field.GetLength(0) && currentBomb[1] + 1 < field.GetLength(1) && field[currentBomb[0] + 1 , currentBomb[1] + 1]>0)
                {
                    field[currentBomb[0] + 1, currentBomb[1] + 1] -= cellValue;
                }
            }
            int aliveCells = 0;
            int sumOfCells = 0;
            foreach (var item in field)
            {
                if (item>0)
                {
                    aliveCells++;
                    sumOfCells += item;
                }
            }
            Console.WriteLine($"Alive cells: { aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    Console.Write($"{field[r, c]} ");
                } 
                Console.WriteLine();
            }

        }
    }
}
