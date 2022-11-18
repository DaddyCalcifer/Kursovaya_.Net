using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Kursovaya_dotNET
{
    public class PointCH
    {
        
        private int x_, y_, Number_;
        public List<Way> ways = new List<Way> ();
        public int X
            { get { return x_; } set { x_ = value; } }
        public int Y 
            { get { return y_; } set { y_ = value; } }
        public int Number
            { get { return Number_; } set { Number_ = value; } }
        public PointCH() { }
        public PointCH(int x, int y, int number)
        {
            X = x; Y = y; Number_ = number;
        }
        public PointCH(PointCH point)
        {
            X = point.X; Y = point.Y; Number_ = point.Number;
        }
        public bool ConnectedByStep(PointCH pt)
        {
            if (this == pt) return false;
            foreach(var item in this.ways)
            {
                if (item.Points.Contains(pt)) return true;
            }
            return false;
        }
    }
}
