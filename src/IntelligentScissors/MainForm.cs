using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace IntelligentScissors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static RGBPixel[,] ImageMatrix;
        public static ArrayList Anchors = new ArrayList();
        Queue<PixelColorAndPosition> mouseMovePath = new Queue<PixelColorAndPosition>();
        bool selectionEnabled = true;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (noTestRadioButton.Checked)
                    TestOutput.PrintTestType = TestOutput.TestType.NoTest;
                else if (sampleTestFormatRadioButton.Checked)
                    TestOutput.PrintTestType = TestOutput.TestType.SampleTest;
                else if (completeTestFormatRadioButton.Checked)
                    TestOutput.PrintTestType = TestOutput.TestType.CompleteTest;
                testTypeGroupBox.Enabled = false;
                panel1.Enabled = true;
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
                DateTime StartTime = DateTime.Now;
                Graph.Construct(ImageMatrix);
                double ConstructionTime = (DateTime.Now - StartTime).TotalSeconds;
                int Width = ImageOperations.GetWidth(ImageMatrix);
                int Height = ImageOperations.GetHeight(ImageMatrix);
                TestOutput.OutputGraph(Graph.AdjLists, Height, Width, ConstructionTime);
                Anchors.Clear();
                TestOutput.Path.Clear();
                TestOutput.ShortestPathTime = 0;
                mouseMovePath.Clear();
                selectionEnabled = true;
            }
        }

        private void pirctureBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (!selectionEnabled || Anchors.Count < 2) return;
            DateTime startTime = DateTime.Now;
            KeyValuePair<int, int> destination = (KeyValuePair<int, int>)Anchors[0];
            KeyValuePair<int, int> source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            if (!Graph.Contains(e.Y, e.X, destination.Key, destination.Value) ||
                !Graph.Contains(e.Y, e.X, source.Key, source.Value)) return;
            Graph.DrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR,
                source, destination);
            pictureBox1.Refresh();
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            selectionEnabled = false;
            TestOutput.PrintPath(ImageMatrix);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            if (!selectionEnabled)
            {
                return;
            }
            DateTime startTime = DateTime.Now;
            int anchorRow = e.Y;
            int anchorColumn = e.X;
            var newSource = new KeyValuePair<int, int>(anchorRow, anchorColumn);
            if (Anchors.Count == 0) {
                Anchors.Add(newSource);
                Graph.InitDijkstra(ImageMatrix, newSource);
            } else {
                var prvSource = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
                if (!Graph.Contains(prvSource.Key, prvSource.Value, newSource.Key, newSource.Value))
                {
                    TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
                    return;
                }
                Anchors.Add(newSource);
                Graph.InitDijkstra(ImageMatrix, newSource);
                Graph.UpdateShortestPath(prvSource);
                Graph.DrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR, newSource, prvSource);
                pictureBox1.Refresh();
            }
            mouseMovePath.Clear();
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (!selectionEnabled || Anchors.Count == 0) return;
            KeyValuePair<int, int> source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            if (!Graph.Contains(source.Key, source.Value, e.Y, e.X))
                return;
            KeyValuePair<int, int> destination = new KeyValuePair<int, int>(e.Y, e.X);
            Graph.MouseUndrawShortestPath((Bitmap)pictureBox1.Image, mouseMovePath);
            Graph.UpdateShortestPath(destination);
            Graph.MouseDrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR, source, destination, mouseMovePath);
            pictureBox1.Refresh();
        }
    }
}