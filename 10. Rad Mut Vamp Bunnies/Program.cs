using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Rad_Mut_Vamp_Bunnies
{
    //class Bunny
    //{
    //    public Bunny(int row, int col)
    //    {
    //        this.Row = row;
    //        this.Col = col;
    //    }
    //        public int Row { get; set; }
    //    public int Col { get; set; }
    //}
    internal class Program
    {
        public bool dead = false;
        static void Main(string[] args)
        {
           int[] dimentions = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimentions[0];
            int col = dimentions[1];
            int[] possition = new int[2];//Player,s possition
            string[,] lair = new string[row, col];
            for (int r = 0; r < row; r++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int c = 0; c < col; c++)
                {
                    lair[r, c] = currentRow[c].ToString();
                    if (currentRow[c].Equals('P'))
                    {
                        possition[0] = r;
                        possition[1] = c;
                    }
                    if (currentRow[c].Equals('B'))
                    {
                    //Bunny bunny = new Bunny(r, c);
                    //bunnies.Add(bunny);
                    }
                }
            }
            //Executing commands
            char[] commands = Console.ReadLine().ToCharArray();
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case 'U':
                        if (possition[0] - 1 >= 0)
                        {
                            lair[possition[0], possition[1]] = ".";
                            if (lair[possition[0]-1, possition[1]] == "B")
                            {
                                New_Bunnies(lair);
                                Draw_Lair(lair);
                                Console.WriteLine($"dead: {possition[0]-1} {possition[1]}");
                                return;
                            }
                            possition[0] -= 1;
                            lair[possition[0], possition[1]] = "P";
                        }
                        else
                        {
                            lair[possition[0], possition[1]] = ".";
                            New_Bunnies(lair);
                            Draw_Lair(lair);
                            Console.WriteLine($"won: {possition[0]} {possition[1]}");
                            return;
                        }
                        break;
                    case 'D':
                        if (possition[0] + 1 < lair.GetLength(0))
                        {
                            lair[possition[0], possition[1]] = ".";
                            if (lair[possition[0]+1, possition[1]] == "B")
                            {
                                New_Bunnies(lair);
                                Draw_Lair(lair);
                                Console.WriteLine($"dead: {possition[0]+1} {possition[1]}");
                                return;
                            }
                            possition[0] += 1;
                            lair[possition[0], possition[1]] = "P";
                        }
                        else
                        {
                            lair[possition[0], possition[1]] = ".";
                            New_Bunnies(lair);
                            Draw_Lair(lair);
                            Console.WriteLine($"won: {possition[0]} {possition[1]}");
                            return;
                        }
                        break;
                    case 'L':
                        if (possition[1] - 1 >= 0)
                        {
                            if (lair[possition[0], possition[1]-1] == "B")
                            {
                                New_Bunnies(lair);
                                Draw_Lair(lair);
                                Console.WriteLine($"dead: {possition[0]} {possition[1]-1}");
                                return;
                            }
                            lair[possition[0], possition[1]] = ".";
                            possition[1] -= 1;
                            lair[possition[0], possition[1]] = "P";
                        }
                        else
                        {
                            lair[possition[0], possition[1]] = ".";
                            New_Bunnies(lair);
                            Draw_Lair(lair);
                            Console.WriteLine($"won: {possition[0]} {possition[1]}");
                            return;
                        }
                        break;
                    case 'R':
                        if (possition[1] + 1 < lair.GetLength(1))
                        {
                            lair[possition[0], possition[1]] = ".";
                            if (lair[possition[0], possition[1]+1] == "B")
                            {
                                New_Bunnies(lair);
                                Draw_Lair(lair);
                                Console.WriteLine($"dead: {possition[0]} {possition[1]+1}");
                                return;
                            }
                            possition[1] += 1;
                            lair[possition[0], possition[1]] = "P";
                        }
                        else
                        {
                            lair[possition[0], possition[1]] = ".";
                            New_Bunnies(lair);
                            Draw_Lair(lair);
                            Console.WriteLine($"won: {possition[0]} {possition[1]}");
                            return;
                        }
                        break;
                }
                New_Bunnies(lair);
                if (Check_Dead(lair))
                {
                    Draw_Lair(lair);
                    Console.WriteLine($"dead: {possition[0]} {possition[1]}");
                    return;
                }
            }
        }
        static bool Cherk_Position(int r, int c,string[,]lair)
        {
            if (r >= 0 && r<lair.GetLength(0) && c>=0 && c<lair.GetLength(1))
            {
                return true;
            }
                return false;
        }
        static bool Check_Dead(string[,] lair)
        {
            foreach (var item in lair)
            {
                if (item == "P")
                {
                    return false;
                }
            }
            return true;
        }
        static void New_Bunnies(string[,] lair)
        {
            for (int r = 0; r < lair.GetLength(0); r++)
            {
                for (int c = 0; c < lair.GetLength(1); c++)
                {
                    if (lair[r,c] == "B")
                    {
                        if(Cherk_Position(r - 1, c, lair) && lair[r - 1, c]!="B")
                        {
                            lair[r - 1, c] = "N";
                        }
                        if(Cherk_Position(r + 1, c, lair) && lair[r + 1, c] != "B")
                        {
                            lair[r + 1, c] = "N";
                        }
                        if(Cherk_Position(r, c - 1 , lair) && lair[r, c - 1] != "B")
                        {
                            lair[r, c - 1] = "N";
                        }
                        if(Cherk_Position(r, c + 1 , lair) && lair[r, c + 1] != "B")
                        {
                            lair[r, c + 1] = "N";
                        }
                    }
                }
            }
            for (int r = 0; r < lair.GetLength(0); r++)
            {
                for (int c = 0; c < lair.GetLength(1); c++)
                {
                    if (lair[r,c] == "N")
                    {
                        lair[r, c] = "B";
                    }
                }
            }   
        }
        static void Draw_Lair(string[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row,col]);
                }
                Console.WriteLine();
            }
        }

    }
}
