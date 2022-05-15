using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[][] matrix = new double[int.Parse(Console.ReadLine())][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }
            for (int row = 0; row < matrix.Length-1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row+1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row+1].Length; col++)
                    {
                        matrix[row+1][col] /= 2;
                    }

                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                switch (cmd[0])
                {
                    case "Add":
                        if (0 <= row && row < matrix.Length && 0 <= col && col<matrix[row].Length)
                        {
                            matrix[row][col] += value;
                        }
                        break;
                    case "Subtract":
                        if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
                        {
                            matrix[row][col] -= value;
                        }
                        break;
                }
            }
            foreach (double[] row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
