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
    public class GraphWriter : Form
    {
        //Элементы графики
        public Bitmap bmp;
        public Pen pen = new Pen(Color.Black, 20);
        public Pen pen_selected = new Pen(Color.CadetBlue, 20);
        public Pen pen_way = new Pen(Color.Green, 7);
        public int radius = 20;

        //Массивы точек и рёбер
        public List<PointCH> Points = new List<PointCH>();
        public List<Way> Ways = new List<Way>();
        public int first_point = -1, on_this_point = -1;

        //Элементы интерфейса
        public PictureBox MainPicture;
        public ListBox PointsList, WaysList;

        public GraphWriter(PictureBox main_pic,ListBox points_l,ListBox ways_l)
        {
            MainPicture = main_pic;
            PointsList = points_l;
            WaysList = ways_l;
            bmp = new Bitmap(MainPicture.Width, MainPicture.Height);
        }
        public void Redraw(PictureBox pic)
        {
            MainPicture.Width = pic.Width;
            bmp = new Bitmap(MainPicture.Width, MainPicture.Height);
            DrawWays();
            DrawPoints();
        }
        public void DrawPoint(Pen pen, Rectangle rect, int ind, bool isNew = true)
        {
            if (isNew)
            {
                var tempo_point = new PointCH(rect.X + radius / 2, rect.Y + radius / 2, ind);
                Points.Add(tempo_point);
                PointsList.Items.Add("Точка " + (tempo_point.Number + 1).ToString()
                    + " (" + (tempo_point.X).ToString() + "; " + (tempo_point.Y).ToString() + ")");
            }
            //
            Graphics g = Graphics.FromImage(bmp);
            g.DrawEllipse(pen, rect);
            g.DrawString((ind + 1).ToString(), SystemFonts.MenuFont, Brushes.White, new PointF((float)rect.X + radius / 4f, (float)rect.Y + radius / 4f));
            MainPicture.Image = bmp;
        }
        public void ClearPoints(bool GraphOnly = false)
        {
            bmp.Dispose();
            bmp = new Bitmap(MainPicture.Width, MainPicture.Height);
            MainPicture.Image = bmp;
            if (GraphOnly == false)
            {
                Points.Clear();
                PointsList.Items.Clear();
                Ways.Clear();
                WaysList.Items.Clear();
            }
        }
        public void RedrawGraph()
        {
            bmp.Dispose();
            bmp = new Bitmap(MainPicture.Width, MainPicture.Height);
            MainPicture.Image = bmp;
            DrawPoints();
            DrawWays();
        }
        public void DrawPoints()
        {
            foreach (PointCH item in Points)
            {
                DrawPoint(pen, new Rectangle(item.X - radius / 2, item.Y - radius / 2, radius, radius), item.Number, false);
            }
        }
        public void DrawWays()
        {
            foreach (Way item in Ways)
            {
                DrawWay(item.Begin, item.End, true);
            }
        }
        public void SelectPoint(int index)
        {
            if (index >= 0)
            {
                var item = Points[index];
                foreach (var point in Points)
                    DrawPoint(pen, new Rectangle(point.X - radius / 2, point.Y - radius / 2, radius, radius), point.Number, false);
                DrawPoint(pen_selected, new Rectangle(item.X - radius / 2, item.Y - radius / 2, radius, radius), item.Number, false);
            }
            else
            {
                PointsList.ClearSelected();
                DrawPoints();
            }
        }
        public void DrawWay(PointCH start, PointCH end, bool GraphOnly = false)
        {
            if (start != end)
            {
                Graphics g = Graphics.FromImage(bmp);
                var tempo_way = new Way(start, end, 1);
                //
                start.ways.Add(tempo_way);
                end.ways.Add(tempo_way);

                //if(start.connected.Contains(end)==false) start.connected.Add(end);
                //if(end.connected.Contains(start)==false) end.connected.Add(start);

                //for (int i = 0; i < end.connected.Count; i++)
                //{
                //    //MessageBox.Show(end.connected.Count.ToString());
                //    if (start.connected.Contains(end.connected[i])==false
                //        && end.connected[i] != start)
                //        start.connected.Add(end.connected[i]);
                //}
                //for (int i = 0; i < start.connected.Count; i++)
                //{
                //    if (end.connected.Contains(start.connected[i]) == false
                //        && start.connected[i] != end)
                //        end.connected.Add(start.connected[i]);
                //}
                //
                if (GraphOnly == false)
                {
                    WaysList.Items.Add((start.Number + 1).ToString() + " <-> " + (end.Number + 1).ToString());
                    Ways.Add(tempo_way);
                }
                //
                g.DrawLine(pen_way, start.X, start.Y, end.X, end.Y);
                //
                DrawPoint(pen, new Rectangle(start.X - radius / 2, start.Y - radius / 2, radius, radius), start.Number, false);
                DrawPoint(pen, new Rectangle(end.X - radius / 2, end.Y - radius / 2, radius, radius), end.Number, false);
                g.DrawString(tempo_way.Name.ToString(), SystemFonts.MenuFont, Brushes.Black, new PointF(Math.Abs((float)start.X + end.X)/2-25, Math.Abs((float)start.Y + end.Y)/2-25));
                //
                MainPicture.Image = bmp;
            }
        }
        /*public void DoConnections(List<Way> ws)
        {
            foreach (var k in ws)
            {
                if (k.Begin != k.End)
                {
                    //
                    if (k.Begin.connected.Contains(k.End) == false) k.Begin.connected.Add(k.End);
                    if (k.End.connected.Contains(k.Begin) == false) k.End.connected.Add(k.Begin);

                    for (int i = 0; i < k.End.connected.Count; i++)
                    {
                        //MessageBox.Show(k.End.connected.Count.ToString());
                        if (k.Begin.connected.Contains(k.End.connected[i]) == false
                            && k.End.connected[i] != k.Begin)
                            k.Begin.connected.Add(k.End.connected[i]);
                    }
                    for (int i = 0; i < k.Begin.connected.Count; i++)
                    {
                        if (k.End.connected.Contains(k.Begin.connected[i]) == false
                            && k.Begin.connected[i] != k.End)
                            k.End.connected.Add(k.Begin.connected[i]);
                    }
                }
            }
        }*/
        public void RemoveWay(int index)
        {
            Ways.RemoveAt(index);
            WaysList.Items.Clear();
            foreach (var item in Ways)
            {
                WaysList.Items.Add((item.Begin.Number + 1).ToString() + " <-> " + (item.End.Number + 1).ToString());
            }
            RedrawGraph();
        }
        public void RemoveWay(Way way)
        {
            Ways.Remove(way);
            WaysList.Items.Clear();
            foreach (var item in Ways)
            {
                WaysList.Items.Add((item.Begin.Number + 1).ToString() + " <-> " + (item.End.Number + 1).ToString());
            }
        }
        public void RemovePoint(int index)
        {
            var tpoint = Points[index];
            foreach (var way in tpoint.ways)
            {
                RemoveWay(way);
            }
            Points.RemoveAt(index);
            PointsList.Items.Clear();
            foreach (var item in Points)
            {
                PointsList.Items.Add("Точка " + (item.Number + 1).ToString()
                    + " (" + (item.X).ToString() + "; " + (item.Y).ToString() + ")");
            }
            ClearPoints(true);
            DrawPoints();
            DrawWays();
            first_point = -1;
        }

        public List<PointCH> FindIndependentSets(List<PointCH> pts = null,int index_=0)
        {
            string res = "";
            if (pts == null) pts = Points;
            var set = new List<PointCH>();
            set.Add(pts[index_]);
            for (int i = 0; i < pts.Count; i++) //По всем точкам
            {
                if(i != index_)
                    set= FindIndependentSets(pts[i], set);
            }
            foreach(var sex in set)
            {
                res += ((sex.Number+1).ToString() + "-");
            }
            MessageBox.Show(res);
            return set;
        }
        public List<PointCH> FindIndependentSets(PointCH pt, List<PointCH> indexes)
        {
            List<PointCH> set = new List<PointCH>();
            set.AddRange(indexes);
                foreach(var point in indexes)
                {
                    if (point.ConnectedByStep(pt))
                    {
                    if(set.IndexOf(pt)!=0)
                    set.Remove(pt);
                    }    
                    else
                    {
                        if(set.Contains(pt) == false)
                            set.Add(pt);
                    }
                }
            return set;
        }
    }
}
