using System;
using System.Collections.Generic;

namespace DoAnCuoiKy_Dijkstra
{
    // Cấu trúc đồ thị quản lý toàn bộ các điểm và các cạnh nối
    public class Graph
    {
        // Sử dụng Dictionary (HashTable) để tìm đỉnh theo ID
        private Dictionary<string, Vertex> vertexMap;

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }

        // Lấy danh sách tất cả các đỉnh
        public Dictionary<string, Vertex>.ValueCollection GetAllVertices()
        {
            return vertexMap.Values;
        }

        // Trả về số lượng đỉnh
        public int VertexCount 
        { 
            get { return vertexMap.Count; } 
        }

        // Thêm một đỉnh mới vào đồ thị
        public void AddVertex(string id, string name, double x, double y)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("ID và Name không được để trống.");

            id = id.Trim();
            name = name.Trim();

            if (vertexMap.ContainsKey(id))
                throw new ArgumentException("Đỉnh có mã đã tồn tại.");

            Vertex vertex = new Vertex(id, name, x, y);
            vertexMap.Add(id, vertex); // Lưu vào Dictionary
        }

        // Tìm đỉnh theo ID
        public Vertex GetVertex(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            id = id.Trim();

            if (vertexMap.ContainsKey(id))
                return vertexMap[id];
                
            return null;
        }

        // Kiểm tra xem có cạnh nối từ from tới to không
        public bool HasEdge(Vertex from, Vertex to)
        {
            if (from == null || to == null) return false;

            ListNode<Edge> current = from.Edges.Head;
            while (current != null)
            {
                Edge edge = current.Data;
                if (edge.Destination.Id == to.Id)
                    return true;
                    
                current = current.Next;
            }
            return false;
        }

        // Tính khoảng cách Euclid giữa 2 đỉnh
        private double CalculateEuclideanDistance(Vertex a, Vertex b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Thêm cạnh 2 chiều (Undirected Edge)
        public void AddUndirectedEdge(string id1, string id2)
        {
            id1 = id1.Trim();
            id2 = id2.Trim();

            if (id1 == id2)
                throw new ArgumentException("Không thể nối đỉnh với chính nó.");

            Vertex v1 = GetVertex(id1);
            Vertex v2 = GetVertex(id2);

            if (v1 == null || v2 == null)
                throw new ArgumentException("Một trong hai đỉnh không tồn tại.");

            if (HasEdge(v1, v2))
                return; // Đã tồn tại cạnh

            double distance = CalculateEuclideanDistance(v1, v2);

            v1.Edges.AddLast(new Edge(v2, distance));
            v2.Edges.AddLast(new Edge(v1, distance));
        }

        // Thêm cạnh 1 chiều (Directed Edge) - Dùng nếu có đường một chiều
        public void AddDirectedEdge(string fromId, string toId)
        {
            fromId = fromId.Trim();
            toId = toId.Trim();

            if (fromId == toId)
                throw new ArgumentException("Không thể nối đỉnh với chính nó.");

            Vertex from = GetVertex(fromId);
            Vertex to = GetVertex(toId);

            if (from == null || to == null)
                throw new ArgumentException("Một trong hai đỉnh không tồn tại.");

            if (HasEdge(from, to))
                return;

            double distance = CalculateEuclideanDistance(from, to);
            from.Edges.AddLast(new Edge(to, distance));
        }
    }
}
