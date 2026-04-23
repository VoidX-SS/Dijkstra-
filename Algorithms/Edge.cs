using System;

namespace DoAnCuoiKy_Dijkstra
{
    // Đại diện cho một cạnh nối giữa 2 đỉnh
    public class Edge
    {
        // Đỉnh đích đến
        public Vertex Destination { get; private set; }
        
        // Trọng số của cạnh (khoảng cách Euclid giữa 2 điểm)
        public double Weight { get; private set; }

        public Edge(Vertex destination, double weight)
        {
            if (destination == null)
                throw new ArgumentNullException("Điểm đến không được phép null.");
            
            if (weight < 0)
                throw new ArgumentException("Trọng số (khoảng cách) không được âm.");

            Destination = destination;
            Weight = weight;
        }
    }
}
