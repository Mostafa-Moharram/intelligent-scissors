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

        RGBPixel[,] ImageMatrix;
        public static ArrayList Anchors = new ArrayList();

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

        private void pirctureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime startTime = DateTime.Now;
            Anchors.Add(Anchors[0]);
            Graph.CalculateShortestPath(ImageMatrix, Anchors);
            Graph.DrawShortestPath(ImageMatrix, Anchors, ImageOperations.BLACK_COLOR);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            TestOutput.PrintPathInCompleteTestsFormat(ImageMatrix);
            //System.Diagnostics.Debug.WriteLine("Double Click");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            DateTime startTime = DateTime.Now;
            int anchorRow = e.Y;
            int anchorColumn = e.X;
            Anchors.Add(new KeyValuePair<int, int>(anchorRow, anchorColumn));
            if (Anchors.Count > 1)
            {
                Graph.CalculateShortestPath(ImageMatrix, Anchors);
                Graph.DrawShortestPath(ImageMatrix, Anchors, ImageOperations.BLACK_COLOR);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            //System.Diagnostics.Debug.WriteLine("Single Click");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (Anchors.Count == 0) return;

        }
    }
}