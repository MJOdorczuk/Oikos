namespace Oikos.Controls
{
    partial class GeneControl
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
            this.GeneNameLabel = new System.Windows.Forms.Label();
            this.GeneValueBox = new System.Windows.Forms.TextBox();
            this.GeneTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.GeneTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneNameLabel
            // 
            this.GeneNameLabel.AutoSize = true;
            this.GeneNameLabel.Location = new System.Drawing.Point(209, 3);
            this.GeneNameLabel.Name = "GeneNameLabel";
            this.GeneNameLabel.Size = new System.Drawing.Size(64, 13);
            this.GeneNameLabel.TabIndex = 19;
            this.GeneNameLabel.Text = "Gene Name";
            // 
            // GeneValueBox
            // 
            this.GeneValueBox.Enabled = false;
            this.GeneValueBox.Location = new System.Drawing.Point(209, 19);
            this.GeneValueBox.MaxLength = 100;
            this.GeneValueBox.Name = "GeneValueBox";
            this.GeneValueBox.Size = new System.Drawing.Size(100, 20);
            this.GeneValueBox.TabIndex = 18;
            // 
            // GeneTrackBar
            // 
            this.GeneTrackBar.Location = new System.Drawing.Point(3, 3);
            this.GeneTrackBar.Maximum = 25;
            this.GeneTrackBar.Name = "GeneTrackBar";
            this.GeneTrackBar.Size = new System.Drawing.Size(200, 45);
            this.GeneTrackBar.TabIndex = 17;
            this.GeneTrackBar.Scroll += new System.EventHandler(this.GeneTrackBar_Scroll);
            // 
            // GeneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GeneNameLabel);
            this.Controls.Add(this.GeneValueBox);
            this.Controls.Add(this.GeneTrackBar);
            this.Name = "GeneControl";
            this.Size = new System.Drawing.Size(350, 50);
            ((System.ComponentModel.ISupportInitialize)(this.GeneTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GeneNameLabel;
        private System.Windows.Forms.TextBox GeneValueBox;
        private System.Windows.Forms.TrackBar GeneTrackBar;
    }
}
