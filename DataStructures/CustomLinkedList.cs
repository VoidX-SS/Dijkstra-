using System.Collections;
using System.Collections.Generic;

internal class Program
{
    public class Node
    { 
        public object TenThanhPho;
        public Node blink, flink;
        public Node()
        {
            TenThanhPho = null;
            flink = blink = null;
        }
        public Node(object ThanhPhoMoi)
        {
            this.TenThanhPho = ThanhPhoMoi;
            flink = blink = null;
        }

        public class DoubleLinkedList
        {
            public Node header;
            public DoubleLinkedList()
            {header = new Node("Header"); }

            private Node TimThanhPho(object value)
            {
                Node current = header.flink;
                while (current != null)
                {
                    if (current.TenThanhPho.Equals(value)) return current;
                    current = current.flink;
                }
                return null;
            }

            public void ThemThanhPho(object newTenThanhPho, object afterTenThanhPho){
                Node current = TimThanhPho(afterTenThanhPho);
                Node newnode = new Node(newTenThanhPho);
                if (current == null) return;
                if(current.flink!=null)
                    current.flink.blink = newnode;
                newnode.flink = current.flink;
                current.flink = newnode;
                newnode.blink = current;
            }

            public void XoaThanhPho(object value) {
                Node current = TimThanhPho(value);
                if (current == null) return;
                if (current.blink != null) {
                    current.blink.flink = current.flink;
                if (current.flink != null)
                    current.flink.blink = current.blink;
                }
            }

            public void SortThanhPho()
            {
                for (Node i = header; i.flink != null; i = i.flink)
                    for (Node j = i.flink; j != null; j = j.flink)
                    {
                        
                    }
            }

            public void DanhSachThanhPho() {
                Node current = new Node();
                current = header.flink;
                while (!(current == null)) {
                    Console.WriteLine(current.TenThanhPho);
                    current = current.flink;
                }
            }
            

            public int DemThanhPho()
            {
                int Count = 0;
                Node current = header.flink;
                while (current != null) 
                {
                    Count++;
                    current = current.flink;
                }

                return Count;
            }
        }
    }
    private static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        
    }
}
