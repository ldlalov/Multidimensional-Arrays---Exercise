using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimentions[0], dimentions[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] element = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < element.GetLength(0); col++)
                {
                    matrix[row, col] = element[col];
                }
            }
            int sum = 0;
            int[,] matrix1 = new int[3, 3];
            int[,] bestMatrix = new int[3, 3];
            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                int tempSum = 0;
                    matrix1[0, 0] = matrix[r, c];
                    matrix1[1, 0] = matrix[r + 1, c];
                    matrix1[2, 0] = matrix[r + 2, c];
                    matrix1[0, 1] = matrix[r, c + 1];
                    matrix1[1, 1] = matrix[r + 1, c + 1];
                    matrix1[2, 1] = matrix[r + 2, c + 1];
                    matrix1[0, 2] = matrix[r, c + 2];
                    matrix1[1, 2] = matrix[r + 1, c + 2];
                    matrix1[2, 2] = matrix[r + 2, c + 2];
                    foreach (var element in matrix1)
                    {
                        tempSum += element;
                    }
                    if (tempSum > sum)
                    {
                        for (int raw = 0; raw < matrix1.GetLength(0); raw++)
                        {
                            for (int col = 0; col < matrix1.GetLength(1); col++)
                            {
                                bestMatrix[raw, col] = matrix1[raw, col];
                            }
                        }
                        sum = tempSum;
                    }

                }
            }
            Console.WriteLine($"Sum = {sum}");
            for (int r = 0; r < bestMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < bestMatrix.GetLength(1); c++)
                {
                    Console.Write($"{bestMatrix[r, c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
