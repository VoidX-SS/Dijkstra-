using System;

namespace DoAnCuoiKy_Dijkstra
{
    public class ListNode<T>
    {
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }
        public ListNode<T> Prev { get; set; }

        public ListNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
