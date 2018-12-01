using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oikos.Kernel.Environment;

namespace Oikos.Controls
{
    public partial class ClimateControl : UserControl
    {
        private double aTemp = 20, tempDiff = 20, tempFluct = 15;
        private readonly double aTempMult, tempDiffMult, tempFluctMult;
        private readonly double aTempShift, tempDiffShift, tempFluctShift;

        public ClimateControl()
        {
            InitializeComponent();
            aTempMult = (World.ATMAX - World.ATMIN) / (ATempBar.Maximum - ATempBar.Minimum);
            aTempShift = World.ATMIN;
            tempDiffMult = (World.TDMAX - World.TDMIN) / (TempDiffBar.Maximum - TempDiffBar.Minimum);
            tempDiffShift = World.TDMIN;
            tempFluctMult = (World.TFMAX - World.TFMIN) / (TempFluctBar.Maximum - TempFluctBar.Minimum);
            tempFluctShift = World.TFMIN;
            ATempBar.Value = (int)((20 - aTempShift) / aTempMult);
            ATempBox.Text = ((ATempBar.Value * aTempMult) + aTempShift).ToString();
            TempDiffBar.Value = (int)((20 - tempDiffShift) / tempDiffMult);
            TempDiffBox.Text = ((TempDiffBar.Value * tempDiffMult) + tempDiffShift).ToString();
            TempFluctBar.Value = (int)((15 - tempFluctShift) / tempFluctMult);
            TempFluctBox.Text = ((TempFluctBar.Value * tempFluctMult) + tempFluctShift).ToString();
        }

        private void TempFluctBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TempFluctBar_Scroll(object sender, EventArgs e)
        {
            tempFluct = (TempFluctBar.Value * tempFluctMult) + tempFluctShift;
            TempFluctBox.Text = tempFluct.ToString();
        }

        private void ATempBar_Scroll(object sender, EventArgs e)
        {
            aTemp = (ATempBar.Value * aTempMult) + aTempShift;
            ATempBox.Text = aTemp.ToString();
        }

        private void TempDiffBar_Scroll(object sender, EventArgs e)
        {
            tempDiff = (TempDiffBar.Value * tempDiffMult) + tempDiffShift;
            TempDiffBox.Text = tempDiff.ToString();
        }

        public double ATemp => aTemp;
        public double TempDiff => tempDiff;
        public double TempFluct => tempFluct;
    }
}
