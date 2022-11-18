using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_dotNET
{
    public class GraphProcessor : GraphCH
    {
        //GraphWriter graph = new GraphWriter();

        public GraphProcessor(GraphWriter grw)
        {
            this.Points = grw.Points;
        }
        public GraphProcessor(GraphCH grw)
        {
            this.Points = grw.Points;
        }
        public List<PointCH> SetSort(List<PointCH> mas)
        {
            PointCH temp;
            for (int i = 0; i < mas.Count; i++)
            {
                for (int j = i + 1; j < mas.Count; j++)
                {
                    if (mas[i].Number > mas[j].Number)
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        public List<PointCH> FindIndependentSets(List<PointCH> pts = null, int index_ = 0)
        {
            if (pts == null) pts = Points; //graph
            var set = new List<PointCH>();
            set.Add(pts[index_]);
            for (int i = 0; i < pts.Count; i++) //По всем точкам
            {
                if (i != index_)
                {
                    set = FindIndependentSets(pts[i], set);
                }
            }
            //
            for (int i = 0; i < set.Count; i++)
            {
                if (i < 0 || i >= set.Count) break;
                for (int j = 0; j < set.Count; j++)
                {
                    if (j < 0 || j >= set.Count) break;
                    //
                    try
                    {
                        if (set[i].ConnectedByStep(set[j]))
                            try { set.RemoveAt(j); }
                            catch { }
                    }
                    catch { break; }
                }
            }
            return set;
        }
        public List<PointCH> FindIndependentSets(PointCH pt, List<PointCH> indexes)
        {
            List<PointCH> set = new List<PointCH>();
            set.AddRange(indexes);
            foreach (var point in indexes)
            {
                if (point.ConnectedByStep(pt) == false)
                {
                    if (set.Contains(pt) == false)
                    {
                        set.Add(pt);
                    }
                }
            }
            return set;
        }
        public List<List<PointCH>> FindAllIndependentSets(List<PointCH> indexes)
        {
            List<PointCH> set = new List<PointCH>();
            List<List<PointCH>> any_sets = new List<List<PointCH>>();
            set.AddRange(indexes);

            foreach (var pt in indexes)
            {
                foreach (var point in indexes)
                {
                    if (point.ConnectedByStep(pt) == false)
                    {
                        if (set.Contains(pt) == false)
                        {
                            set.Add(pt);
                        }
                        any_sets.Add(set);
                    }
                }
                set.Clear();
                set.AddRange(indexes);
            }
            foreach (var ind1 in indexes)
            {
                foreach (var ind2 in indexes)
                {
                    if (ind1.ConnectedByStep(ind2) == false && ind1 != ind2)
                        any_sets.Add(new List<PointCH>() { ind1, ind2 });
                }
            }

            Stack<PointCH> points_stack = new Stack<PointCH>();
            foreach (var item in SetSort(indexes))
            {
                points_stack.Push(item);
            }
            for (int i = 0; i < indexes.Count; i++)
            {
                List<PointCH> pts_list = new List<PointCH>();
                foreach (var item in points_stack)
                {
                    pts_list.Add(item);
                }
                points_stack.Pop();
                any_sets.Add(pts_list);
            }

            for (int i = 0; i < any_sets.Count; i++)
            {
                any_sets[i] = SetSort(any_sets[i]);
            }

            return any_sets;
        }
        public List<PointCH> ReversePoints(List<PointCH> sets)
        {
            List<PointCH> re_sets = new List<PointCH>();

            for (int i = 0; i < sets.Count; i++)
            {
                re_sets.Add(sets[sets.Count - (i + 1)]);
            }

            return re_sets;
        }
        public List<List<PointCH>> AllIndependentSets(List<PointCH> ptss = null, System.Windows.Forms.ProgressBar bar=null)
        {
            if (ptss == null) ptss = Points; //graph
            bar.Visible = true;
            //В обычном порядке
            List<List<PointCH>> sets = new List<List<PointCH>>();
            List<List<PointCH>> re_sets = new List<List<PointCH>>();
            var re_pts = ReversePoints(ptss);


            if (ptss.Count > 0)
            {
                for (int i = 0; i < ptss.Count; i++)
                {
                    sets.Add(SetSort(FindIndependentSets(ptss, i)));
                }
            }

            if (re_pts.Count > 0)
            {
                for (int i = 0; i < re_pts.Count; i++)
                {
                    re_sets.Add(SetSort(FindIndependentSets(re_pts, i)));
                }
            }
            sets.AddRange(re_sets);

            sets.AddRange(FindAllIndependentSets(ptss));
            sets.AddRange(FindAllIndependentSets(re_pts));
            int sts = sets.Count;
            for (int i = 0; i < sts; i++)
            {
                sets.AddRange(FindAllIndependentSets(sets[i]));
            }

            bar.Maximum = sets.Count;
            for (int ij = 0; ij < 2; ij++)
            {
                var st_counter = sets.Count;

                for (int i = 0; i < st_counter; i++)
                {
                    for (int j = 0; j < sets[i].Count; j++)
                    {
                        int popo = sets[i].Count;
                        for (int k = 0; k < popo; k++)
                        {
                            try
                            {
                                if (sets[i][k].ConnectedByStep(sets[i][j]))
                                {
                                    sets[i].Remove(sets[i][j]);
                                    popo--;
                                }
                            }
                            catch { }
                        }
                    }
                    if (bar.Value < bar.Maximum)
                        try { bar.Value += 1; }
                        catch { }
                }
            }

            bar.Value = 0;
            bar.Visible = false;
            return sets;
        }
    }
}
