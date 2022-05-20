using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IntelligentScissors
{
    class Graph
    {

        private static double[,] ShortestPath;
        private static KeyValuePair<int, int>[,] Parent;
        public static ArrayList[,] AdjLists;
        public static readonly int MANUAL_SELECT_DEFAULT_OFFSET = 75;
        public static readonly int AUTO_SELECT_DEFAULT_OFFSET = 20;
        public static int Offset = MANUAL_SELECT_DEFAULT_OFFSET;
        private static SortedSet<Node> Nodes = new SortedSet<Node>();
        private static KeyValuePair<int, int> Source;

        // Complexity Analysis: O(1)
        public static bool Contains(int source_x, int source_y, int x, int y) {
            return Math.Abs(x - source_x) < Offset && Math.Abs(y - source_y) < Offset;
        }
        // Complexity Analysis: O(V), where V = width * height
        public static void Construct(RGBPixel[,] ImageMatrix) { 
            int width = ImageOperations.GetWidth(ImageMatrix);
            int height = ImageOperations.GetHeight(ImageMatrix);
            AdjLists = new ArrayList[height, width];

            // O(width * height)
            for (int i = 0; i < height; ++i) { // O(height)
                for (int j = 0; j < width; ++j) { // O(width)
                    AdjLists[i, j] = new ArrayList();
                }
            }

            // O(width * height)
            for (int i = 0; i < height; ++i) { // O(height)
                for (int j = 0; j < width; ++j) { // O(width)
                    Vector2D vector = ImageOperations.CalculatePixelEnergies(i, j, ImageMatrix); // O(1)

                    if (i != height - 1)
                    {
                        AdjLists[i, j].Add(new Edge(i + 1, j, 1 / vector.Y));
                        AdjLists[i + 1, j].Add(new Edge(i, j, 1 / vector.Y));
                    }
                    if (j != width - 1)
                    {
                        AdjLists[i, j].Add(new Edge(i, j + 1, 1 / vector.X));
                        AdjLists[i, j + 1].Add(new Edge(i, j, 1 / vector.X));
                    }
                }
            }
        }

        // Complexity Analysis: O(Nodes in Priority Queue)
        public static void InitDijkstra(RGBPixel[,] ImageMatrix,
            KeyValuePair<int, int> source)
        {
            Source = source;
            int height = ImageOperations.GetHeight(ImageMatrix);
            int width = ImageOperations.GetWidth(ImageMatrix);
            ShortestPath = new double[height, width];
            Parent = new KeyValuePair<int, int>[height, width];
            // When the width and height are larger than RADIUS the complexity is O(RADUIS^2)
            // which is equailvant to O(1). Otherwise, the complexity is O(width * height)
            for (int i = Math.Max(0, Source.Key - Offset); i < Math.Min(height, Source.Key + Offset); ++i) {
                for (int j = Math.Max(0, Source.Value - Offset); j < Math.Min(width, Source.Value + Offset); ++j) {
                    ShortestPath[i, j] = double.PositiveInfinity;
                }
            }
            Nodes.Clear();
            Node sourceNode = new Node(Source.Key, Source.Value, 0.0);
            Parent[sourceNode.X, sourceNode.Y] = new KeyValuePair<int, int>(Source.Key, Source.Value);
            ShortestPath[sourceNode.X, sourceNode.Y] = sourceNode.Cost;
            Nodes.Add(sourceNode);
        }
        // Complexity Analysis : O(OFFSET^2) which is equivelant to O(1) 
        public static void UpdateShortestPath(KeyValuePair<int, int> destination) {
            // When V is larger than (RADIUS^2) the complexity is O(RADUIS^2)
            // which is equailvant to O(1). Otherwise, the complexity is O(V + E log(V))
            int destinationRow = destination.Key;
            int destinationColumn = destination.Value;
            if (ShortestPath[destinationRow, destinationColumn] != double.PositiveInfinity) {
                return;
            }
            while (Nodes.Count != 0) {
            
                Node node = Nodes.Min(); // O(log(Nodes.size())
                if (node.X == destinationRow && node.Y == destinationColumn)
                {
                    break;
                }
                Nodes.Remove(node); // O(log(Nodes.size())
                if (ShortestPath[node.X, node.Y] < node.Cost)
                {
                    continue;
                }
                foreach (Edge edge in AdjLists[node.X, node.Y]) // O(1) - Maximum 4 children
                {
                    var newCost = node.Cost + edge.Weight;
                    System.Diagnostics.Debug.Assert(edge.Weight != double.PositiveInfinity);
                    if (!Contains(Source.Key, Source.Value, edge.X, edge.Y)) // O(1)
                        continue;
                    if (newCost < ShortestPath[edge.X, edge.Y])
                    {
                        ShortestPath[edge.X, edge.Y] = newCost;
                        Parent[edge.X, edge.Y] = new KeyValuePair<int, int>(node.X, node.Y);
                        Nodes.Add(new Node(edge.X, edge.Y, newCost)); // O(log(Nodes.size())
                    }
                }
            }
        }
        // Complexity Analysis : O(Number of pixels in the Shortest Path)
        public static void DrawShortestPath(Bitmap ImageMatrix, RGBPixel PixelColor, KeyValuePair<int, int> Source, KeyValuePair<int, int> Destination)
        {
            int SourceRow = Source.Key;
            int SourceColumn = Source.Value;
            int CurrentRow = Destination.Key, CurrentColumn = Destination.Value;
            while (CurrentRow != SourceRow || CurrentColumn != SourceColumn)
            {
                drawPoint(ImageMatrix, CurrentRow, CurrentColumn,
                    Color.FromArgb(PixelColor.red, PixelColor.green, PixelColor.blue));
                TestOutput.Path.Enqueue(new KeyValuePair<int, int>(CurrentRow, CurrentColumn));
                KeyValuePair<int, int> ParentPosition = Graph.Parent[CurrentRow, CurrentColumn];
                CurrentRow = ParentPosition.Key;
                CurrentColumn = ParentPosition.Value;
            }
            drawPoint(ImageMatrix, CurrentRow, CurrentColumn,
                    Color.FromArgb(PixelColor.red, PixelColor.green, PixelColor.blue));
            TestOutput.Path.Enqueue(new KeyValuePair<int, int>(CurrentRow, CurrentColumn));
        }
        // Complexity Analysis: O(1)
        private static void drawPoint(Bitmap imageMatrix, int r, int c, Color color) {
            imageMatrix.SetPixel(c, r, color);
            foreach (Edge edge in AdjLists[r, c])
                imageMatrix.SetPixel(edge.Y, edge.X, color);
        }
        // Complexity Analysis : O(Number of pixels in the Shortest Path)
        public static void MouseDrawShortestPath(Bitmap ImageMatrix, RGBPixel color, KeyValuePair<int, int> Source, KeyValuePair<int, int> Destination, Queue<PixelColorAndPosition> queue) {
            int SourceRow = Source.Key;
            int SourceColumn = Source.Value;
            int CurrentRow = Destination.Key, CurrentColumn = Destination.Value;
            while (CurrentRow != SourceRow || CurrentColumn != SourceColumn) {
                queue.Enqueue(new PixelColorAndPosition(
                    CurrentColumn, CurrentRow,
                    ImageMatrix.GetPixel(CurrentColumn, CurrentRow)));
                ImageMatrix.SetPixel(CurrentColumn, CurrentRow,
                    Color.FromArgb(color.red, color.green, color.blue));
                KeyValuePair<int, int> ParentPosition = Graph.Parent[CurrentRow, CurrentColumn];
                CurrentRow = ParentPosition.Key;
                CurrentColumn = ParentPosition.Value;
            }
            queue.Enqueue(new PixelColorAndPosition(
                    CurrentColumn, CurrentRow,
                    ImageMatrix.GetPixel(CurrentColumn, CurrentRow)));
            ImageMatrix.SetPixel(CurrentColumn, CurrentRow,
                Color.FromArgb(color.red, color.green, color.blue));
        }

        // Complexity Analysis : O(Number of pixels in the Shortest Path)
        public static void MouseUndrawShortestPath(Bitmap ImageMatrix, Queue<PixelColorAndPosition> queue) {
            while (queue.Count > 0) {
                var pixel = queue.Dequeue();
                ImageMatrix.SetPixel(pixel.X, pixel.Y, pixel.Color);
            }
        }
    }

    class Node : IComparable
    {
        public readonly int X, Y;
        public readonly double Cost;

        public Node(int X, int Y, double Cost)
        {
            this.X = X;
            this.Y = Y;
            this.Cost = Cost;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Node other = (Node)obj;

            if (this.Cost == other.Cost)
            {
                if (this.X == other.X)
                {
                    return this.Y - other.Y;
                }
                else {
                    return this.X - other.X;
                }
            }
            else if (this.Cost > other.Cost)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

    class Edge
    {
        public readonly int X, Y;
        public readonly double Weight;
        public Edge(int X, int Y, double Weight)
        {
            this.X = X;
            this.Y = Y;
            this.Weight = Weight;
        }
    }
}
