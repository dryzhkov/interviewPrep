using System;
using CodingInterviewPrep.SA;
using CodingInterviewPrep.LinkedList;
using CodingInterviewPrep.StacksAndQueues;
using CodingInterviewPrep.TreesAndGraphs;
using CodingInterviewPrep.BitManipulation;
using CodingInterviewPrep.DPandRec;

namespace CodingInterviewPrep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is interview prep.");

            //LinkedListProblems.kthToLast_Test();
            //SQProblems.SortStack_Test();
            
            //BinaryTreeProblems.Test_BinaryTreeInit();
            //BinaryTreeProblems.Test_CreateMinimalTree();

            //BitManipulationProblems.Test_GetBit();
            //BitManipulationProblems.Test_SetBit();

            //DynamicProgramming.Test_TripleStep();
            //DynamicProgramming.Test_TowerOfHanoi();

            SA.MaxProfit.MaxProfit_Test();
        }
    }
}
