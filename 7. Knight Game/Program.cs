using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[,] matrix = new string[dimentions, dimentions];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col].ToString();
                }
            }
            int[] coordinates = new int[2];
            Dictionary<Dictionary<int,int>, int> kCount = new Dictionary<Dictionary<int,int>, int>();
            int removedKnights = 0;
            bool found = true;
            while (found)
            {
                int maxCount = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                         int i = 0;
                        if (matrix[row, col].Equals("K"))
                        {
                            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1].Equals("K"))
                            {
                                i++;
                            }
                            if (row - 2 >= 0 && col + 1 < matrix.GetLength(0) && matrix[row - 2, col + 1].Equals("K"))
                            {
                                i++;
                            }
                            if (row + 2 < matrix.GetLength(1) && col - 1 >= 0 && matrix[row + 2, col - 1].Equals("K"))
                            {
                                i++;
                            }
                            if (row + 2 < matrix.GetLength(1) && col + 1 < matrix.GetLength(0) && matrix[row + 2, col + 1].Equals("K"))
                            {
                                i++;
                            }
                            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2].Equals("K"))
                            {
                                i++;
                            }
                            if (row - 1 >= 0 && col + 2 < matrix.GetLength(0) && matrix[row - 1, col + 2].Equals("K"))
                            {
                                i++;
                            }
                            if (row + 1 < matrix.GetLength(1) && col - 2 >= 0 && matrix[row + 1, col - 2].Equals("K"))
                            {
                                i++;
                            }
                            if (row + 1 < matrix.GetLength(1) && col + 2 < matrix.GetLength(0) && matrix[row + 1, col + 2].Equals("K"))
                            {
                                i++;
                            }
                            if (i > maxCount)
                            {
                                maxCount = i;
                                coordinates[0] = row;
                                coordinates[1] = col;
                            }
                        }
                    }
                }
                if (maxCount>0)
                {
                matrix[coordinates[0], coordinates[1]] = "0";
                removedKnights++;
                }
                else
                {
                    found = false;
                }
            }
            Console.WriteLine(removedKnights);
        }
    }
}
