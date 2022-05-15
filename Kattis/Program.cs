using System;
using System.Collections.Generic;


namespace Kattis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProblemA();
            for (int i = 1; i < 4; i++)
            {
                ProblemB($"ProbB{i}.in");
            }
            ProblemC();
        }
        public static void ProblemC()
        {
            string input = "";
            //while(true)
            //{
            //    string i = Console.ReadLine();
            //    input += i + "\n";
            //    if(i == "0")
            //        break;

            //}
            input = File.ReadAllText(Environment.CurrentDirectory + @"\probC.in");

            string[] instructions = input.Split('\n');
            int index = 0;
            while (true)
            {
                int n = int.Parse(instructions[index]);

                if (n == 0)
                    break;
                bool error = false;
                int old = -1;
                for (int i = index + 1; i <= index + n; i++)
                {

                    char main = '.';
                    char alt = '.';
                    if (instructions[i][0] == '#')
                        main = '#';
                    else
                        alt = '#';
                    string[] arr = instructions[i].Split(' ');


                    int counter = 0;
                    for (int j = 1; j < arr.Length; j++)
                    {
                        for (int k = 0; k < int.Parse(arr[j]); k++)
                        {
                            if (j % 2 != 0)
                                Console.Write(main);
                            else
                                Console.Write(alt);
                            counter++;
                        }
                    }
                    if (old != -1 && old != counter)
                        error = true;
                    old = counter;

                    Console.WriteLine();


                }
                if (error)
                    Console.WriteLine("Error decoding image");
                index += n + 1;
            }
        }
        public static void ProblemB(string filename)
        {
            
            string input = "";
            //while (true)
            //{
            //    string i = Console.ReadLine();
            //    input += i + "\n";
            //    if (i.StartsWith('F'))
            //        break;

            //}
            input = File.ReadAllText(Environment.CurrentDirectory + $@"\{filename}");
            string[] split = input.Split('\n');
            
            string instructions = split[8];
            char[,] board = new char[8,8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i,j] = split[i][j];
                }
            }
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(board[i,j]);
            //    }
            //    Console.WriteLine();
            //}
            int[] direction = { 0, 1 };
            int[] pos = { 7, 0 };
            bool isDiamond = false;
            for (int i = 0; i < instructions.Length; i++)
            {

                if (instructions[i] == 'F')
                {
                    pos[0] += direction[0];
                    pos[1] += direction[1];
                    if (pos[0] > 7 || pos[1] < 0 || pos[1] > 7 || pos[0] < 0)
                        break;
                    
                    if (board[pos[0], pos[1]] == 'D')
                    {
                        isDiamond = true;
                        break;
                    }
                    else if (board[pos[0], pos[1]] != '.')
                        break;
                }
                else if (instructions[i] == 'L')
                {
                    if (direction[0] == 0 && direction[1] == 1)
                    {
                        direction[0] = -1;
                        direction[1] = 0;
                    }
                    else if (direction[0] == 1 && direction[1] == 0)
                    {
                        direction[0] = 0;
                        direction[1] = 1;
                    }
                    else if (direction[0] == 0 && direction[1] == -1)
                    {
                        direction[0] = 1;
                        direction[1] = 0;
                    }
                    else if (direction[0] == -1 && direction[1] == 0)
                    {
                        direction[0] = 0;
                        direction[1] = -1;
                    }
                }
                else if (instructions[i] == 'R')
                {
                    if (direction[0] == 0 && direction[1] == 1)
                    {
                        direction[0] = 1;
                        direction[1] = 0;
                    }
                    else if (direction[0] == 1 && direction[1] == 0)
                    {
                        direction[0] = 0;
                        direction[1] = -1;
                    }
                    else if (direction[0] == 0 && direction[1] == -1)
                    {
                        direction[0] = 1;
                        direction[1] = 0;
                    }
                    else if (direction[0] == -1 && direction[1] == 0)
                    {
                        direction[0] = 0;
                        direction[1] = 1;
                    }
                }
                else if (instructions[i] == 'X')
                {
                    if (board[pos[0] + direction[0], pos[1] + direction[1]] != 'I')
                        break;
                    else
                        board[pos[0] + direction[0], pos[1] + direction[1]] = '.';
                }



                
            }
            if (isDiamond)
                Console.WriteLine("Diamond!");
            else
                Console.WriteLine("Bug!");
        }

        public static void ProblemA()
        {
            string input = "";
            //while(true)
            //{
            //    string i = Console.ReadLine();
            //    input += i + "\n";
            //    if(i == "0")
            //        break;

            //}
            input = File.ReadAllText(Environment.CurrentDirectory + @"\probA.in");
            string[] instructions = input.Split('\n');
            int index = 0;
            while (true)
            {
                byte n = byte.Parse(instructions[index]);
                if (n == 0)
                    break;
                index++;
                char[] output = new char[32];
                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = '?';
                }

                for (int i = 0; i < n; i++)
                {


                    string[] arr = instructions[index].Split(' ');
                    index++;
                    byte a, b;
                    a = byte.Parse(arr[1]);
                    switch (arr[0])
                    {
                        case "SET":
                            output[a] = '1';
                            break;
                        case "CLEAR":
                            output[a] = '0';
                            break;
                        case "OR":
                            b = byte.Parse(arr[2]);
                            if (output[a] != '?' && output[b] != '?')
                            {
                                output[a] = output[a] == '1' || output[b] == '1' ? '1' : '0';
                            }
                            else
                                output[a] = '?';
                            break;
                        case "AND":
                            b = byte.Parse(arr[2]);
                            if (output[a] != '?' && output[b] != '?')
                                output[a] = output[a] == '1' && output[a] == output[b] ? '1' : '0';
                            else
                                output[a] = '?';
                            break;
                        default:
                            Console.Error.WriteLine("SOMETHING WENT HORRIBLY WRONG");
                            break;
                    }

                }
                Array.Reverse<char>(output);
                Console.WriteLine(output);

            }
        }
    }
}