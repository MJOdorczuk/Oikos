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

namespace Oikos.Controls.WorldControl
{
    public partial class WorldPanel : UserControl
    {
        
        private readonly List<Tuple<InfoPanel, InfoPanel, InfoPanel>> groups = new List<Tuple<InfoPanel, InfoPanel, InfoPanel>>();
        public WorldPanel()
        {
            InitializeComponent();
        }

        public void GeneratePanels(int numOfBiomes)
        {
            Point point = new Point(0, 0);
            for(int i = 0; i < numOfBiomes; i++)
            {
                GroupBox group = new GroupBox()
                {
                    AutoSize = true,
                    Visible = true,
                    Enabled = true,
                    Location = point,
                    Width = 200,
                    Height = 100,
                    Text = "Biom " + i
                };
                InfoPanel popsPanel = new InfoPanel("Biom population")
                {
                    AutoSize = true,
                    Visible = true,
                    Enabled = true,
                    Location = new Point(0,0)
                };
                InfoPanel tempPanel = new InfoPanel("Average biom temperature")
                {
                    AutoSize = true,
                    Visible = true,
                    Enabled = true,
                    Location = new Point(0,25)
                };
                InfoPanel nutriPanel = new InfoPanel("Biom flora level")
                {
                    AutoSize = true,
                    Visible = true,
                    Enabled = true,
                    Location = new Point(0,50)
                };
                group.Controls.Add(popsPanel);
                group.Controls.Add(tempPanel);
                group.Controls.Add(nutriPanel);
                Controls.Add(group);
                point.Y += 100;
                groups.Add(new Tuple<InfoPanel, InfoPanel, InfoPanel>(popsPanel, tempPanel, nutriPanel));
            }
        }

        private void WorldPanel_Load(object sender, EventArgs e)
        {

        }

        delegate void SetInfoPanelCallBack(InfoPanel info);

        private void SetInfoPanel(InfoPanel info)
        {
            if (this.InvokeRequired)
            {
                SetInfoPanelCallBack d = new SetInfoPanelCallBack(SetInfoPanel);
                Invoke(d, new object[] { info });
            }
            else
            {
                Controls.Add(info);
            }
        }

        internal void Update(InfoContainer infoContainer)
        {
            for(int i = 0; i < infoContainer.biomInfos.Count(); i++)
            {
                var pop = infoContainer.biomInfos[i].Item1;
                var temp = infoContainer.biomInfos[i].Item2;
                var nutri = infoContainer.biomInfos[i].Item3;
                groups[i].Item1.Value(pop);
                groups[i].Item2.Value(temp);
                groups[i].Item3.Value(nutri);
            }
            Point point = new Point(300, 0);
            foreach(var sPop in infoContainer.speciesPops)
            {
                InfoPanel info = new InfoPanel(sPop.Key.name)
                {
                    AutoSize = true,
                    Visible = true,
                    Enabled = true,
                    Location = point,
                    Text = sPop.Key.name
                };
                info.Value(sPop.Value);
                point.Y += 30;
                SetInfoPanel(info);
            }
        }
    }
}
