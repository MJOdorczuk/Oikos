namespace Oikos.Controls
{
    partial class WorldGenerationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumOfBiomesCounter = new System.Windows.Forms.NumericUpDown();
            this.NumOfBiomesLabel = new System.Windows.Forms.Label();
            this.NumOfSpecLabel = new System.Windows.Forms.Label();
            this.NumOfSpecCounter = new System.Windows.Forms.NumericUpDown();
            this.NumOfAllSpeciesLabel = new System.Windows.Forms.Label();
            this.NumOfAllSpeciesBox = new System.Windows.Forms.TextBox();
            this.GenerateSpeciesButton = new System.Windows.Forms.Button();
            this.GenerateWorldButton = new System.Windows.Forms.Button();
            this.MaxAngleLabel = new System.Windows.Forms.Label();
            this.MaxHeightCounter = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfBiomesCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfSpecCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxHeightCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // NumOfBiomesCounter
            // 
            this.NumOfBiomesCounter.Location = new System.Drawing.Point(4, 4);
            this.NumOfBiomesCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumOfBiomesCounter.Name = "NumOfBiomesCounter";
            this.NumOfBiomesCounter.Size = new System.Drawing.Size(120, 20);
            this.NumOfBiomesCounter.TabIndex = 0;
            this.NumOfBiomesCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumOfBiomesCounter.ValueChanged += new System.EventHandler(this.NumOfBiomesCounter_ValueChanged);
            // 
            // NumOfBiomesLabel
            // 
            this.NumOfBiomesLabel.AutoSize = true;
            this.NumOfBiomesLabel.Location = new System.Drawing.Point(131, 4);
            this.NumOfBiomesLabel.Name = "NumOfBiomesLabel";
            this.NumOfBiomesLabel.Size = new System.Drawing.Size(92, 13);
            this.NumOfBiomesLabel.TabIndex = 1;
            this.NumOfBiomesLabel.Text = "Number of biomes";
            // 
            // NumOfSpecLabel
            // 
            this.NumOfSpecLabel.AutoSize = true;
            this.NumOfSpecLabel.Location = new System.Drawing.Point(131, 56);
            this.NumOfSpecLabel.Name = "NumOfSpecLabel";
            this.NumOfSpecLabel.Size = new System.Drawing.Size(184, 13);
            this.NumOfSpecLabel.TabIndex = 5;
            this.NumOfSpecLabel.Text = "Number of random generated species";
            // 
            // NumOfSpecCounter
            // 
            this.NumOfSpecCounter.Location = new System.Drawing.Point(4, 56);
            this.NumOfSpecCounter.Name = "NumOfSpecCounter";
            this.NumOfSpecCounter.Size = new System.Drawing.Size(120, 20);
            this.NumOfSpecCounter.TabIndex = 4;
            this.NumOfSpecCounter.ValueChanged += new System.EventHandler(this.NumOfSpecCounter_ValueChanged);
            // 
            // NumOfAllSpeciesLabel
            // 
            this.NumOfAllSpeciesLabel.AutoSize = true;
            this.NumOfAllSpeciesLabel.Location = new System.Drawing.Point(3, 79);
            this.NumOfAllSpeciesLabel.Name = "NumOfAllSpeciesLabel";
            this.NumOfAllSpeciesLabel.Size = new System.Drawing.Size(108, 13);
            this.NumOfAllSpeciesLabel.TabIndex = 6;
            this.NumOfAllSpeciesLabel.Text = "Number of all species";
            // 
            // NumOfAllSpeciesBox
            // 
            this.NumOfAllSpeciesBox.Enabled = false;
            this.NumOfAllSpeciesBox.Location = new System.Drawing.Point(6, 95);
            this.NumOfAllSpeciesBox.Name = "NumOfAllSpeciesBox";
            this.NumOfAllSpeciesBox.Size = new System.Drawing.Size(100, 20);
            this.NumOfAllSpeciesBox.TabIndex = 7;
            // 
            // GenerateSpeciesButton
            // 
            this.GenerateSpeciesButton.Location = new System.Drawing.Point(3, 667);
            this.GenerateSpeciesButton.Name = "GenerateSpeciesButton";
            this.GenerateSpeciesButton.Size = new System.Drawing.Size(160, 30);
            this.GenerateSpeciesButton.TabIndex = 8;
            this.GenerateSpeciesButton.Text = "NEW SPECIES";
            this.GenerateSpeciesButton.UseVisualStyleBackColor = true;
            this.GenerateSpeciesButton.Click += new System.EventHandler(this.GenerateSpeciesButton_Click);
            // 
            // GenerateWorldButton
            // 
            this.GenerateWorldButton.Location = new System.Drawing.Point(187, 667);
            this.GenerateWorldButton.Name = "GenerateWorldButton";
            this.GenerateWorldButton.Size = new System.Drawing.Size(160, 30);
            this.GenerateWorldButton.TabIndex = 9;
            this.GenerateWorldButton.Text = "GENERATE WORLD";
            this.GenerateWorldButton.UseVisualStyleBackColor = true;
            this.GenerateWorldButton.Click += new System.EventHandler(this.GenerateWorldButton_Click);
            // 
            // MaxAngleLabel
            // 
            this.MaxAngleLabel.AutoSize = true;
            this.MaxAngleLabel.Location = new System.Drawing.Point(131, 30);
            this.MaxAngleLabel.Name = "MaxAngleLabel";
            this.MaxAngleLabel.Size = new System.Drawing.Size(152, 13);
            this.MaxAngleLabel.TabIndex = 11;
            this.MaxAngleLabel.Text = "Angualr height of the continent";
            // 
            // MaxHeightCounter
            // 
            this.MaxHeightCounter.Location = new System.Drawing.Point(4, 30);
            this.MaxHeightCounter.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.MaxHeightCounter.Name = "MaxHeightCounter";
            this.MaxHeightCounter.Size = new System.Drawing.Size(120, 20);
            this.MaxHeightCounter.TabIndex = 10;
            this.MaxHeightCounter.ValueChanged += new System.EventHandler(this.MaxHeightCounter_ValueChanged);
            // 
            // WorldGenerationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MaxAngleLabel);
            this.Controls.Add(this.MaxHeightCounter);
            this.Controls.Add(this.GenerateWorldButton);
            this.Controls.Add(this.GenerateSpeciesButton);
            this.Controls.Add(this.NumOfAllSpeciesBox);
            this.Controls.Add(this.NumOfAllSpeciesLabel);
            this.Controls.Add(this.NumOfSpecLabel);
            this.Controls.Add(this.NumOfSpecCounter);
            this.Controls.Add(this.NumOfBiomesLabel);
            this.Controls.Add(this.NumOfBiomesCounter);
            this.Name = "WorldGenerationControl";
            this.Size = new System.Drawing.Size(350, 700);
            this.Load += new System.EventHandler(this.WorldGenerationControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumOfBiomesCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfSpecCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxHeightCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumOfBiomesCounter;
        private System.Windows.Forms.Label NumOfBiomesLabel;
        private System.Windows.Forms.Label NumOfSpecLabel;
        private System.Windows.Forms.NumericUpDown NumOfSpecCounter;
        private System.Windows.Forms.Label NumOfAllSpeciesLabel;
        private System.Windows.Forms.TextBox NumOfAllSpeciesBox;
        private System.Windows.Forms.Button GenerateSpeciesButton;
        private System.Windows.Forms.Button GenerateWorldButton;
        private System.Windows.Forms.Label MaxAngleLabel;
        private System.Windows.Forms.NumericUpDown MaxHeightCounter;
    }
}
