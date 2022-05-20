namespace IntelligentScissors
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.testTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.completeTestFormatRadioButton = new System.Windows.Forms.RadioButton();
            this.sampleTestFormatRadioButton = new System.Windows.Forms.RadioButton();
            this.noTestRadioButton = new System.Windows.Forms.RadioButton();
            this.clearSelectionButton = new System.Windows.Forms.Button();
            this.autoSelectCheckBox = new System.Windows.Forms.CheckBox();
            this.boxSideLengthLabel = new System.Windows.Forms.Label();
            this.boxSideLengthNumericDomain = new System.Windows.Forms.NumericUpDown();
            this.selectColorButton = new System.Windows.Forms.Button();
            this.selectColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.testTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxSideLengthNumericDomain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(30, 419);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(212, 40);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(452, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pirctureBox1_MouseDoubleClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 375);
            this.panel1.TabIndex = 15;
            // 
            // testTypeGroupBox
            // 
            this.testTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testTypeGroupBox.Controls.Add(this.completeTestFormatRadioButton);
            this.testTypeGroupBox.Controls.Add(this.sampleTestFormatRadioButton);
            this.testTypeGroupBox.Controls.Add(this.noTestRadioButton);
            this.testTypeGroupBox.Location = new System.Drawing.Point(249, 395);
            this.testTypeGroupBox.Name = "testTypeGroupBox";
            this.testTypeGroupBox.Size = new System.Drawing.Size(186, 117);
            this.testTypeGroupBox.TabIndex = 16;
            this.testTypeGroupBox.TabStop = false;
            this.testTypeGroupBox.Text = "Test Type";
            // 
            // completeTestFormatRadioButton
            // 
            this.completeTestFormatRadioButton.AutoSize = true;
            this.completeTestFormatRadioButton.Location = new System.Drawing.Point(15, 85);
            this.completeTestFormatRadioButton.Name = "completeTestFormatRadioButton";
            this.completeTestFormatRadioButton.Size = new System.Drawing.Size(161, 20);
            this.completeTestFormatRadioButton.TabIndex = 2;
            this.completeTestFormatRadioButton.TabStop = true;
            this.completeTestFormatRadioButton.Text = "Complete Test Format";
            this.completeTestFormatRadioButton.UseVisualStyleBackColor = true;
            // 
            // sampleTestFormatRadioButton
            // 
            this.sampleTestFormatRadioButton.AutoSize = true;
            this.sampleTestFormatRadioButton.Location = new System.Drawing.Point(15, 53);
            this.sampleTestFormatRadioButton.Name = "sampleTestFormatRadioButton";
            this.sampleTestFormatRadioButton.Size = new System.Drawing.Size(150, 20);
            this.sampleTestFormatRadioButton.TabIndex = 1;
            this.sampleTestFormatRadioButton.TabStop = true;
            this.sampleTestFormatRadioButton.Text = "Sample Test Format";
            this.sampleTestFormatRadioButton.UseVisualStyleBackColor = true;
            // 
            // noTestRadioButton
            // 
            this.noTestRadioButton.AutoSize = true;
            this.noTestRadioButton.Checked = true;
            this.noTestRadioButton.Location = new System.Drawing.Point(15, 21);
            this.noTestRadioButton.Name = "noTestRadioButton";
            this.noTestRadioButton.Size = new System.Drawing.Size(76, 20);
            this.noTestRadioButton.TabIndex = 0;
            this.noTestRadioButton.TabStop = true;
            this.noTestRadioButton.Tag = "";
            this.noTestRadioButton.Text = "No Test";
            this.noTestRadioButton.UseVisualStyleBackColor = true;
            // 
            // clearSelectionButton
            // 
            this.clearSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearSelectionButton.Enabled = false;
            this.clearSelectionButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearSelectionButton.Location = new System.Drawing.Point(30, 459);
            this.clearSelectionButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearSelectionButton.Name = "clearSelectionButton";
            this.clearSelectionButton.Size = new System.Drawing.Size(212, 40);
            this.clearSelectionButton.TabIndex = 17;
            this.clearSelectionButton.Text = "Clear Selection";
            this.clearSelectionButton.UseVisualStyleBackColor = true;
            this.clearSelectionButton.Click += new System.EventHandler(this.clearSelectionButton_Click);
            // 
            // autoSelectCheckBox
            // 
            this.autoSelectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoSelectCheckBox.AutoSize = true;
            this.autoSelectCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSelectCheckBox.Location = new System.Drawing.Point(441, 405);
            this.autoSelectCheckBox.Name = "autoSelectCheckBox";
            this.autoSelectCheckBox.Size = new System.Drawing.Size(108, 20);
            this.autoSelectCheckBox.TabIndex = 18;
            this.autoSelectCheckBox.Text = "Auto Select";
            this.autoSelectCheckBox.UseVisualStyleBackColor = true;
            this.autoSelectCheckBox.CheckedChanged += new System.EventHandler(this.autoSelectCheckBox_CheckedChanged);
            // 
            // boxSideLengthLabel
            // 
            this.boxSideLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxSideLengthLabel.AutoSize = true;
            this.boxSideLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSideLengthLabel.Location = new System.Drawing.Point(441, 433);
            this.boxSideLengthLabel.Name = "boxSideLengthLabel";
            this.boxSideLengthLabel.Size = new System.Drawing.Size(119, 16);
            this.boxSideLengthLabel.TabIndex = 19;
            this.boxSideLengthLabel.Text = "Box Side Length";
            // 
            // boxSideLengthNumericDomain
            // 
            this.boxSideLengthNumericDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxSideLengthNumericDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSideLengthNumericDomain.Location = new System.Drawing.Point(444, 457);
            this.boxSideLengthNumericDomain.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.boxSideLengthNumericDomain.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.boxSideLengthNumericDomain.Name = "boxSideLengthNumericDomain";
            this.boxSideLengthNumericDomain.ReadOnly = true;
            this.boxSideLengthNumericDomain.Size = new System.Drawing.Size(120, 22);
            this.boxSideLengthNumericDomain.TabIndex = 20;
            this.boxSideLengthNumericDomain.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // selectColorButton
            // 
            this.selectColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectColorButton.BackColor = System.Drawing.Color.Black;
            this.selectColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectColorButton.ForeColor = System.Drawing.Color.White;
            this.selectColorButton.Location = new System.Drawing.Point(444, 484);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(120, 28);
            this.selectColorButton.TabIndex = 21;
            this.selectColorButton.Text = "Select Color";
            this.selectColorButton.UseVisualStyleBackColor = false;
            this.selectColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 521);
            this.Controls.Add(this.selectColorButton);
            this.Controls.Add(this.boxSideLengthNumericDomain);
            this.Controls.Add(this.boxSideLengthLabel);
            this.Controls.Add(this.autoSelectCheckBox);
            this.Controls.Add(this.clearSelectionButton);
            this.Controls.Add(this.testTypeGroupBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpen);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Intelligent Scissors...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.testTypeGroupBox.ResumeLayout(false);
            this.testTypeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxSideLengthNumericDomain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox testTypeGroupBox;
        private System.Windows.Forms.RadioButton completeTestFormatRadioButton;
        private System.Windows.Forms.RadioButton sampleTestFormatRadioButton;
        private System.Windows.Forms.RadioButton noTestRadioButton;
        private System.Windows.Forms.Button clearSelectionButton;
        private System.Windows.Forms.CheckBox autoSelectCheckBox;
        private System.Windows.Forms.Label boxSideLengthLabel;
        private System.Windows.Forms.NumericUpDown boxSideLengthNumericDomain;
        private System.Windows.Forms.Button selectColorButton;
        private System.Windows.Forms.ColorDialog selectColorDialog;
    }
}

