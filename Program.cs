using System;

namespace Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World of Double Links!");
            //populate list
            DoublyLinkedList list = new DoublyLinkedList();
            list.add(5);
            list.add(4);
            list.add(3);
            list.add(2);
            list.add(1);
            list.Print();
            //check remove function
            list.Remove(3);
            list.Print();

            //check edge cases
            list.Remove(1);
            list.Remove(5);
            list.Print();

            //add some more values to list.
            list.add(5);
            list.add(4);
            list.add(3);
            list.add(2);
            list.add(1);
            list.Print();

            //test reverse function
            list.Reverse();
            list.Print();
        }
    }
    public class DoublyLinkedList
    {
        public DLLNode Head;
        
        public void add(int val)
        {
            DLLNode newNode = new DLLNode(val);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                var Runner = Head;
                while(Runner.Next != null)
                {
                    Runner = Runner.Next;
                }
                Runner.Next = newNode;
                newNode.Prev = Runner;
            }
        }
        public void Print()
        {
            Console.WriteLine("##################################");
            var Runner = Head;
            if(Runner == null)
            {
                Console.WriteLine("Empty list.");
                return;
            }
            else
            {
                Console.Write(Runner.Value + ", ");
                while(Runner.Next != null)
                {
                    Runner = Runner.Next;
                    Console.Write(Runner.Value + ", ");
                }
                Console.WriteLine("");
                Console.WriteLine("##################################");
            }
        }
        public bool Remove(int value)
        {
            if(Head == null)
            {
                return false;
            }
            else
            {
                var Runner = Head;
                if(Head.Value == value)
                {
                    Head = Runner.Next;
                    Runner.Prev = null;
                    return true;
                }
                while(Runner.Next != null)
                {
                    if(Runner.Value == value)
                    {
                        //remove the runner node
                        Runner.Prev.Next = Runner.Next;
                        Runner.Next.Prev = Runner.Prev;
                        return true;
                    }
                    Runner = Runner.Next;
                }
                if(Runner.Value == value)
                {
                    Runner.Prev.Next = null;
                    return true;
                }
            }
            return false;
        }
        public void Reverse()
        {
            if(Head == null)
            {
                return;
            }
            //navigate to end of the list using runner
            var Runner = Head;
            while(Runner.Next != null)
            {
                Runner = Runner.Next;
            }
            DLLNode newHead = new DLLNode(Runner.Value);
            Head = newHead;
            Runner = Runner.Prev;
            while(Runner.Prev != null)
            {
                this.add(Runner.Value);
                Runner = Runner.Prev;
            }
        }
    }
    public class DLLNode
    {
        public int Value;
        public DLLNode Next;
        public DLLNode Prev;

        //constructor
        public DLLNode(int val)
        {
            Value = val;
            Next = null;
            Prev = null;
        }
    }
}