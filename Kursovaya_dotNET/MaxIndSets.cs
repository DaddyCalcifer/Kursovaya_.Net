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
            foreach(List<PointCH> set in Sets)
            {
                string showcase = "";
                foreach (PointCH point in set)
                {
                    showcase += (" " + (point.Number+1).ToString() + ",");
                }
                MaximumSets.Items.Add("{" + showcase.TrimEnd(',') + " }");
            }
        }
    }
}
