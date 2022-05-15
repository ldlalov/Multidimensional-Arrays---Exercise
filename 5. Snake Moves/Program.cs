using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //rows and cols
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[] snake = Console.ReadLine().ToCharArray();
            //fill matrix
            string[,] matrix = new string[dimentions[0], dimentions[1]];
            int currentSnake = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = (snake[currentSnake]).ToString();
                        currentSnake++;
                        if (currentSnake==snake.Length)
                        {
                            currentSnake = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        matrix[row, col] = (snake[currentSnake]).ToString();
                        currentSnake++;
                        if (currentSnake == snake.Length)
                        {
                            currentSnake = 0;
                        }
                    }
                }
            }
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c]}");
                }
                Console.WriteLine();
            }
        }
    }
}
