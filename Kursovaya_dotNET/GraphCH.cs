using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_dotNET
{
    public abstract class GraphCH
    {
        public List<PointCH> Points = new List<PointCH>();
        public List<Way> Ways = new List<Way>();

        public int Power() { return Points.Count; }
        public int Edges() { return Ways.Count; }
    }
}
