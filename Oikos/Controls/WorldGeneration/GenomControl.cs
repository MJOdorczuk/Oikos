using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oikos.Kernel.Dwellers;

namespace Oikos.Controls
{
    public partial class GenomControl : UserControl
    {
        private static readonly int MODULE_HEIGHT = 55;
        private readonly List<GeneControl> geneControls = new List<GeneControl>();

        public GenomControl()
        {
            InitializeComponent();
            List<string> geneNames = Creature.Genes;
            Point point = new Point(0, 0);
            foreach(var name in geneNames)
            {
                GeneControl geneControl = new GeneControl(name)
                {
                    Visible = true,
                    Enabled = true,
                    AutoSize = true,
                    Location = point
                };
                geneControls.Add(geneControl);
                Controls.Add(geneControl);
                point.Y += MODULE_HEIGHT;
            }
        }

        private void GenomControl_Load(object sender, EventArgs e)
        {

        }

        public Dictionary<string,double> GeneValues()
        {
            Dictionary<string, double> ret = new Dictionary<string, double>();
            foreach(var gc in geneControls)
            {
                ret.Add(gc.name, gc.Value);
            }
            return ret;
        }
    }
}
