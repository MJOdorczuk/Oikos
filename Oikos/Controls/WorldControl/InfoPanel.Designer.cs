namespace Oikos.Controls.WorldControl
{
    partial class InfoPanel
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
            this.InfoNameLabel = new System.Windows.Forms.Label();
            this.InfoValueBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InfoNameLabel
            // 
            this.InfoNameLabel.AutoSize = true;
            this.InfoNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoNameLabel.Location = new System.Drawing.Point(4, 4);
            this.InfoNameLabel.Name = "InfoNameLabel";
            this.InfoNameLabel.Size = new System.Drawing.Size(51, 20);
            this.InfoNameLabel.TabIndex = 0;
            this.InfoNameLabel.Text = "label1";
            // 
            // InfoValueBox
            // 
            this.InfoValueBox.Enabled = false;
            this.InfoValueBox.Location = new System.Drawing.Point(200, 6);
            this.InfoValueBox.Name = "InfoValueBox";
            this.InfoValueBox.Size = new System.Drawing.Size(90, 20);
            this.InfoValueBox.TabIndex = 1;
            this.InfoValueBox.TextChanged += new System.EventHandler(this.InfoValueBox_TextChanged);
            // 
            // InfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InfoValueBox);
            this.Controls.Add(this.InfoNameLabel);
            this.Name = "InfoPanel";
            this.Size = new System.Drawing.Size(300, 30);
            this.Load += new System.EventHandler(this.InfoPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoNameLabel;
        private System.Windows.Forms.TextBox InfoValueBox;
    }
}
