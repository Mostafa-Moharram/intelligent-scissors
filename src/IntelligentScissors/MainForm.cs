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
        static Queue<PixelColorAndPosition> MouseMovePath = new Queue<PixelColorAndPosition>();
        static bool SelectionEnabled;
        static KeyValuePair<int, int> LastValidSelectionPoint;

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
                clearSelectionButton.Enabled = true;
                testTypeGroupBox.Enabled = false;
                panel1.Enabled = true;
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, 3, 1);
                DateTime StartTime = DateTime.Now;
                Graph.Construct(ImageMatrix);
                double ConstructionTime = (DateTime.Now - StartTime).TotalSeconds;
                int Width = ImageOperations.GetWidth(ImageMatrix);
                int Height = ImageOperations.GetHeight(ImageMatrix);
                TestOutput.OutputGraph(Graph.AdjLists, Height, Width, ConstructionTime);
                clearSelection(pictureBox1);
            }
        }

        private static void clearSelection(PictureBox pictureBox) {
            ImageOperations.DisplayImage(ImageMatrix, pictureBox);
            Anchors.Clear();
            TestOutput.Path.Clear();
            TestOutput.ShortestPathTime = 0;
            MouseMovePath.Clear();
            SelectionEnabled = true;
        }

        private void pirctureBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (!SelectionEnabled || Anchors.Count < 3) return;
            DateTime startTime = DateTime.Now;
            KeyValuePair<int, int> destination = (KeyValuePair<int, int>)Anchors[0];
            KeyValuePair<int, int> source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            if (!Graph.Contains(e.Y, e.X, destination.Key, destination.Value) ||
                !Graph.Contains(e.Y, e.X, source.Key, source.Value)) return;
            Graph.UpdateShortestPath(destination);
            Graph.DrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR,
                source, destination);
            pictureBox1.Refresh();
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            SelectionEnabled = false;
            TestOutput.PrintPath(ImageMatrix);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            if (!SelectionEnabled)
            {
                return;
            }
            Graph.Offset = (int)boxSideLengthNumericDomain.Value;
            autoSelectCheckBox.Enabled = false;
            boxSideLengthNumericDomain.Enabled = false;
            int anchorRow = e.Y;
            int anchorColumn = e.X;
            AddNewAnchor(anchorRow, anchorColumn);
        }

        private void AddNewAnchor(int anchorRow, int anchorColumn)
        {
            var anchor = new KeyValuePair<int, int>(anchorRow, anchorColumn);
            DateTime startTime = DateTime.Now;
            if (Anchors.Count == 0)
            {
                Anchors.Add(anchor);
                Graph.InitDijkstra(ImageMatrix, anchor);
            }
            else
            {
                var prvSource = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
                if (!Graph.Contains(prvSource.Key, prvSource.Value, anchor.Key, anchor.Value))
                {
                    TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
                    return;
                }
                Anchors.Add(anchor);
                Graph.InitDijkstra(ImageMatrix, anchor);
                Graph.UpdateShortestPath(prvSource);
                Graph.DrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR, anchor, prvSource);
                pictureBox1.Refresh();
            }
            MouseMovePath.Clear();
            TestOutput.ShortestPathTime += (DateTime.Now - startTime).TotalSeconds;
            LastValidSelectionPoint = anchor;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (!SelectionEnabled || Anchors.Count == 0) return;
            KeyValuePair<int, int> source = (KeyValuePair<int, int>)Anchors[Anchors.Count - 1];
            int sourceRow = source.Key;
            int sourceColumn = source.Value;
            int newPointRow = e.Y;
            int newPointColumn = e.X;
            if (!Graph.Contains(sourceRow, sourceColumn, newPointRow, newPointColumn))
            {
                if (autoSelectCheckBox.Checked)
                {
                    AddNewAnchor(LastValidSelectionPoint.Key, LastValidSelectionPoint.Value);
                }
            } else
            {
                KeyValuePair<int, int> destination = new KeyValuePair<int, int>(e.Y, e.X);
                Graph.MouseUndrawShortestPath((Bitmap)pictureBox1.Image, MouseMovePath);
                Graph.UpdateShortestPath(destination);
                Graph.MouseDrawShortestPath((Bitmap)pictureBox1.Image, ImageOperations.BLACK_COLOR, source, destination, MouseMovePath);
                pictureBox1.Refresh();
                LastValidSelectionPoint = destination;
            }
        }

        private void clearSelectionButton_Click(object sender, EventArgs e) {
            clearSelection(pictureBox1);
            autoSelectCheckBox.Enabled = true;
            boxSideLengthNumericDomain.Enabled = true;
        }

        private void autoSelectCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (autoSelectCheckBox.Checked)
                boxSideLengthNumericDomain.Value = Graph.AUTO_SELECT_DEFAULT_OFFSET;
            else
                boxSideLengthNumericDomain.Value = Graph.MANUAL_SELECT_DEFAULT_OFFSET;
        }
    }
}