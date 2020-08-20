using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LinkedList
{
    //this program determines if node contains loop
    class Program
    {
        public static int counter = 1;

        static void Main(string[] args)
        {
            List<int> visitedNodes = new List<int>();
            LinkedList linkedList = new LinkedList();
            //No loop
            //linkedList.add(10);
            //linkedList.add(5);
            //linkedList.add(6);
            //linkedList.add(0);
            //linkedList.add(-4);

            //Yes loop
            linkedList.add(10);
            linkedList.add(5);
            linkedList.add(6);
            linkedList.add(0);
            linkedList.add(-4);
            linkedList.HeadNode.next.next.next.next = linkedList.HeadNode.next.next;

            visitedNodes.Add(linkedList.HeadNode.NodeId);
            visitedNodes.Add(linkedList.HeadNode.next.NodeId);
            visitedNodes.Add(linkedList.HeadNode.next.next.NodeId);
            visitedNodes.Add(linkedList.HeadNode.next.next.next.NodeId);
            visitedNodes.Add(linkedList.HeadNode.next.next.next.next.NodeId);


            bool flag = false;
            var duplicateItems = from x in visitedNodes
                                 group x by x into grouped
                                 where grouped.Count() > 1
                                 select grouped.Key;

            if (duplicateItems.Any())
                flag = true;

            if (flag)
                Console.WriteLine("Loop exists");
            else
                Console.WriteLine("Loop does not exist");

            Console.ReadKey();
        }

        public class Node
        {
            public int data { get; set; }
            public int NodeId { get; set; }
            public Node next { get; set; }
            public Node(int item)
            {
                data = item;
                next = null;
            }
        }

        public class LinkedList
        {
            public Node HeadNode { get; set; }
            public void add(int value)
            {
                Node newNode = new Node(value);
                newNode.next = HeadNode;
                HeadNode = newNode;
                HeadNode.NodeId = counter;
                counter++;

            }
        }
    }
}
