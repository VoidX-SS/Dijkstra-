using System;

namespace DoAnCuoiKy_Dijkstra
{
    public class Vertex
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public MyLinkedList<Edge> Edges { get; private set; }

        public Vertex(string id, string name, double x, double y)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("Mã địa điểm không hợp lệ.");

            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Tên địa điểm không hợp lệ.");

            Id = id.Trim();
            Name = name.Trim();
            X = x;
            Y = y;
            Edges = new MyLinkedList<Edge>();
        }

        public override string ToString()
        {
            return Id + " - " + Name + " (" + X.ToString("0.##") + ", " + Y.ToString("0.##") + ")";
        }
    }
}
