using System;
using System.Collections.Generic;

namespace DoAnCuoiKy_Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("THUẬT TOÁN TÌM ĐƯỜNG ĐI NGẮN NHẤT BẰNG DIJKSTRA (BACKEND)");

            try
            {
                // 1. Load đồ thị từ file CSV
                string locationPath = "DS_Location.csv";
                string edgePath = "DS_Edge.csv";
                Graph graph = GraphLoader.LoadGraph(locationPath, edgePath);

                Console.WriteLine("Load dữ liệu thành công. Tổng số đỉnh: " + graph.VertexCount);

                // 2. Khởi tạo bộ máy Dijkstra
                DijkstraEngine engine = new DijkstraEngine(graph);

                // 3. Tìm đường đi ngắn nhất
                string startId = "DinhDL"; // Dinh Độc Lập
                string endId = "Landmark81"; // Landmark 81

                Console.WriteLine("Đang tìm đường đi từ [" + startId + "] đến [" + endId + "]...");

                PathResult result = engine.FindShortestPath(startId, endId);

                // 4. In kết quả
                if (result != null)
                {
                    Console.WriteLine("ĐÃ TÌM THẤY ĐƯỜNG ĐI NGẮN NHẤT!");
                    Console.WriteLine("Tổng khoảng cách: " + Math.Round(result.TotalDistance, 2) + " đơn vị");
                    Console.Write("Lộ trình: ");
                    
                    List<Vertex> pathVertices = new List<Vertex>();
                    ListNode<Vertex> current = result.Path.Head;
                    while (current != null)
                    {
                        pathVertices.Add(current.Data);
                        current = current.Next;
                    }

                    for (int i = 0; i < pathVertices.Count; i++)
                    {
                        Console.Write(pathVertices[i].Name);
                        if (i < pathVertices.Count - 1)
                            Console.Write(" -> ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("KHÔNG TÌM THẤY ĐƯỜNG ĐI NÀO.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CÓ LỖI XẢY RA: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
