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
       // public List<PointCH> connected = new List<PointCH> (0);
        /*public int ConnectedVia(PointCH pt, List<Way> grounded = null)
        {
            if (grounded == null) grounded = new List<Way>();
            if (this.connected.Contains(pt)) return 1;
            else return 0;
            //PointCH checking = this;
            //int counter = 0;
            ////
            //while (this.ways.Count > 1) {
            //    if (this.ways.Count == 1 && counter>0) break;
            //    foreach (Way w in this.ways)
            //    {
            //        if (grounded.Contains(w) == false)
            //        {
            //            if (w.Points.Contains(pt)) return 1;
            //            else
            //            {
            //                int zaebalo = w.Points.IndexOf(this);
            //                if (zaebalo == 0)
            //                {
            //                    if (w.Points[1].ways.Count != 1)
            //                        counter += w.Points[1].ConnectedVia(pt, grounded);
            //                    else continue;
            //                }
            //                if (zaebalo == 1)
            //                {
            //                    if (w.Points[0].ways.Count != 1)
            //                        counter += w.Points[0].ConnectedVia(pt, grounded);
            //                    else continue;
            //                }
            //            }
            //            grounded.Add(w);
            //            counter++;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}
            ////
            //return counter;
        }*/
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
