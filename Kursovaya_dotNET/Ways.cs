using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_dotNET
{
    public class Way
    {
        private PointCH beg, end;
        int name;
        public PointCH Begin
        { get { return beg; } set { beg = value; } }
        public PointCH End
        { get { return end; } set { end = value; } }
        public int Name
        { get { return name; } set { name = value; } }
        public List<PointCH> Points = new List<PointCH>();

        public Way() { }
        public Way(PointCH beg_, PointCH end_, int nm)
        {
            Begin = beg_; End = end_; Name = 1;
            Points.Add(Begin); Points.Add(End);
        }
        public Way(Way way)
        {
            Begin = way.Begin; End = way.End; Name = 1;
            Points.Add(Begin); Points.Add(End);
        }
    }
}
