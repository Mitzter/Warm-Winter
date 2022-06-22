using System;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] scarfInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hatStack = new Stack<int>();
            Queue<int> scarfQueue = new Queue<int>();

            List<int> createdSets = new List<int>();

            for (int i = 0; i < hatInput.Length; i++)
            {
                hatStack.Push(hatInput[i]);
            }
            for (int i = 0; i < scarfInput.Length; i++)
            {
                scarfQueue.Enqueue(scarfInput[i]);
            }

            while (hatStack.Count != 0 || scarfQueue.Count != 0)
            {
                int currentHat = hatStack.Peek();
                int currentScarf = scarfQueue.Peek();
                int currentSetValue = 0;

                if (currentHat > currentScarf)
                {
                    currentSetValue = currentHat + currentScarf;
                    createdSets.Add(currentSetValue);
                    hatStack.Pop();
                    scarfQueue.Dequeue();
                    
                }
                else if (currentScarf > currentHat)
                {
                    hatStack.Pop();
                    
                }
                else if (currentHat == currentScarf)
                {
                    scarfQueue.Dequeue();
                    hatStack.Pop();
                    currentHat++;
                    hatStack.Push(currentHat);
                }

                if (WhileCycleBreak(hatStack, scarfQueue) == true)
                {
                    break;
                }
            }

            Console.WriteLine($"The most expensive set is: {createdSets.Max()}");

            Console.WriteLine(string.Join(" ", createdSets));

        }

        public static bool WhileCycleBreak(Stack<int> hatStack, Queue<int> scarfQueue)
        {
            if (hatStack.Count == 0 || scarfQueue.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
