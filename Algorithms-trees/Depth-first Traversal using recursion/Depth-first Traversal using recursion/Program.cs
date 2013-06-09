using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Depth_first_Traversal_using_recursion
{
    class Program
    {
        public int[,] Matrix = new int[50, 50];
        public int MatrixSize;
        public int[] Result = new int[50];
        public int[] Stack = new int[50];
        int stackindexposition;
        int resultindex;
        int Stacknumber;
        //Function for creating matrix for traversal
        private void InputMatrix()
        {
            string edge;
            int numberofedge;
            Console.WriteLine("Please, input your Tree traversal.");
            Console.WriteLine("If you want enter next edges press Enter twice ");
            for (int i = 0; i < MatrixSize; i++)
            {
                Console.WriteLine("Input the numbers of edges, those are connected to {0} edge ", i + 1);
                do
                {
                    edge = Console.ReadLine();
                    if (edge == "")
                        break;
                    if (Int32.TryParse(edge, out numberofedge) && numberofedge < MatrixSize + 1 && i != numberofedge - 1)
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
        private bool IsMatrixEmpty()
        {
            for (int i = 0; i < MatrixSize - 1; i++)
                for (int j = i + 1; j < MatrixSize; j++)
                    if (Matrix[i, j] != 0)
                        return false;
            return true;
        }
        //  Function  that verify has matrix empty stroke, if Matrix at first has empty stroke that's mean, 
        //that there is an edge that doesn't connected any other edge.
        private bool HasEmptyStroke()
        {
            int countof1 = 0;
            for (int i = 0; i < MatrixSize; i++)
            {
                countof1 = 0;
                for (int j = 0; j < MatrixSize; j++)
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
        private bool HasMatrixCycle()
        {
            int k = 0;
            for (int i = 0; i < MatrixSize - 1; i++)
                for (int j = i + 1; j < MatrixSize; j++)
                    if (Matrix[i, j] == 1)
                        k++;
            if (k > MatrixSize - 1)
                return true;
            return false;
        }

        //Function  that verify has that edge  other branch, if  has, we add in stack
        private bool HasOtherBranch(int k, int j)
        {
            for (int i = k + 1; i < MatrixSize; i++)
            {
                if (Matrix[i, j] == 1)
                    return true;
            }
            return false;
        }

        //Function  that verify is stack empty, if it's empty and  matrix  doesn't  empty
        //It's mean  that  there are edges  that  connect  together,  but  don't connect other edges,It's mean that  it's not tree traversal
        private bool IsStackEmpty()
        {
            for (int i = 0; i < stackindexposition; i++)
                if (Stack[i] != 0)
                    return false;
            return true;

        }

        //Function  that make  alternation of edges
        private void MakingResult(int j)
        {
            int isbreak = 0;
            for (; ; )
            {
                for (int i = 0; i < MatrixSize; i++)
                    if (Matrix[i, j] == 1)
                    {
                        Result[resultindex] = i + 1;
                        resultindex++;
                        if (HasOtherBranch(i, j))
                        {
                            Stack[stackindexposition++] = j + 1;
                        }
                        Matrix[i, j] = 0;
                        Matrix[j, i] = 0;
                        j = i;
                        break;
                    }
                    else if (i == MatrixSize - 1)
                    {
                        isbreak = 1;
                    }
                if (isbreak == 1)
                    break;
            }
            for (; ; )
            {
                if (!IsMatrixEmpty())
                {
                    if (IsStackEmpty())
                    {
                        Console.WriteLine("You entered  traversal  not  wright, there is one or more edges, that isn't connected each other ");
                        break;
                    }
                    for (int k = stackindexposition; k > -1; k--)
                        if (Stack[k] != 0)
                        {
                            Stacknumber = Stack[k];
                            Stack[k] = 0;
                            MakingResult(Stacknumber - 1);
                            break;
                        }
                    break;
                }
                else
                {
                    for (int i = 0; i < resultindex; i++)
                        Console.WriteLine(Result[i]);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.Write("Enter number of edges, please   ");
            int firstedge;
            if (Int32.TryParse(Console.ReadLine(), out program.MatrixSize) == false)
                Console.WriteLine("You entered wrong simbol");
            else
            {
                program.InputMatrix();
                if (!program.HasMatrixCycle())
                {
                    if (!program.HasEmptyStroke())
                    {
                        Console.Write("Enter number of first edges, please   ");
                        if (Int32.TryParse(Console.ReadLine(), out firstedge) == false || firstedge < 1 || firstedge > program.MatrixSize)
                            Console.WriteLine("You entered wrong simbol");
                        program.Result[program.resultindex] = firstedge;
                        program.resultindex++;
                        program.MakingResult(firstedge - 1);
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
