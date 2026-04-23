using System;
using System.Collections.Generic;

namespace DoAnCuoiKy_Dijkstra
{
    // Trả về Winform kết quả từ Dijkstra
    public class PathResult
    {
        // Lưu trữ đường đi theo thứ tự từ nguồn tới đích
        public CustomLinkedList<Vertex> Path { get; private set; }
        
        // Tổng khoảng cách/trọng số của đường đi
        public double TotalDistance { get; private set; }

        public PathResult(CustomLinkedList<Vertex> path, double totalDistance)
        {
            if (path == null)
                throw new ArgumentNullException("Danh sách đường đi không được null.");
                
            if (totalDistance < 0)
                throw new ArgumentException("Tổng khoảng cách không được âm.");

            Path = path;
            TotalDistance = totalDistance;
        }
    }
}
