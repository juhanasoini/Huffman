using System;

namespace Huffman
{
    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public char Data;
        public double Freq;

        public HuffmanNode Left = null;
        public HuffmanNode Right = null;
        public HuffmanNode Parent;

        public HuffmanNode(char data, double freq)
        {
            Data = data;
            Freq = freq;
        }

        public HuffmanNode(HuffmanNode left, HuffmanNode right)
        {
            Left = left;
            Right = right;
            Freq = left.Freq + right.Freq;
            Left.Parent = this;
            Right.Parent = this;
        }

        public int CompareTo(HuffmanNode obj)
        {
            if (Freq > obj.Freq)
                return 1;
            if (Freq < obj.Freq)
                return -1;

            return 0;
        }

        public bool isLeaf()
        {
            return (Left == null && Right == null);
        }
    }
}
