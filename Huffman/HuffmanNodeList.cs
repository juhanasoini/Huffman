using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class HuffmanNodeList
    {
        public List<HuffmanNode> NodeList;
        public SortedList<string, char> binaryCodeList = new SortedList<string, char>();
        public SortedList<char, string> reverseBinaryCodeList = new SortedList<char, string>();

        public HuffmanNodeList()
        {
            NodeList = new List<HuffmanNode>();
        }

        public void Add(HuffmanNode Node)
        {
            NodeList.Add(Node);
        }

        public void Sort()
        {
            NodeList.Sort();
        }

        public HuffmanNode Pop()
        {
            if (NodeList.Count == 0)
                return null;

            HuffmanNode node = NodeList[0];
            NodeList.RemoveAt(0);
            return node;
        }

        public void CreateBinaryLists()
        {
            if (NodeList[0] == null)
                return;

            List<int> path = new List<int>();
            HuffmanNode root = NodeList[0];
            HuffmanNode branch = root;

            traverse( root, path);

        }
        public void traverse(HuffmanNode node, List<int> path)
        {
            if (node.Left != null)
            {
                List<int> leftPath = new List<int>();
                leftPath.AddRange(path);
                leftPath.Add(0);
                traverse(node.Left, leftPath);
            }

            if( node.Right != null )
            {
                List<int> rightPath = new List<int>();
                rightPath.AddRange(path);
                rightPath.Add(1);
                traverse(node.Right, rightPath);
            }

            if (node.isLeaf())
            {
                var code = String.Join("", path.ToArray());

                reverseBinaryCodeList.Add(node.Data,code);
                binaryCodeList.Add(code, node.Data);
                //Console.WriteLine(code);
            }
        }
    }
}
