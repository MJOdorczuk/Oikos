namespace Oikos
{
    partial class Simulation
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
            this.GenerationCounterBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GenerationCounterBox
            // 
            this.GenerationCounterBox.Enabled = false;
            this.GenerationCounterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GenerationCounterBox.Location = new System.Drawing.Point(12, 818);
            this.GenerationCounterBox.Name = "GenerationCounterBox";
            this.GenerationCounterBox.Size = new System.Drawing.Size(200, 31);
            this.GenerationCounterBox.TabIndex = 0;
            this.GenerationCounterBox.TextChanged += new System.EventHandler(this.GenerationCounterBox_TextChanged);
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.GenerationCounterBox);
            this.Name = "Simulation";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Simulation_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GenerationCounterBox;
    }
}

