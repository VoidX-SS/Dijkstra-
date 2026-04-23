using System;

namespace DoAnCuoiKy_Dijkstra
{
    // Danh sách liên kết Generic để lưu trữ Adjacency List
    public class CustomLinkedList<T>
    {
        public ListNode<T> Head { get; private set; }
        public ListNode<T> Tail { get; private set; }
        
        private int count;
        public int Count 
        { 
            get { return count; } 
        }

        public CustomLinkedList()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        // Thêm phần tử vào cuối danh sách
        public void AddLast(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
            count++;
        }

        // Thêm phần tử vào đầu danh sách
        public void AddFirst(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
            count++;
        }

        // Xóa một phần tử theo Data
        public bool Remove(T data)
        {
            ListNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == Head)
                    {
                        Head = current.Next;
                        if (Head != null) Head.Prev = null;
                        else Tail = null; // List có 1 phần tử
                    }
                    else if (current == Tail)
                    {
                        Tail = current.Prev;
                        if (Tail != null) Tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}
