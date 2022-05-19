using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace IntelligentScissors
{
    class TestOutput
    {
        public enum TestType {
            NoTest, SampleTest, CompleteTest
        };
        public static TestType PrintTestType = TestType.NoTest;
        public static Queue<KeyValuePair<int, int>> Path = new Queue<KeyValuePair<int, int>>();
        public static double ShortestPathTime; // time in seconds
        public static void OutputGraph(ArrayList[,] AdjLists, int Height, int Width, int Time) {
            switch (PrintTestType) {
                case TestType.SampleTest:
                    OutputGraphInSampleTestsFormat(AdjLists, Height, Width);
                    break;
                case TestType.CompleteTest:
                    OutputGraphInCompleteTestsFormat(AdjLists, Height, Width, Time);
                    break;
            }
        }
        public static void OutputPath(RGBPixel[,] ImageMatrix) {
            switch (PrintTestType) {
                case TestType.SampleTest:
                    PrintPathInSampleTestsFormat(ImageMatrix);
                    break;
                case TestType.CompleteTest:
                    PrintPathInCompleteTestsFormat(ImageMatrix);
                    break;
            }
        }
        public static void OutputGraphInSampleTestsFormat(ArrayList[,] AdjLists, int Height, int Width)
        {
            string file_name = "sample-output.txt";
            StreamWriter streamWriter = new StreamWriter(file_name);
            streamWriter.WriteLine("The constructed graph\n");

            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    int node_index = i * Width + j;
                    streamWriter.WriteLine($" The  index node{node_index}");
                    streamWriter.WriteLine("Edges");
                    foreach (Edge edge in AdjLists[i, j])
                    {
                        int next_node_index = edge.X * Width + edge.Y;
                        streamWriter.WriteLine($"edge from   {node_index}  To  {next_node_index}  With Weights  {edge.Weight}");
                    }
                    streamWriter.Write("\n\n\n");
                }
            }
            streamWriter.Close();
        }
        public static void PrintPathInSampleTestsFormat(RGBPixel[,] ImageMatrix)
        {
            int width = ImageOperations.GetWidth(ImageMatrix);
            string file_name = "sample-path.txt";
            StreamWriter streamWriter = new StreamWriter(file_name);
            while (Path.Count > 0)
            {
                KeyValuePair<int, int> node = Path.Dequeue();
                int row = node.Key;
                int column = node.Value;
                int node_index = row * width + column;
                streamWriter.WriteLine($"Node  {node_index} at position x {row} at position y   {column}");
            }
            streamWriter.Close();
        }

        public static void OutputGraphInCompleteTestsFormat(ArrayList[,] AdjLists, int Height, int Width, double time)
        {
            string file_name = "complete-output.txt";
            StreamWriter streamWriter = new StreamWriter(file_name);
            streamWriter.WriteLine("Constructed Graph: (Format: node_index|edges:(from, to, weight)... )\n");

            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    int node_index = i * Width + j;
                    streamWriter.Write($"{node_index}|edges:");
                    foreach (Edge edge in AdjLists[i, j])
                    {
                        int next_node_index = edge.X * Width + edge.Y;
                        streamWriter.Write($"({node_index},{next_node_index},{edge.Weight})");
                    }
                    streamWriter.WriteLine();
                }
            }
            streamWriter.WriteLine($"Graph construction took: {time} seconds.");
            streamWriter.Close();
        }

        public static void PrintPathInCompleteTestsFormat(RGBPixel[,] ImageMatrix)
        {
            int width = ImageOperations.GetWidth(ImageMatrix);
            string file_name = "complete-path.txt";
            StreamWriter streamWriter = new StreamWriter(file_name);
            var source = (KeyValuePair<int, int>)MainForm.Anchors[0];
            var destination = (KeyValuePair<int, int>)MainForm.Anchors[MainForm.Anchors.Count - 2];
            int source_row = source.Key, source_column = source.Value;
            int destination_row = destination.Key, destination_column = destination.Value;
            int source_index = source_row * width + source_column;
            int destination_index = destination_row * width + destination_column;
            streamWriter.WriteLine($"The Shortest path from Node {source_index}"
                + $" at ({source_row}, {source_column}) to Node {destination_index} at ({destination_row}, {destination_column})");
            streamWriter.WriteLine("Format: (node_index, x, y)");
            while (Path.Count > 0)
            {
                KeyValuePair<int, int> node = Path.Dequeue();
                int row = node.Key;
                int column = node.Value;
                streamWriter.WriteLine($"{{X = {row},Y = {column}}},{row},{column})");
            }
            streamWriter.WriteLine($"Path construction took: {ShortestPathTime} seconds.");
            streamWriter.Close();
        }
    }

}
