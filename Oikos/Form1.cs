using Oikos.Controls;
using Oikos.Controls.WorldControl;
using Oikos.Kernel.Environment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oikos
{
    public partial class Form1 : Form
    {
        private World world;
        private World copy = null;
        private readonly ClimateControl climateControl;
        private readonly WorldGenerationControl worldGenerationControl;
        private readonly WorldPanel worldPanel;
        private bool worldRequested = false, worldProvided = true, endRequested = false;

        public Form1()
        {
            InitializeComponent();
            worldGenerationControl = new WorldGenerationControl(this)
            {
                AutoSize = true,
                Visible = true,
                Location = new Point(0,0),
                Enabled = true
            };
            climateControl = new ClimateControl()
            {
                AutoSize = true,
                Visible = false,
                Location = new Point(0, 0),
                Enabled = false
            };
            worldPanel = new WorldPanel()
            {
                AutoSize = true,
                Visible = false,
                Location = new Point(400, 0),
                Enabled = false
            };
            Controls.Add(climateControl);
            Controls.Add(worldGenerationControl);
            Controls.Add(worldPanel);
        }

        internal void GenerateWorld(World world)
        {
            this.world = world;
            if (worldGenerationControl.Enabled)
            {
                worldGenerationControl.Enabled = false;
                worldGenerationControl.Visible = false;
                climateControl.Enabled = true;
                climateControl.Visible = true;
                worldPanel.Enabled = true;
                worldPanel.Visible = true;
                worldPanel.GeneratePanels(world.Biomes().Count());
                worldPanel.Update(InfoContainer.ExtractInfo(world));
                Simulate();
            }
            
        }

        private World Tick(bool worldRequested)
        {
            world.Tick();
            world.TempFluct = climateControl.TempFluct;
            world.TempDiff = climateControl.TempDiff;
            world.ATemp = climateControl.ATemp;
            if (worldRequested) return world.Clone();
            else return null;
        }

        private World GetWorld()
        {
            World copy = null;
            while (worldRequested && !worldProvided) ;
            copy = this.copy;
            this.copy = null;
            return copy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Run()
        {
            World clone;
            while (!endRequested)
            {
                bool copyRequested = this.worldRequested;
                this.worldRequested = false;
                this.worldProvided = !copyRequested;
                clone = Tick(copyRequested);
                if (copyRequested) copy = clone;
                worldPanel.Update(InfoContainer.ExtractInfo(world));
                Thread.Sleep(100);
            }
        }

        public void Simulate()
        {
            new Thread(() => Run()).Start();
        }
    }
}
