﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadth_first_traversal_without_recursion
{
    class Program
    {
        public int[,] Matrix = new int[50, 50];
        public int[] Result = new int[50];
        int count=1;
        int countofsteps;
        //Function for creating matrix for traversal
        private void InputMatrix(int size)
        {
            string edge;
            int numberofedge;
            Console.WriteLine("Please, input your Tree traversal.");
            Console.WriteLine("If you want enter next edges press Enter twice ");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Input the numbers of edges, those are connected to {0} edge ", i + 1);
                do
                {
                    edge = Console.ReadLine();
                    if (edge == "")
                        break;
                    if (Int32.TryParse(edge, out numberofedge) && numberofedge < size + 1 && i != numberofedge - 1)
                    {
                        Matrix[i, numberofedge - 1] = 1;
                        Matrix[numberofedge - 1, i] = 1;

                    }
                    else Console.WriteLine("please write right number");
                }
                while (true);
            }
        }
        //  Function  that verify is matrix empty
        private bool IsMatrixEmpty(int size)
        {
            int k = 0;
            for (int i = 0; i < size - 1; i++)
                for (int j = i + 1; j < size; j++)
                    if (Matrix[i, j] != 0)
                       return false;
            return true;
        }
        //Function  that make  alternation of edges
        private void MakingResult(int size)
        {
            int count1 = count;
            int CountOfSteps = countofsteps;
            countofsteps = 0;
            for (int k = CountOfSteps; k > 0; k--)
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        if (Matrix[i, j] == count1 - k)
                        {

                            Result[Matrix[i, j]] = i + 1;
                            Matrix[i, j] = 0;
                            Matrix[j, i] = 0;
                            for (int l = 0; l < size; l++)
                            {
                                if (Matrix[l, i] == 1)
                                {
                                    countofsteps++;
                                    Matrix[l, i] = count;
                                    Matrix[i, l] = count + size;
                                    count++;
                                }
                            }
                        }
                    }
            }
        }
        //  Function  that verify has matrix empty stroke
        private bool HasEmptyStroke(int size)
        {
            int countof1 = 0;
            for (int i = 0; i < size; i++)
            {
                countof1 = 0;
                for (int j = 0; j < size; j++)
                    if (Matrix[i, j] == 1)
                    {
                        countof1 = 1;
                        break;
                    }
                if (countof1 == 1)
                    continue;
                else return true;
            }
            return false;
        }
        //  Function  that verify has matrix cycle, if has it's can't be tree traversal
        private bool HasMatrixCycle(int size)
        {
            int k = 0;
            for (int i = 0; i < size - 1; i++)
                for (int j = i + 1; j < size; j++)
                    if (Matrix[i, j] == 1)
                        k++;
            if (k > size - 1)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number of edges, please   ");
            int size;
            int firstedge;
            if (Int32.TryParse(Console.ReadLine(), out size) == false)
                Console.WriteLine("You entered wrong simbol");
            else
            {
                Program program = new Program();
                program.InputMatrix(size);
                if (!program.HasMatrixCycle(size))
                {
                    if (!program.HasEmptyStroke(size))
                    {
                        Console.Write("Enter number of first edges, please   ");
                        if (Int32.TryParse(Console.ReadLine(), out firstedge) == false || firstedge < 1 || firstedge > size)
                            Console.WriteLine("You entered wrong simbol");
                        program.Result[program.count++] = firstedge;
                        if (!program.IsMatrixEmpty(size))
                            for (int i = 0; i < size; i++)
                            {
                                if (program.Matrix[i, firstedge - 1] == 1)
                                {
                                    program.Matrix[i, firstedge - 1] = program.count;
                                    program.Matrix[firstedge - 1, i] = program.count + size;
                                    program.count++;
                                }
                            }

                        program.countofsteps = program.count - 2;
                        int countofsteps1 = program.countofsteps;
                        //Making alternation of edges
                        for (int m = 0; m < size + 1; m++)
                        {
                            if (!program.IsMatrixEmpty(size))
                                program.MakingResult(size);
                            else
                            {
                                    for (int i = 1; i < program.count; i++)
                                        Console.WriteLine(program.Result[i]);                               
                                break;
                            }
                            if (m == size - countofsteps1 + 1)
                                Console.WriteLine("You entered  traversal  not  wright, there is one or more edges, that isn't connected each other ");
                        }
                    }
                    else
                        Console.WriteLine("You entered traversal  not  wright, there is one edge, that isn't connected to one of traversal's edges  ");
                }
                else
                    Console.WriteLine("You entered traversal  not  wright, it's has cicle ");
            }
        }
    }
}
