using System;

namespace DoAnCuoiKy_Dijkstra
{
    // Đại diện cho một điểm/địa điểm trên đồ thị
    public class Vertex
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }

        // Danh sách các cạnh kề của đỉnh này
        public CustomLinkedList<Edge> Edges { get; private set; }

        public Vertex(string id, string name, double x, double y)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Mã địa điểm không hợp lệ.");
                
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên địa điểm không hợp lệ.");

            Id = id;
            Name = name;
            X = x;
            Y = y;
            Edges = new CustomLinkedList<Edge>();
        }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
