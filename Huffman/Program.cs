﻿using System;
using System.Collections.Generic;

//https://www.geeksforgeeks.org/huffman-coding-greedy-algo-3/

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<char, int> characters = new SortedList<char, int>();
            string message = "";
            while (message == "")
            {
                Console.Write("Anna merkkijono: ");
                message = Console.ReadLine();
            }
            
            for (int i = 0; i < message.Length; i++)
            {
                char a = message[i];
                try
                {
                    characters.Add(a, 0);
                }
                catch (Exception) { }

                characters[a]++;
            }

            //Luodaan jokaisesta merkistä Node olio joka lisätään listalle
            HuffmanNode Node;
            HuffmanNodeList Nodelist = new HuffmanNodeList();
            foreach (KeyValuePair<char, int> item in characters)
            {
                Node = new HuffmanNode(item.Key, item.Value);
                Nodelist.Add(Node);
            }
            Nodelist.Sort();

            //Jatketaan listan käsittelyä. Tehdään binääripuu.
            //Käyydään listaa läpi niin kauan, että listalla on vain yksi päätason elementti
            while (Nodelist.NodeList.Count > 1)
            {
                HuffmanNode left = Nodelist.Pop();
                HuffmanNode right = Nodelist.Pop();
                HuffmanNode parent = new HuffmanNode(left, right);
                Nodelist.Add(parent);
            }
            Nodelist.CreateBinaryLists();

            Console.WriteLine("Source: {0}", message);

            var encoded = Encode(message, Nodelist.reverseBinaryCodeList);
            Console.WriteLine("Encoded: {0}", encoded);

            var decoded = Decode(encoded, Nodelist.binaryCodeList);
            Console.WriteLine("Decodeded: {0}", decoded);

            if (decoded == message)
                Console.WriteLine("TOIMII");

            Console.ReadKey();
        }

        //Luo koodatun stringin
        static string Encode(string source, SortedList<char, string> codeList)
        {
            List<string> encodedSource = new List<string>();
            for (int i = 0; i < source.Length; i++)
            {
                encodedSource.Add(codeList[source[i]]);
            }

            return String.Join("", encodedSource.ToArray());
        }

        //Dekoodaa koodatun stringin
        static string Decode(string encoded, SortedList<string, char> charList)
        {
            List<string> decodedSource = new List<string>();
            string temp = "";
            for (int i = 0; i < encoded.Length; i++)
            {
                temp = temp + "" + encoded[i];
                try
                {
                    if (charList[temp].ToString() != "")
                    {
                        decodedSource.Add(charList[temp].ToString());
                        temp = "";
                    }
                }
                catch { }
            }

            return String.Join("", decodedSource.ToArray());
        }
    }
}
