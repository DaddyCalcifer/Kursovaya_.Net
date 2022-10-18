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
    public partial class Form1 : Form
    {
        GraphWriter graph;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            graph = new GraphWriter(MainPicture,PointsList,WaysList);
        }
        /*
        void DrawPoint(Pen pen, Rectangle rect, int ind, bool isNew = true)
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
            g.DrawString((ind+1).ToString(),SystemFonts.MenuFont,Brushes.White,new PointF((float)rect.X+radius/4f,(float)rect.Y+radius/4f));
            pictureBox1.Image = bmp;
        }
        void ClearPoints(PictureBox pic,ListBox box, List<PointCH> points, bool GraphOnly=false)
        {
            bmp = new Bitmap(pic.Width, pic.Height);
            pic.Image = bmp;
            if (GraphOnly == false)
            {
                points.Clear();
                box.Items.Clear();
                Ways.Clear();
                WaysList.Items.Clear();
            }
        }
        void RedrawGraph(PictureBox pic, List<PointCH> points, List<Way> ways_)
        {
            bmp = new Bitmap(pic.Width, pic.Height);
            pic.Image = bmp;
            DrawPoints(pic, points);
            DrawWays(pic, ways_);
        }
        void DrawPoints(PictureBox pic, List<PointCH> points)
        {
            foreach (PointCH item in points)
            {
                DrawPoint(pen,new Rectangle(item.X - radius / 2, item.Y - radius / 2, radius, radius),item.Number,false);
            }
        }
        void DrawWays(PictureBox pic, List<Way> ways_)
        {
            foreach (Way item in Ways)
            {
                DrawWay(item.Begin,item.End,pictureBox1,true);
            }
        }
        void SelectPoint(List<PointCH> pts, int index)
        {
            if (index >= 0)
            {
                var item = pts[index];
                foreach (var point in Points)
                    DrawPoint(pen, new Rectangle(point.X - radius / 2, point.Y - radius / 2, radius, radius), point.Number, false);
                DrawPoint(pen_selected, new Rectangle(item.X - radius / 2, item.Y - radius / 2, radius, radius), item.Number, false);
            }
            else
            {
                PointsList.ClearSelected();
                DrawPoints(pictureBox1, Points);
            }
        }
        void DrawWay(PointCH start, PointCH end, PictureBox pic,bool GraphOnly=false)
        {
            if (start != end)
            {
                Graphics g = Graphics.FromImage(bmp);
                var tempo_way = new Way(start, end, 1);
                //
                start.ways.Add(tempo_way);
                end.ways.Add(tempo_way);
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
                //
                pic.Image = bmp;
            }
        }
        void RemoveWay(List<Way> ways, int index)
        {
            ways.RemoveAt(index);
            WaysList.Items.Clear();
            foreach (var item in ways)
            {
                WaysList.Items.Add((item.Begin.Number + 1).ToString() + " <-> " + (item.End.Number + 1).ToString());
            }
            button5.Enabled = false;
            RedrawGraph(pictureBox1, Points, Ways);
        }
        void RemoveWay(List<Way> ways, Way way)
        {
            ways.Remove(way);
            WaysList.Items.Clear();
            foreach (var item in ways)
            {
                WaysList.Items.Add((item.Begin.Number + 1).ToString() + " <-> " + (item.End.Number + 1).ToString());
            }
            button5.Enabled = false;
        }
        */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (editCheckBox.Checked == false && addWaysCheckBox.Checked == false)
            {
                graph.DrawPoint(graph.pen, new Rectangle(e.X - graph.radius / 2, e.Y - graph.radius / 2, graph.radius, graph.radius), graph.Points.Count);
            }
            if (editCheckBox.Checked || addWaysCheckBox.Checked)
            {
                if (graph.on_this_point != -1)
                {
                    graph.SelectPoint(graph.on_this_point);
                    graph.PointsList.SelectedIndex = graph.on_this_point;
                }
            }
            if(addWaysCheckBox.Checked)
            {
                if(graph.first_point != -1)
                {
                    if(graph.on_this_point != -1)
                    {
                        graph.DrawWay(graph.Points[graph.first_point], graph.Points[graph.on_this_point]);
                        graph.on_this_point = -1;
                        graph.first_point = -1;
                        graph.PointsList.ClearSelected();
                    }
                }
                else
                {
                    graph.first_point = graph.on_this_point;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            graph.ClearPoints();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            graph.DrawPoints();
        }
        private void button3_Click(object sender, EventArgs e) //Удаление вершины
        {
            graph.RemovePoint(PointsList.SelectedIndex);
            button3.Enabled = false;
        }
        private void PointsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graph.PointsList.SelectedIndex >= 0)
            {
                button3.Enabled = true;
                graph.SelectPoint(graph.PointsList.SelectedIndex);
                graph.WaysList.ClearSelected();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            graph.RemoveWay(graph.WaysList.SelectedIndex);
        }
        private void WaysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graph.WaysList.SelectedIndex >= 0)
            {
                button5.Enabled = true;
                graph.PointsList.ClearSelected();
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (editCheckBox.Checked || addWaysCheckBox.Checked)
                for (int i = 0; i < graph.Points.Count; i++)
                {
                    var point = graph.Points[i];
                    if (Math.Abs(e.X - point.X) <= graph.radius && Math.Abs(e.Y - point.Y) <= graph.radius)
                    {
                        label_in_point.Text = "Вы в точке: " + (point.Number + 1).ToString();
                        graph.on_this_point = i;
                        break;
                    }
                    else
                    {
                        label_in_point.Text = "Точек не найдено.";
                        graph.on_this_point = -1;
                    }
                }
            else
            {
                
            }
        }

        private void label_in_point_Click(object sender, EventArgs e)
        {

        }

        private void editCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addWaysCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label_Points_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainPicture_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Minimized)
            graph.Redraw(MainPicture);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                //if(graph.PointsList.SelectedIndex >= 0)
                    graph.RemovePoint(graph.PointsList.SelectedIndex);
                if(graph.WaysList.SelectedIndex >= 0)
                    graph.RemoveWay(graph.WaysList.SelectedIndex);
            }
            if (e.KeyCode == Keys.Space)
                MessageBox.Show("xuq");
        }
    }
}
    