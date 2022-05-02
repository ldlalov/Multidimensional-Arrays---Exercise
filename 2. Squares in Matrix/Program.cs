using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] element = Console.ReadLine().Split(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = element[col];
                }
            }
            int equal = 0;
            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    if ((matrix[r,c] == matrix[r,c+1]) &&(matrix[r,c] == matrix[r+1,c]) &&(matrix[r,c] == matrix[r+1,c+1]))
                    {
                        equal++;
                    }
                }
            }
            Console.WriteLine(equal);
        }
    }
}
