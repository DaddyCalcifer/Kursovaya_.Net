using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_dotNET
{
    [Serializable]
    public class GraphObj
    {
        public List<int> X = new List<int>();
        public List<int> Y = new List<int>();

        public List<int> ways_p1 = new List<int>();
        public List<int> ways_p2 = new List<int>();
        public GraphObj() { }
        public GraphObj(List<int> x, List<int> y, List<int> p1, List<int> p2) 
        {
            X = x; ways_p1 = p1;
            Y = y; ways_p2 = p2;
        }
    }
}
