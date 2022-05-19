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
        Queue<PixelColorAndPosition> values = new Queue<PixelColorAndPosition>();
        bool allowLiveWire = true;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
                DateTime StartTime = DateTime.Now;
                Graph.Construct(ImageMatrix);
                double ConstructionTime = (DateTime.Now - StartTime).TotalSeconds; 
                int Width = ImageOperations.GetWidth(ImageMatrix);
                int Height = ImageOperations.GetHeight(ImageMatrix);
                TestOutput.OutputGraphInCompleteTestsFormat(Graph.AdjLists, Height, Width, ConstructionTime);
                Anchors.Clear();
                TestOutput.Path.Clear();
                TestOutput.ShortestPathTime = 0;
            }
        }

        private void pirctureBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (Anchors.Count < 2) return;
            DateTime startTime = DateTime.Now;
            KeyValuePair<int, int> destination = (KeyValuePair<int, int>)Anchors[0];
            KeyValuePair<int, int> source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            if (!Graph.Contains(e.Y, e.X, destination.Key, destination.Value) ||
                !Graph.Contains(e.Y, e.X, source.Key, source.Value)) return;
            Graph.DrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR,
                source, destination);
            pictureBox1.Refresh();
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            allowLiveWire = false;
            TestOutput.PrintPathInCompleteTestsFormat(ImageMatrix);
            //System.Diagnostics.Debug.WriteLine("Double Click");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            DateTime startTime = DateTime.Now;
            int anchorRow = e.Y;
            int anchorColumn = e.X;
            var source = new KeyValuePair<int, int>(anchorRow, anchorColumn);
            var destination = new KeyValuePair<int, int>();
            if (Anchors.Count > 0) {
                destination = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
                if (!Graph.Contains(destination.Key, destination.Value, source.Key, source.Value)) {
                    TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
                    return;
                }
            }
            Anchors.Add(source);
            Graph.CalculateShortestPath(ImageMatrix, source);
            if (Anchors.Count > 1) {
                Graph.DrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR, source, destination);
                pictureBox1.Refresh();
            }
            values.Clear();
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            //System.Diagnostics.Debug.WriteLine("Single Click");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (!allowLiveWire || Anchors.Count == 0) return;
            KeyValuePair<int, int> source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            if (!Graph.Contains(source.Key, source.Value, e.Y, e.X))
                return;
            KeyValuePair<int, int> destination = new KeyValuePair<int, int>(e.Y, e.X);
            Graph.MouseUndrawShortestPath((Bitmap)pictureBox1.Image, values);
            Graph.MouseDrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR, source, destination, values);
            pictureBox1.Refresh();
        }
    }
}