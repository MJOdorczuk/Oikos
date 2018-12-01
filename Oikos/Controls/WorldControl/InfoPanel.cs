using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oikos.Controls.WorldControl
{
    public partial class InfoPanel : UserControl
    {
        public readonly string name;
        public InfoPanel(string name)
        {
            this.name = name;
            InitializeComponent();
            InfoNameLabel.Text = name;
        }

        private void InfoValueBox_TextChanged(object sender, EventArgs e)
        {

        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (InfoValueBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                InfoValueBox.Text = text;
            }
            
        }

        internal void Value(double v)
        {
            SetText(v + "");
        }

        private void InfoPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
