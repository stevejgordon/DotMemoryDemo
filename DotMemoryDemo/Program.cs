using JetBrains.Profiler.Api;
using System;

namespace DotMemoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryProfiler.CollectAllocations(true);

            MemoryProfiler.GetSnapshot();

            var arrayOfValues = new[] { 10, 20, 30, 40, 50 };

            var thing = new SomeClass(arrayOfValues, "FiveValues");

            var total = thing.GetTotal();

            MemoryProfiler.GetSnapshot();
        }
    }

    public class SomeClass
    {
        private readonly int[] values;

        public SomeClass(int[] values, string name)
        {
            this.values = values;
            Name = name;
        }

        public string Name { get; }

        public int GetTotal()
        {
            var total = 0;

            foreach (var value in values)
            {
                total += value;
            }

            return total;
        }
    }
}
