using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Kursovaya_dotNET
{
    public partial class Form1 : Form
    {
        GraphWriter graph;
        GraphProcessor processor;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            graph = new GraphWriter(MainPicture,PointsList,WaysList);
            processor = new GraphProcessor(graph);

            //Функционал для того чтобы можно было в винде использовать "Открыть с помощью..."
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (args[1].EndsWith(".chg"))
                    graph.OpenXML(args[1]);
                if (args[1].EndsWith(".chg2"))
                    graph.OpenXML(args[1],true);
            }
            //
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PointsList.Focus();
            if (editCheckBox.Checked == false && addWaysCheckBox.Checked == false && e.Button == MouseButtons.Left)
            {
                //
                for (int i = 0; i < graph.Points.Count; i++)
                {
                    var point = graph.Points[i];
                    if (Math.Abs(e.X - point.X) <= graph.radius * 2 && Math.Abs(e.Y - point.Y) <= graph.radius * 2)
                    {
                        graph.SelectPoint(graph.on_this_point);
                        graph.first_point = graph.on_this_point;
                        graph.PointsList.SelectedIndex = graph.on_this_point;
                        return;
                    }
                }
                //
                graph.DrawPoint(graph.pen, new Rectangle(e.X - graph.radius / 2, e.Y - graph.radius / 2, graph.radius, graph.radius), graph.Points.Count);
            }
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                if (graph.on_this_point != -1)
                {
                    graph.SelectPoint(graph.on_this_point);
                    graph.PointsList.SelectedIndex = graph.on_this_point;
                }
            if(e.Button == MouseButtons.Right) // Постройка рёбер
            {
                if(graph.first_point != -1)
                {
                    if(graph.on_this_point != -1)
                    {
                        foreach (var item in graph.Ways)
                        {
                            if (item.Begin == graph.Points[graph.first_point]
                                && item.End == graph.Points[graph.on_this_point] ||
                                item.Begin == graph.Points[graph.on_this_point]
                                && item.End == graph.Points[graph.first_point]
)
                            {
                                graph.SelectPoint(graph.first_point);
                                graph.on_this_point = -1;
                                MessageBox.Show("Заданное ребро уже существует!", "Ошибка!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }
                        }

                        graph.DrawWay(graph.Points[graph.first_point], graph.Points[graph.on_this_point]);
                        graph.on_this_point = -1;
                        graph.first_point = -1;
                        graph.PointsList.ClearSelected();
                        button3.Enabled = false;
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
            button3.Enabled = false;
            button5.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            graph.DrawPoints();
        }
        private void button3_Click(object sender, EventArgs e) //Удаление вершины
        {
            graph.RemovePoint(PointsList.SelectedIndex);
            button3.Enabled = false;
            PointsList.Focus();
        }
        private void PointsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graph.PointsList.SelectedIndex >= 0)
            {
                button3.Enabled = true;
                button5.Enabled = false;
                graph.SelectPoint(graph.PointsList.SelectedIndex);
                graph.WaysList.ClearSelected();
            }
        }
        private void button4_Click(object sender, EventArgs e) {}
        private void button5_Click(object sender, EventArgs e) //Удаление ребра
        {
            graph.RemoveWay(graph.WaysList.SelectedIndex);
            button5.Enabled = false;
            PointsList.Focus();
        }
        private void WaysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graph.WaysList.SelectedIndex >= 0)
            {
                button5.Enabled = true;
                button3.Enabled = false;
                graph.PointsList.ClearSelected();
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
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
        }
        //
        private void label_in_point_Click(object sender, EventArgs e) {}
        private void editCheckBox_CheckedChanged(object sender, EventArgs e){}
        private void addWaysCheckBox_CheckedChanged(object sender, EventArgs e){}
        private void label_Points_Click(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
        private void Form1_Load(object sender, EventArgs e) {}
        //
        private void MainPicture_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Minimized)
            graph.Redraw(MainPicture);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e){}

        private void button2_Click_1(object sender, EventArgs e)
        {
            var sets = new List<List<PointCH>>();
            sets = processor.AllIndependentSets(null,progressBar);
            MaxIndSets form2 = new MaxIndSets(ref sets);
            form2.ShowDialog();
            button2.Text = "Поиск максимального незавсимого множества [Enter]";
            PointsList.Focus();
        }

        private void PointsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (graph.PointsList.SelectedIndex >= 0)
                {
                    graph.RemovePoint(graph.PointsList.SelectedIndex);
                    button3.Enabled = false;
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                graph.ClearPoints();
                button3.Enabled = false;
                button5.Enabled = false;
            }
            if (e.KeyCode == Keys.F12)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    return;
                }
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            if (e.KeyCode == Keys.Return) //Открыть результаты
            {
                button2.Text = "Идёт поиск независимых множеств...";
                var sets = processor.AllIndependentSets(null,progressBar);
                MaxIndSets form2 = new MaxIndSets(ref sets);
                form2.ShowDialog();
                button2.Text = "Поиск максимального незавсимого множества [Enter]";
                PointsList.Focus();
            }
        }
        private void WaysList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (graph.WaysList.SelectedIndex >= 0)
                {
                    graph.RemoveWay(graph.WaysList.SelectedIndex);
                    button5.Enabled = false;
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = 
                MessageBox.Show("Вы уверены что хотите выйти из ChGraph?", 
                "Подтвердите действие", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ChangeWinFormButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topBorder_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
        }
        Point MouseHook = new Point();
        private void topBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (e.Button != MouseButtons.Left)
                {
                    MouseHook = e.Location;
                }
                else
                {
                    Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
                }
            }
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Red;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Transparent;
        }

        private void ChangeWinFormButton_MouseEnter(object sender, EventArgs e)
        {
            ChangeWinFormButton.BackColor = Color.DarkGray;
        }

        private void ChangeWinFormButton_MouseLeave(object sender, EventArgs e)
        {
            ChangeWinFormButton.BackColor = Color.Transparent;
        }

        private void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Color.DarkGray;
        }

        private void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Color.Transparent;
        }

        private void topBorder_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.Location.Y < 0 && this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Location = new Point(300,200);
                //return;
            }
            if(this.Cursor == Cursors.Hand)
                this.Cursor = Cursors.Default;
        }

        private void topBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                Cursor = Cursors.Hand;
        }
        public void SavePicture(Image picture)
        {
            if (picture != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить граф как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Изображение (*.PNG)|*.png|Файл графа (*.CHG)|*.chg|Бинарный файл графа (*.CHG2)|*.chg2";

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    if (savedialog.FileName.EndsWith(".png")) {
                        try
                        {
                            graph.SelectPoint(-1);
                            picture.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            var dr = MessageBox.Show("Изображение успешно сохранено"
                                + Environment.NewLine
                                + "Просмотреть файл?", "Выполнено",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dr == DialogResult.Yes)
                                Process.Start(savedialog.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить изображение", "Ошибка!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if(savedialog.FileName.EndsWith(".chg"))
                    {
                        try
                        {
                            graph.SaveXML(savedialog.FileName);
                            var dr = MessageBox.Show("Граф успешно сохраненён", "Выполнено",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить граф", "Ошибка!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (savedialog.FileName.EndsWith(".chg2"))
                    {
                        try
                        {
                            graph.SaveXML(savedialog.FileName,true);
                            var dr = MessageBox.Show("Граф успешно сохраненён", "Выполнено",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить граф", "Ошибка!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно сохранить граф - пустой файл", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SavePicture(MainPicture.Image);
        }
        private void SaveButton_MouseEnter(object sender, EventArgs e)
        {
            SaveButton.BackColor = Color.Gray;
        }
        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            SaveButton.BackColor = Color.Transparent;
        }
        private void PointsList_Click(object sender, EventArgs e)
        {
            
        }
        private void PointsList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Y > PointsList.Items.Count * 24)
            {
                graph.SelectPoint(-1);
                button3.Enabled = false;
            }
        }
        private void WaysList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Y > WaysList.Items.Count * 24)
            {
                WaysList.ClearSelected();
                button5.Enabled = false;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Title = "Открыть файл графа...";
            opfd.CheckPathExists = true;
            opfd.Filter = "Файл графа (*.CHG)|*.chg|Бинарный файл графа (*.CHG2)|*.chg2";

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                graph.ClearPoints();
                try
                {
                    if(opfd.FileName.EndsWith(".chg"))
                        graph.OpenXML(opfd.FileName);
                    if (opfd.FileName.EndsWith(".chg2"))
                        graph.OpenXML(opfd.FileName,true);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Gray;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.Transparent;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Text = "Идёт поиск независимых множеств...";
        }

        private void PointsList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            button2.Text = "Идёт поиск независимых множеств...";
        }
    }
}
    