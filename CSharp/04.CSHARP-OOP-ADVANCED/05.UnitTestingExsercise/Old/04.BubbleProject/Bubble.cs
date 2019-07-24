using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _04BubbleProject
{
    public class Bubble
    {
        public readonly List<int> elements;

        public Bubble(string input)
        {
            this.elements = Create(input);
            this.MaxElement = this.elements.Max();
            this.MinElement = this.elements.Min();
        }

        public int MaxElement { get; private set; }
        public int MinElement { get; private set; }

        private List<int> Create(string input)
        {
            int[] inputArgs = input.Split().Select(int.Parse).ToArray();
            List<int> temp = new List<int>();
            for (int i = 0; i < inputArgs.Length; i++)
            {
                temp.Add(inputArgs[i]);
            }
            return temp;
        }

        public void BubbleSort()
        {
            for (int i = 0; i < this.elements.Count-2; i++)
            {
                for (int j = 0; j < this.elements.Count-1; j++)
                {
                    if (this.elements[j] > this.elements[j+1])
                    {
                        int temp = this.elements[j];
                        this.elements[j] = this.elements[j + 1];
                        this.elements[j + 1] = temp;
                    }
                }
            }
        }
    }
}
