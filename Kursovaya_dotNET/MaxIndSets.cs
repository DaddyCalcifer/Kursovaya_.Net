using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_dotNET
{
    public partial class MaxIndSets : Form
    {
        public List<List<PointCH>> Sets;
        public MaxIndSets(ref List<List<PointCH>> sets_)
        {
            InitializeComponent();
            Sets = sets_;
        }

        private void MaxIndSets_Load(object sender, EventArgs e)
        {
            int max_ = 0;
            foreach(List<PointCH> set in Sets)
            {
                if(set.Count > max_) max_ = set.Count;
            }
            foreach (List<PointCH> set in Sets)
            {
                string showcase = "";
                foreach (PointCH point in set)
                {
                    showcase += (" " + (point.Number + 1).ToString() + ",");
                }
                if (set.Count == max_ )
                {
                    if (MaximumSets.Items.Contains("{" + showcase.TrimEnd(',') + " }") == false
                    && OtherSets.Items.Contains("{" + showcase.TrimEnd(',') + " }") == false
                    && ("{" + showcase.TrimEnd(',') + " }").Length > 5)
                        MaximumSets.Items.Add("{" + showcase.TrimEnd(',') + " }");
                    else continue;
                }
                else
                {
                    if (MaximumSets.Items.Contains("{" + showcase.TrimEnd(',') + " }") == false
                    && OtherSets.Items.Contains("{" + showcase.TrimEnd(',') + " }") == false
                    && ("{" + showcase.TrimEnd(',') + " }").Length > 5)
                        OtherSets.Items.Add("{" + showcase.TrimEnd(',') + " }");
                    else continue;
                }
            }
        }

        private void MaximumSets_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void MaximumSets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Return)
                this.Close();
        }
        Point MouseHook  = new Point();
        private void MaxIndSets_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            else
            {
                Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Red;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Transparent;
        }
    }
}
