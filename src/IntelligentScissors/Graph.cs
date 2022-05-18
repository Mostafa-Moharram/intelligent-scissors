using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace IntelligentScissors
{
    class Graph
    {

        public static double[,] ShortestPath;
        public static KeyValuePair<int, int>[,] Parent;
        public static ArrayList[,] AdjLists;

        public static void Construct(RGBPixel[,] ImageMatrix)
        {
            int width = ImageOperations.GetWidth(ImageMatrix);
            int height = ImageOperations.GetHeight(ImageMatrix);
            Graph.AdjLists = new ArrayList[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Graph.AdjLists[i, j] = new ArrayList();
                }
            }
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Vector2D vector = ImageOperations.CalculatePixelEnergies(i, j, ImageMatrix);

                    if (i != height - 1)
                    {
                        Graph.AdjLists[i, j].Add(new Edge(i + 1, j, 1 / vector.Y));
                        Graph.AdjLists[i + 1, j].Add(new Edge(i, j, 1 / vector.Y));
                    }
                    if (j != width - 1)
                    {
                        Graph.AdjLists[i, j].Add(new Edge(i, j + 1, 1 / vector.X));
                        Graph.AdjLists[i, j + 1].Add(new Edge(i, j, 1 / vector.X));
                    }
                }
            }
        }
        
        public static void CalculateShortestPath(RGBPixel[,] ImageMatrix, ArrayList Anchors)
        {
            int height = ImageOperations.GetHeight(ImageMatrix);
            int width = ImageOperations.GetWidth(ImageMatrix);
            ShortestPath = new double [height, width];
            Parent = new KeyValuePair<int, int>[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    ShortestPath[i, j] = double.PositiveInfinity;
                }
            }
            var Nodes = new SortedSet<Node>();
            var sourcePosition = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            var destinationPosition = (KeyValuePair<int, int>)Anchors[Anchors.Count - 2];
            int destinationRow = destinationPosition.Key, destinationColumn = destinationPosition.Value;
            Node source = new Node(sourcePosition.Key, sourcePosition.Value, 0.0);
            Parent[source.X, source.Y] = new KeyValuePair<int, int>(source.X, source.Y);
            ShortestPath[source.X, source.Y] = source.Cost;
            Nodes.Add(source);
            while (Nodes.Count != 0) {
            
                Node node = Nodes.Min();
                Nodes.Remove(node);
                if (node.X == destinationRow && node.Y == destinationColumn)
                {
                    break;
                }
                if (ShortestPath[node.X, node.Y] < node.Cost)
                {
                    continue;
                }
                foreach (Edge edge in AdjLists[node.X, node.Y])
                {
                    var newCost = node.Cost + edge.Weight;
                    System.Diagnostics.Debug.Assert(edge.Weight != double.PositiveInfinity);
                    if (newCost < ShortestPath[edge.X, edge.Y])
                    {
                        ShortestPath[edge.X, edge.Y] = newCost;
                        Parent[edge.X, edge.Y] = new KeyValuePair<int, int>(node.X, node.Y);
                        Nodes.Add(new Node(edge.X, edge.Y, newCost));
                    }
                }
            }
        }

        public static void DrawShortestPath(RGBPixel[,] ImageMatrix, ArrayList Anchors, RGBPixel PixelColor)
        {
            KeyValuePair<int, int> Source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            KeyValuePair<int, int> Destination = (KeyValuePair<int, int>)Anchors[Anchors.Count - 2];
            int SourceRow = Source.Key;
            int SourceColumn = Source.Value;
            int CurrentRow = Destination.Key, CurrentColumn = Destination.Value;
            while (CurrentRow != SourceRow || CurrentColumn != SourceColumn)
            {
                ImageMatrix[CurrentRow, CurrentColumn] = PixelColor;
                TestOutput.Path.Push(new KeyValuePair<int, int>(CurrentRow, CurrentColumn));
                KeyValuePair<int, int> ParentPosition = Graph.Parent[CurrentRow, CurrentColumn];
                CurrentRow = ParentPosition.Key;
                CurrentColumn = ParentPosition.Value;
            }
            ImageMatrix[CurrentRow, CurrentColumn] = PixelColor;
            TestOutput.Path.Push(new KeyValuePair<int, int>(CurrentRow, CurrentColumn));
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
