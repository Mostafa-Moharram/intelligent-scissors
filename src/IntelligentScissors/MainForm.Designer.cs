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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.testTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(49, 415);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(132, 76);
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
            this.panel1.Size = new System.Drawing.Size(477, 375);
            this.panel1.TabIndex = 15;
            // 
            // testTypeGroupBox
            // 
            this.testTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testTypeGroupBox.Controls.Add(this.completeTestFormatRadioButton);
            this.testTypeGroupBox.Controls.Add(this.sampleTestFormatRadioButton);
            this.testTypeGroupBox.Controls.Add(this.noTestRadioButton);
            this.testTypeGroupBox.Location = new System.Drawing.Point(232, 395);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 521);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox testTypeGroupBox;
        private System.Windows.Forms.RadioButton completeTestFormatRadioButton;
        private System.Windows.Forms.RadioButton sampleTestFormatRadioButton;
        private System.Windows.Forms.RadioButton noTestRadioButton;
    }
}

