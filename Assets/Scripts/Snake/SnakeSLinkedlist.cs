using System;

namespace Snake
{
    public class SnakeSlinkedlist<T>: IDynamicList<T>
    {
    
    
        private int count = 0;

        public DlinkListNode tail;
        public DlinkListNode head;



        public class DlinkListNode
        {
            public T data;
            public DlinkListNode next;
        }

        public void Add(T item)
        {
            DlinkListNode node = new DlinkListNode();

            node.data = item;
            node.next = null;

            if (this.count == 0)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
            this.count++;
        }
    
    
    
    
    
        public int Count
        {
            get
            {
                return count;
            }
        }
        public int IndexOf(T item)
        {
            throw new System.NotImplementedException();
        }

        public void PrintList()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                DlinkListNode currentNode = this.head;
                int counter = 0;
                while (currentNode != null)
                {
                    if (counter == index)
                    {
                        return currentNode.data;
                    }
                    else
                    {
                        currentNode = currentNode.next;
                        counter++;
                    }
                }
                throw new IndexOutOfRangeException(); // throw runTime error
            }

            set
            {
                DlinkListNode currentNode = this.head;
                int counter = 0;
                while (currentNode != null)
                {
                    if (counter == index)
                    {
                        currentNode.data = value;
                    }
                    else
                    {
                        currentNode = currentNode.next;
                        counter++;
                    }
                
                }
                throw new IndexOutOfRangeException(); // throw runTime error
            }
        }

        public T test(int index)
        {
        
            int counter = 0;
            for ( DlinkListNode currentNode = this.head ; currentNode != null; currentNode = currentNode.next, counter++)
            {
                if (counter == index)
                {
                    return currentNode.data;
                }
            
            
            }
            throw new IndexOutOfRangeException(); // throw runTime error

        }

    }
}
