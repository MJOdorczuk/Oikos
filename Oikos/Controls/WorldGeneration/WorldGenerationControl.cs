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
using Oikos.Kernel.Environment;

namespace Oikos.Controls
{
    public partial class WorldGenerationControl : UserControl
    {
        private int numOfBiomes = 1, numOfSpec, maxAngle, numOfHandMadeSpec;
        private List<Herd> herdsGenerated = new List<Herd>();
        private readonly GenomControl genomControl;
        private readonly Form1 parent;

        public WorldGenerationControl(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
            genomControl = new GenomControl()
            {
                Visible = true,
                Enabled = true,
                AutoSize = true,
                Location = new Point(0, 130),
            };
            Controls.Add(genomControl);
        }

        private void GenerateSpeciesButton_Click(object sender, EventArgs e)
        {
            double[] genepool = new double[Creature.GENOMSIZE];
            foreach(var name in Creature.Genes)
            {
                genepool[Creature.Calls[name]] = genomControl.GeneValues()[name];
            }
            Creature ancestor = new Creature(genepool, null, true);
            Herd herd = Herd.Multiply(ancestor);
            ancestor.Herd = herd;
            herdsGenerated.Add(herd);
            numOfHandMadeSpec++;
            NumOfAllSpeciesBox.Text = (numOfSpec + numOfHandMadeSpec).ToString();
        }

        private void GenerateWorldButton_Click(object sender, EventArgs e)
        {
            World world = new World(numOfBiomes, ((double)maxAngle)*Math.PI/180);
            for(int i = 0; i < numOfSpec; i++)
            {
                world.AddHerdRandomly();
            }
            foreach(var herd in herdsGenerated)
            {
                world.AddHerdRandomly(herd);
            }
            parent.GenerateWorld(world);
        }

        private void WorldGenerationControl_Load(object sender, EventArgs e)
        {

        }

        private void MaxHeightCounter_ValueChanged(object sender, EventArgs e)
        {
            maxAngle = (int)MaxHeightCounter.Value;
        }

        private void NumOfSpecCounter_ValueChanged(object sender, EventArgs e)
        {
            numOfSpec = (int)NumOfSpecCounter.Value;
            NumOfAllSpeciesBox.Text = (numOfSpec + numOfHandMadeSpec).ToString();
        }

        private void NumOfBiomesCounter_ValueChanged(object sender, EventArgs e)
        {
            numOfBiomes = (int)NumOfBiomesCounter.Value;
        }
    }
}
