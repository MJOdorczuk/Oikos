using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oikos.Controls
{
    public partial class GeneControl : UserControl
    {
        private double value;
        public readonly string name;
        public GeneControl(string name)
        {
            InitializeComponent();
            this.name = name;
            GeneNameLabel.Text = name;
        }

        private void GeneTrackBar_Scroll(object sender, EventArgs e)
        {
            value = (double)GeneTrackBar.Value / (double)GeneTrackBar.Maximum;
            GeneValueBox.Text = value.ToString();
        }

        public double Value => value;
    }
}
