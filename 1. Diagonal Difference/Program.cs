using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] element = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < element.GetLength(0); col++)
                {
                    matrix[row, col] = element[col];
                }
            }
            int sum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                sum += matrix[col, col];
            }
            int sum1 = 0;
            int row1 = 0;
            for (int col = matrix.GetLength(1)-1; col >= 0;  col--)
            {
                sum1 += matrix[row1, col];
                row1++;
            }
            Console.WriteLine(Math.Abs(sum - sum1));
        }
    }
}
