namespace Oikos.Controls
{
    partial class ClimateControl
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
            this.TempDiffLabel = new System.Windows.Forms.Label();
            this.TempDiffBox = new System.Windows.Forms.TextBox();
            this.ATempLabel = new System.Windows.Forms.Label();
            this.ATempBox = new System.Windows.Forms.TextBox();
            this.TempFluctLabel = new System.Windows.Forms.Label();
            this.TempFluctBox = new System.Windows.Forms.TextBox();
            this.TempDiffBar = new System.Windows.Forms.TrackBar();
            this.ATempBar = new System.Windows.Forms.TrackBar();
            this.TempFluctBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.TempDiffBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATempBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempFluctBar)).BeginInit();
            this.SuspendLayout();
            // 
            // TempDiffLabel
            // 
            this.TempDiffLabel.AutoSize = true;
            this.TempDiffLabel.Location = new System.Drawing.Point(206, 105);
            this.TempDiffLabel.Name = "TempDiffLabel";
            this.TempDiffLabel.Size = new System.Drawing.Size(117, 13);
            this.TempDiffLabel.TabIndex = 17;
            this.TempDiffLabel.Text = "Temperature difference";
            // 
            // TempDiffBox
            // 
            this.TempDiffBox.Enabled = false;
            this.TempDiffBox.Location = new System.Drawing.Point(209, 121);
            this.TempDiffBox.MaxLength = 100;
            this.TempDiffBox.Name = "TempDiffBox";
            this.TempDiffBox.Size = new System.Drawing.Size(100, 20);
            this.TempDiffBox.TabIndex = 16;
            // 
            // ATempLabel
            // 
            this.ATempLabel.AutoSize = true;
            this.ATempLabel.Location = new System.Drawing.Point(206, 54);
            this.ATempLabel.Name = "ATempLabel";
            this.ATempLabel.Size = new System.Drawing.Size(106, 13);
            this.ATempLabel.TabIndex = 15;
            this.ATempLabel.Text = "Average temperature";
            // 
            // ATempBox
            // 
            this.ATempBox.Enabled = false;
            this.ATempBox.Location = new System.Drawing.Point(209, 70);
            this.ATempBox.MaxLength = 100;
            this.ATempBox.Name = "ATempBox";
            this.ATempBox.Size = new System.Drawing.Size(100, 20);
            this.ATempBox.TabIndex = 14;
            // 
            // TempFluctLabel
            // 
            this.TempFluctLabel.AutoSize = true;
            this.TempFluctLabel.Location = new System.Drawing.Point(209, 3);
            this.TempFluctLabel.Name = "TempFluctLabel";
            this.TempFluctLabel.Size = new System.Drawing.Size(119, 13);
            this.TempFluctLabel.TabIndex = 13;
            this.TempFluctLabel.Text = "Temperature fluctuation";
            // 
            // TempFluctBox
            // 
            this.TempFluctBox.Enabled = false;
            this.TempFluctBox.Location = new System.Drawing.Point(209, 19);
            this.TempFluctBox.MaxLength = 100;
            this.TempFluctBox.Name = "TempFluctBox";
            this.TempFluctBox.Size = new System.Drawing.Size(100, 20);
            this.TempFluctBox.TabIndex = 12;
            this.TempFluctBox.TextChanged += new System.EventHandler(this.TempFluctBox_TextChanged);
            // 
            // TempDiffBar
            // 
            this.TempDiffBar.Location = new System.Drawing.Point(3, 105);
            this.TempDiffBar.Maximum = 25;
            this.TempDiffBar.Name = "TempDiffBar";
            this.TempDiffBar.Size = new System.Drawing.Size(200, 45);
            this.TempDiffBar.TabIndex = 11;
            this.TempDiffBar.Scroll += new System.EventHandler(this.TempDiffBar_Scroll);
            // 
            // ATempBar
            // 
            this.ATempBar.Location = new System.Drawing.Point(3, 54);
            this.ATempBar.Maximum = 25;
            this.ATempBar.Name = "ATempBar";
            this.ATempBar.Size = new System.Drawing.Size(200, 45);
            this.ATempBar.TabIndex = 10;
            this.ATempBar.Scroll += new System.EventHandler(this.ATempBar_Scroll);
            // 
            // TempFluctBar
            // 
            this.TempFluctBar.Location = new System.Drawing.Point(3, 3);
            this.TempFluctBar.Maximum = 25;
            this.TempFluctBar.Name = "TempFluctBar";
            this.TempFluctBar.Size = new System.Drawing.Size(200, 45);
            this.TempFluctBar.TabIndex = 9;
            this.TempFluctBar.Scroll += new System.EventHandler(this.TempFluctBar_Scroll);
            // 
            // ClimateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TempDiffLabel);
            this.Controls.Add(this.TempDiffBox);
            this.Controls.Add(this.ATempLabel);
            this.Controls.Add(this.ATempBox);
            this.Controls.Add(this.TempFluctLabel);
            this.Controls.Add(this.TempFluctBox);
            this.Controls.Add(this.TempDiffBar);
            this.Controls.Add(this.ATempBar);
            this.Controls.Add(this.TempFluctBar);
            this.Name = "ClimateControl";
            this.Size = new System.Drawing.Size(350, 150);
            ((System.ComponentModel.ISupportInitialize)(this.TempDiffBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATempBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempFluctBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TempDiffLabel;
        private System.Windows.Forms.TextBox TempDiffBox;
        private System.Windows.Forms.Label ATempLabel;
        private System.Windows.Forms.TextBox ATempBox;
        private System.Windows.Forms.Label TempFluctLabel;
        private System.Windows.Forms.TextBox TempFluctBox;
        private System.Windows.Forms.TrackBar TempDiffBar;
        private System.Windows.Forms.TrackBar ATempBar;
        private System.Windows.Forms.TrackBar TempFluctBar;
    }
}
