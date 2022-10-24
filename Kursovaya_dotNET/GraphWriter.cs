﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Kursovaya_dotNET
{
    public class GraphWriter : Form
    {
        //Элементы графики
        public Bitmap bmp;
        public Pen pen = new Pen(Color.White, 20);
        public Pen pen_selected = new Pen(Color.CadetBlue, 20);
        public Pen pen_way = new Pen(Color.DarkSlateGray, 7);
        public int radius = 20;

        //Массивы точек и рёбер
        public List<PointCH> Points = new List<PointCH>();
        public List<Way> Ways = new List<Way>();
        public int first_point = -1, on_this_point = -1;

        //Элементы интерфейса
        public PictureBox MainPicture;
        public ListBox PointsList, WaysList;

        XmlSerializer xmlS = new XmlSerializer(typeof(GraphObj));

        public GraphWriter(PictureBox main_pic,ListBox points_l,ListBox ways_l)
        {
            MainPicture = main_pic;
            PointsList = points_l;
            WaysList = ways_l;
            bmp = new Bitmap(MainPicture.Width, MainPicture.Height);
        }
        public GraphWriter() { }
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
            g.DrawString((ind + 1).ToString(), SystemFonts.DefaultFont, Brushes.Black, new PointF((float)rect.X + radius / 4f, (float)rect.Y + radius / 4f));
            MainPicture.Image = bmp;
        }
        public void ClearPoints(bool GraphOnly = false)
        {
            bmp.Dispose();
            bmp = new Bitmap(MainPicture.Width, MainPicture.Height);
            MainPicture.Image = null;
            if (GraphOnly == false)
            {
                Points.Clear();
                PointsList.Items.Clear();
                Ways.Clear();
                WaysList.Items.Clear();
            }
            first_point = -1; on_this_point = -1;
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
            var tempo_way = new Way(start, end, 1);

            if (start != end)
            {
                Graphics g = Graphics.FromImage(bmp);

                start.ways.Add(tempo_way);
                end.ways.Add(tempo_way);

                if (GraphOnly == false)
                {
                    WaysList.Items.Add((start.Number + 1).ToString() + " <-> " + (end.Number + 1).ToString());
                    Ways.Add(tempo_way);
                }

                g.DrawLine(pen_way, start.X, start.Y, end.X, end.Y);

                DrawPoint(pen, new Rectangle(start.X - radius / 2, start.Y - radius / 2, radius, radius), start.Number, false);
                DrawPoint(pen, new Rectangle(end.X - radius / 2, end.Y - radius / 2, radius, radius), end.Number, false);
                //g.DrawString(tempo_way.Name.ToString(), SystemFonts.MenuFont, Brushes.Black, new PointF(Math.Abs((float)start.X + end.X)/2-25, Math.Abs((float)start.Y + end.Y)/2-25));

                MainPicture.Image = bmp;
            }
        }
        public void RemoveWay(int index)
        {
            foreach (var pt in Ways[index].Points)
            {
                pt.ways.Remove(Ways[index]);
            }
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
            foreach(var pt in way.Points)
            {
                pt.ways.Remove(way);
            }
            Ways.Remove(way);
            WaysList.Items.Clear();
            foreach (var item in Ways)
            {
                WaysList.Items.Add((item.Begin.Number + 1).ToString() + " <-> " + (item.End.Number + 1).ToString());
            }
            RedrawGraph();
        }
        public void RemovePoint(int index)
        {
            var tpoint = Points[PointsList.SelectedIndex];
            var delete_counter = tpoint.ways.Count;
            for (int i = 0; i < delete_counter; i++)
                RemoveWay(tpoint.ways[0]);
            //
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

        public void OpenXML(string path)
        {
            GraphObj grob = new GraphObj();
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
            {
                try { grob = xmlS.Deserialize(fs) as GraphObj; }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                fs.Close();
            }
            for (int i = 0; i < grob.X.Count; i++)
            {
                this.DrawPoint(this.pen, new Rectangle(grob.X[i] - this.radius / 2, grob.Y[i] - this.radius / 2, this.radius, this.radius), i);
            }
            for (int i = 0; i < grob.ways_p1.Count; i++)
            {
                this.DrawWay(this.Points[grob.ways_p1[i]], this.Points[grob.ways_p2[i]], false);
            }
        }
        public void SaveXML(string path)
        {
            List<int> x_ = new List<int>();
            List<int> y_ = new List<int>();

            List<int> p1 = new List<int>();
            List<int> p2 = new List<int>();

            foreach (var item in this.Points)
            {
                x_.Add(item.X);
                y_.Add(item.Y);
            }
            foreach (var item in this.Ways)
            {
                p1.Add(this.Points.IndexOf(item.Begin));
                p2.Add(this.Points.IndexOf(item.End));
            }
            var graphObj = new GraphObj(x_, y_, p1, p2);
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
            {
                xmlS.Serialize(fs, graphObj);
                fs.Close();
            }
        }
        //public List<PointCH> SetSort(List<PointCH> mas)
        //{
        //    PointCH temp;
        //    for (int i = 0; i < mas.Count; i++)
        //    {
        //        for (int j = i + 1; j < mas.Count; j++)
        //        {
        //            if (mas[i].Number > mas[j].Number)
        //            {
        //                temp = mas[i];
        //                mas[i] = mas[j];
        //                mas[j] = temp;
        //            }
        //        }
        //    }
        //    return mas;
        //}
        //public List<PointCH> FindIndependentSets(List<PointCH> pts = null,int index_=0)
        //{
        //    if (pts == null) pts = Points;
        //    var set = new List<PointCH>();
        //    set.Add(pts[index_]);
        //    for (int i = 0; i < pts.Count; i++) //По всем точкам
        //    {
        //        if (i != index_)
        //        {
        //            set = FindIndependentSets(pts[i], set);
        //        }
        //    }
        //    //
        //    for (int i = 0; i < set.Count; i++)
        //    {
        //        if (i < 0 || i >= set.Count) break;
        //        for (int j = 0; j < set.Count; j++)
        //        {
        //            if (j < 0 || j >= set.Count) break;
        //            //
        //            try { 
        //                if (set[i].ConnectedByStep(set[j]))
        //                try { set.RemoveAt(j); }
        //                catch { }
        //            }
        //            //catch(Exception ex) { MessageBox.Show(ex.Message); }
        //            catch { break; }
        //        }
        //    }
        //    return set;
        //}
        //public List<PointCH> FindIndependentSets(PointCH pt, List<PointCH> indexes)
        //{
        //    List<PointCH> set = new List<PointCH>();
        //    set.AddRange(indexes);
        //    foreach (var point in indexes)
        //    {
        //        if (point.ConnectedByStep(pt) == false)
        //        {
        //            //if(set.IndexOf(pt)!=0)
        //            //set.Remove(pt);
        //            //}    
        //            //else
        //            //{
        //            if (set.Contains(pt) == false)
        //            {
        //                set.Add(pt);
        //            }
        //        }
        //    }
        //    return set;
        //}
        //public List<List<PointCH>> FindAllIndependentSets(List<PointCH> indexes)
        //{
        //    List<PointCH> set = new List<PointCH>();
        //    List<List<PointCH>> any_sets = new List<List<PointCH>>();
        //    set.AddRange(indexes);

        //    foreach (var pt in indexes)
        //    {
        //        foreach (var point in indexes)
        //        {
        //            if (point.ConnectedByStep(pt) == false)
        //            {
        //                if (set.Contains(pt) == false)
        //                {
        //                    set.Add(pt);
        //                }
        //                any_sets.Add(set);
        //            }
        //        }
        //        set.Clear();
        //        set.AddRange(indexes);
        //    }
        //    foreach (var ind1 in indexes)
        //    {
        //        foreach (var ind2 in indexes)
        //        {
        //            if (ind1.ConnectedByStep(ind2) == false && ind1 != ind2)
        //                any_sets.Add(new List<PointCH>() { ind1,ind2 });
        //        }
        //    }

        //    Stack<PointCH> points_stack = new Stack<PointCH>();
        //    foreach (var item in SetSort(indexes))
        //    {
        //        points_stack.Push(item);
        //    }
        //    for (int i = 0; i < indexes.Count; i++)
        //    {
        //        List<PointCH> pts_list = new List<PointCH>();
        //        foreach (var item in points_stack)
        //        {
        //            pts_list.Add(item);
        //        }
        //        points_stack.Pop();
        //        any_sets.Add(pts_list);
        //    }

        //    for (int i = 0; i < any_sets.Count; i++)
        //    {
        //        any_sets[i] = SetSort(any_sets[i]);
        //    }

        //    return any_sets;
        //}
        //public List<PointCH> ReversePoints(List<PointCH> sets)
        //{
        //    List<PointCH> re_sets = new List<PointCH>();

        //    for(int i = 0; i < sets.Count; i++)
        //    {
        //        re_sets.Add(sets[sets.Count-(i+1)]);
        //    }

        //    return re_sets;
        //}
        //public List<List<PointCH>> AllIndependentSets(List<PointCH> ptss=null)
        //{
        //    if (ptss == null) ptss = this.Points;

        //    //В обычном порядке
        //    List<List<PointCH>> sets = new List<List<PointCH>>();
        //    if (ptss.Count > 0)
        //    {
        //        for (int i = 0; i < ptss.Count; i++)
        //        {
        //            sets.Add(SetSort(FindIndependentSets(ptss, i)));
        //        }
        //    }

        //    //В обратном порядке
        //    var re_pts = ReversePoints(ptss);
        //    List<List<PointCH>> re_sets = new List<List<PointCH>>();
        //    if (re_pts.Count > 0)
        //    {
        //        for (int i = 0; i < re_pts.Count; i++)
        //        {
        //            re_sets.Add(SetSort(FindIndependentSets(re_pts, i)));
        //        }
        //    }
        //    sets.AddRange(re_sets);

        //    sets.AddRange(FindAllIndependentSets(ptss));
        //    sets.AddRange(FindAllIndependentSets(re_pts));
        //    int sts = sets.Count;
        //    for(int i = 0; i < sts; i++)
        //    {
        //        sets.AddRange(FindAllIndependentSets(sets[i]));
        //    }

        //    for (int ij = 0; ij < 2; ij++)
        //    {
        //        var st_counter = sets.Count;
        //        for (int i = 0; i < st_counter; i++)
        //        {
        //            for (int j = 0; j < sets[i].Count; j++)
        //            {
        //                int popo = sets[i].Count;
        //                for (int k = 0; k < popo; k++)
        //                {
        //                    try
        //                    {
        //                        if (sets[i][k].ConnectedByStep(sets[i][j]))
        //                        {
        //                            sets[i].Remove(sets[i][j]);
        //                            popo--;
        //                        }
        //                    }
        //                    catch { }
        //                }
        //            }
        //        }
        //    }

        //    return sets;
        //}
    }
}
