using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            contextMenuStrip.Click += ContextMenuStrip_Click;
            dataGridView.CellMouseUp += DataGridView_CellMouseUp;
            dataGridView.ColumnCount = 1;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Columns[0].Width = 220;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.ClearSelection();
            setScale();

            initFieldOnChart();

            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
        }

        void initFieldOnChart()
        {
            var fieldSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Field",
                Color = System.Drawing.Color.Black,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Line
            };
            fieldSeries.BorderWidth = 1;
            chart.Series.Add(fieldSeries);
        }

        
        void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            double addedValue = 25;
            double differenceX = currentXMax - currentXMin;
            double differenceY = currentYMax - currentYMin;
            if ((differenceX > 50) && (differenceX > 50))
            {
                addedValue = 25;
            }
            else if ((differenceX > 25) && (differenceX > 25))
            {
                addedValue = 10;
            }
            else if ((differenceX > 10) && (differenceX > 10))
            {
                addedValue = 5;
            }
            else if ((differenceX > 5) && (differenceX > 5))
            {
                addedValue = 1;
            } else
            {
                addedValue = 0.1;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    currentYMax += addedValue;
                    currentYMin += addedValue;
                    setScale();
                    break;
                case Keys.Down:
                    currentYMax += -addedValue;
                    currentYMin += -addedValue;
                    setScale();
                    break;
                case Keys.Left:
                    currentXMax += -addedValue;
                    currentXMin += -addedValue;
                    setScale();
                    break;
                case Keys.Right:
                    currentXMax += addedValue;
                    currentXMin += addedValue;
                    setScale();
                    break;
                case Keys.Add:
                    if ((currentXMax - addedValue > currentXMin + addedValue) && currentYMax - addedValue > currentYMin - addedValue)
                    {
                        currentXMax += -addedValue;
                        currentXMin += addedValue;
                        currentYMax += -addedValue;
                        currentYMin += addedValue;
                        setScale();
                    }
                    break;
                case Keys.Subtract:
                    currentXMax += addedValue;
                    currentXMin += -addedValue;
                    currentYMax += addedValue;
                    currentYMin += -addedValue;
                    setScale();
                    break;
            }
        }
        
        public class Intersection
        {
            public Point intersectionPoint;
            public Constraint firstConstraint;
            public Constraint secondConstraint;

            public Intersection(Point point, Constraint first, Constraint second)
            {
                intersectionPoint = point;
                firstConstraint = first;
                secondConstraint = second;
            }
            public override bool Equals(object obj)
            {
                Intersection i = obj as Intersection;
                return ((firstConstraint == i.firstConstraint && secondConstraint == i.secondConstraint) || (firstConstraint == i.secondConstraint && secondConstraint == i.firstConstraint)) && intersectionPoint.x1 == i.intersectionPoint.x1 && intersectionPoint.x2 == i.intersectionPoint.x2;
            }

            public static bool operator ==(Intersection i1, Intersection i2)
            {
                return i1.Equals(i2);
            }

            public static bool operator !=(Intersection i1, Intersection i2)
            {
                return !i1.Equals(i2);
            }

            public override int GetHashCode()
            {
                int hash = 27;
                hash = (13 * hash) + intersectionPoint.GetHashCode();
                hash = (13 * hash) + firstConstraint.GetHashCode();
                hash = (13 * hash) + secondConstraint.GetHashCode();
                return hash;
            }
        }

        public struct Point
        {
            public double x1;
            public double x2;
            public Point(double x1, double x2)
            {
                this.x1 = x1;
                this.x2 = x2;
            }
        }

        List<Intersection> getIntersections(Constraint line, Constraint[] constraints)
        {
            List<Intersection> intersactions = new List<Intersection>();
            Constraint cons1 = line;
            for (int i = 0; i < constraints.Length; i++)
            {
                Constraint cons2 = constraints[i];

                if ((cons1.a1 != 0 && cons1.a2 == 0 && cons2.a1 == 0 && cons2.a2 != 0) || (cons2.a1 != 0 && cons2.a2 == 0 && cons1.a1 == 0 && cons1.a2 != 0))
                {
                    if (cons1.a1 != 0)
                    {
                        Point common = new Point(cons1.b, cons2.b);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    }
                    else
                    {
                        Point common = new Point(cons2.b, cons1.b);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    }
                } else if ((cons1.a2 != 0 || cons2.a2 != 0) && cons1.a1 != 0 && cons2.a1 != 0)
                {
                    Constraint c1 = new Constraint(cons1.a1 / cons1.a1, cons1.a2 / cons1.a1, cons1.b / cons1.a1, cons1.isGreater);
                    Constraint c2 = new Constraint(cons2.a1 / cons2.a1, cons2.a2 / cons2.a1, cons2.b / cons2.a1, cons2.isGreater);

                    if (c1.a2 - c2.a2 != 0)
                    {
                        double x2 = (c1.b - c2.b) / (c1.a2 - c2.a2);
                        double x1 = c1.b - c1.a2 * x2;
                        Point common = new Point(x1, x2);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    }
                } else if (cons2.a1 == 0)
                {
                    Constraint c1 = new Constraint(cons1.a1 / cons1.a1, cons1.a2 / cons1.a1, cons1.b / cons1.a1, cons1.isGreater);
                    if (c1.a2 - cons2.a2 != 0)
                    {
                        double x2 = (c1.b - cons2.b) / (c1.a2 - cons2.a2);
                        double x1 = c1.b - c1.a2 * x2;
                        Point common = new Point(x1, x2);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    } else
                    {
                        double x1 = c1.b - cons2.b;
                        double x2 = cons2.b / cons2.a2;
                        Point common = new Point(x1, x2);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    }
                }
                else if (cons1.a1 == 0)
                {
                    Constraint c2 = new Constraint(cons2.a1 / cons2.a1, cons2.a2 / cons2.a1, cons2.b / cons2.a1, cons2.isGreater);
                    if (c2.a2 - cons1.a2 != 0)
                    {
                        double x2 = (c2.b - cons1.b) / (c2.a2 - cons1.a2);
                        double x1 = c2.b - c2.a2 * x2;
                        Point common = new Point(x1, x2);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    } else
                    {
                        double x1 = c2.b - cons1.b;
                        double x2 = cons1.b / cons1.a2;
                        Point common = new Point(x1, x2);
                        Intersection inter = new Intersection(common, cons1, cons2);
                        if (!intersactions.Contains(inter))
                        {
                            intersactions.Add(inter);
                        }
                    }
                    
                }
            }


            return intersactions;
        }

        List<Intersection> getIntersections(Constraint[] constraints)
        {
            List<Intersection> intersactions = new List<Intersection>();
            for (int j = 0; j < constraints.Length; j++)
            {

                for (int i = 0; i < constraints.Length; i++)
                {
                    if (i != j)
                    {
                        Constraint cons1 = constraints[i];
                        Constraint cons2 = constraints[j];

                        if ((cons1.a1 != 0 && cons1.a2 == 0 && cons2.a1 == 0 && cons2.a2 != 0) || (cons2.a1 != 0 && cons2.a2 == 0 && cons1.a1 == 0 && cons1.a2 != 0))
                        {
                            if (cons1.a1 != 0)
                            {
                                Point common = new Point(cons1.b, cons2.b);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }
                            else
                            {
                                Point common = new Point(cons2.b, cons1.b);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }
                        }
                        else if ((cons1.a2 != 0 || cons2.a2 != 0) && cons1.a1 != 0 && cons2.a1 != 0)
                        {
                            Constraint c1 = new Constraint(cons1.a1 / cons1.a1, cons1.a2 / cons1.a1, cons1.b / cons1.a1, cons1.isGreater);
                            Constraint c2 = new Constraint(cons2.a1 / cons2.a1, cons2.a2 / cons2.a1, cons2.b / cons2.a1, cons2.isGreater);

                            if (c1.a2 - c2.a2 != 0)
                            {
                                double x2 = (c1.b - c2.b) / (c1.a2 - c2.a2);
                                double x1 = c1.b - c1.a2 * x2;
                                Point common = new Point(x1, x2);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }
                        }
                        else if (cons2.a1 == 0)
                        {
                            Constraint c1 = new Constraint(cons1.a1 / cons1.a1, cons1.a2 / cons1.a1, cons1.b / cons1.a1, cons1.isGreater);
                            if (c1.a2 - cons2.a2 != 0)
                            {
                                double x2 = (c1.b - cons2.b) / (c1.a2 - cons2.a2);
                                double x1 = c1.b - c1.a2 * x2;
                                Point common = new Point(x1, x2);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }
                            else
                            {
                                double x1 = c1.b - cons2.b;
                                double x2 = cons2.b / cons2.a2;
                                Point common = new Point(x1, x2);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }
                        }
                        else if (cons1.a1 == 0)
                        {
                            Constraint c2 = new Constraint(cons2.a1 / cons2.a1, cons2.a2 / cons2.a1, cons2.b / cons2.a1, cons2.isGreater);
                            if (c2.a2 - cons1.a2 != 0)
                            {
                                double x2 = (c2.b - cons1.b) / (c2.a2 - cons1.a2);
                                double x1 = c2.b - c2.a2 * x2;
                                Point common = new Point(x1, x2);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }
                            else
                            {
                                double x1 = c2.b - cons1.b;
                                double x2 = cons1.b / cons1.a2;
                                Point common = new Point(x1, x2);
                                Intersection inter = new Intersection(common, cons1, cons2);
                                if (!intersactions.Contains(inter))
                                {
                                    intersactions.Add(inter);
                                }
                            }

                        }
                    }
                }
            }
            

            return intersactions;
        }
        
        void adjustAxis(Constraint[] constraints)
        {
            List <Intersection> inters = getIntersections(constraints);
            Console.WriteLine(inters.Count);
            if (inters.Count > 0)
            {
                double maxX1 = inters[0].intersectionPoint.x1;
                foreach (Intersection inter in inters)
                {
                    if (inter.intersectionPoint.x1 > maxX1)
                    {
                        maxX1 = inter.intersectionPoint.x1;
                    }
                }
                double maxX2 = inters[0].intersectionPoint.x2;
                foreach (Intersection inter in inters)
                {
                    if (inter.intersectionPoint.x2 > maxX2)
                    {
                        maxX2 = inter.intersectionPoint.x2;
                    }
                }

                double minX1 = inters[0].intersectionPoint.x1;
                foreach (Intersection inter in inters)
                {
                    if (inter.intersectionPoint.x1 < minX1)
                    {
                        minX1 = inter.intersectionPoint.x1;
                    }
                }
                double minX2 = inters[0].intersectionPoint.x2;
                foreach (Intersection inter in inters)
                {
                    if (inter.intersectionPoint.x2 < minX2)
                    {
                        minX2 = inter.intersectionPoint.x2;
                    }
                }

                double widthX1 = maxX1 - minX1;
                double heightX2 = maxX2 - minX2;

                currentXMax = Convert.ToInt32(maxX1 + widthX1);
                currentXMin = Convert.ToInt32(minX1 - widthX1);
                currentYMax = Convert.ToInt32(maxX2 + heightX2);
                currentYMin = Convert.ToInt32(minX2 - heightX2);

                setScale();
            }
        }

        public List<Constraint> constraints = new List<Constraint>();
        public Function currentFunction;
        
        void remove(int index)
        {
            chart.Series.Remove(chart.Series[constraints[index].ToString()]);
            chart.Series["Field"].Points.Clear();
            constraints.RemoveAt(index);
            dataGridView.Rows.RemoveAt(index);
        }
        void add(Constraint constraint)
        {
            constraints.Add(constraint);

            clearConstraintsTextBoxes();

            dataGridView.Rows.Add(constraint.ToString());
            dataGridView.ClearSelection();

            drawConstraint(constraint);
            chart.ApplyPaletteColors();
            dataGridView.Rows[constraints.Count - 1].Cells[0].Style.BackColor = chart.Series[constraint.ToString()].Color;
        }

        double chartConstraintValue = 10000;

        void drawConstraint(Constraint constraint)
        {
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = constraint.ToString(),
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line
            };
            series.BorderWidth = 2;

            this.chart.Series.Add(series);
            chart.Series["Field"].Points.Clear();

            if (constraint.a1 == 0)
            {
                double x2 = constraint.b / constraint.a2;
                series.Points.AddXY(-chartConstraintValue, x2);
                series.Points.AddXY(chartConstraintValue, x2);
            }
            else if (constraint.a2 == 0)
            {
                double x1 = constraint.b / constraint.a1;
                series.Points.AddXY(x1, -chartConstraintValue);
                series.Points.AddXY(x1, chartConstraintValue);
            }
            else
            {
                double x1 = (constraint.b - constraint.a2 * chartConstraintValue) / constraint.a1;
                double x2 = (constraint.b - constraint.a2 * -chartConstraintValue) / constraint.a1;
                series.Points.AddXY(x1, chartConstraintValue);
                series.Points.AddXY(x2, -chartConstraintValue);

            }
            adjustAxis(constraints.ToArray());
        }
        
        void clearConstraintsTextBoxes()
        {
            a1TextBox.Text = "";
            a2TextBox.Text = "";
            bTextBox.Text = "";
            signTextBox.Text = "";
        }

        void clearFunctionTextBoxes()
        {
            c1TextBox.Text = "";
            c2TextBox.Text = "";
        }
        
        void buildFunction(Function function)
        {
            currentFunction = function;

            chart.ChartAreas[0].AxisX.Interval = 2;
            chart.ChartAreas[0].AxisY.Interval = 2;
             
            drawField(function.constraints);

            chart.Invalidate();
            adjustAxis(function.constraints);
        }

        void drawField(Constraint[] constraints)
        {
            
            double scale = 100;

            Series fieldSeries = chart.Series["Field"];

            for (double i = -scale; i <= scale; i += 0.1)
            {
                

                Point point = new Point(i, -scale);
                Point topPoint = new Point(i, -scale + scale);

                Constraint currentLine = new Constraint(1, 0, i, true);

                List<Intersection> inters = getIntersections(currentLine, constraints);
                List<Intersection> sortedInters = inters.OrderBy(x => x.intersectionPoint.x2).ToList();
                
                if(sortedInters.Count != 0)
                {
                    if (isPointLegit(checkPoint(point, constraints)))
                    {
                        int interIndex = 0;

                        while (!isPointLegit(checkPoint(sortedInters[interIndex].intersectionPoint, constraints)) && interIndex < sortedInters.Count - 1)
                        {
                            interIndex++;
                        }
                        topPoint = sortedInters[interIndex].intersectionPoint;
                    }
                    else
                    {

                        int interIndex = 0;

                        while (!isPointLegit(checkPoint(sortedInters[interIndex].intersectionPoint, constraints)) && interIndex < sortedInters.Count - 1)
                        {
                            interIndex++;
                        }

                        point = sortedInters[interIndex].intersectionPoint;
                        if (interIndex != sortedInters.Count - 1)
                        {

                            while (isPointLegit(checkPoint(sortedInters[interIndex].intersectionPoint, constraints)) && interIndex < sortedInters.Count - 1)
                            {
                                interIndex++;
                            }

                            topPoint = sortedInters[interIndex].intersectionPoint;

                            if (isPointLegit(checkPoint(topPoint, constraints)))
                            {
                                Point upperTopPoint = new Point(sortedInters[interIndex].intersectionPoint.x1, sortedInters[interIndex].intersectionPoint.x2 + scale);

                                if (isPointLegit(checkPoint(upperTopPoint, constraints)))
                                {
                                    topPoint = upperTopPoint;
                                }
                            } else
                            {
                                topPoint = sortedInters[interIndex - 1].intersectionPoint;
                            }

                        }
                        else
                        {
                            topPoint = new Point(point.x1, point.x2 + scale);
                        }
                    }
                }

                

                if (isPointLegit(checkPoint(point,constraints)) && isPointLegit(checkPoint(topPoint,constraints)))
                {
                    fieldSeries.Points.AddXY(point.x1, point.x2);
                    fieldSeries.Points.AddXY(topPoint.x1, topPoint.x2);
                    
                    Console.WriteLine($"Legit ({point.x1},{point.x2}) ({topPoint.x1},{topPoint.x2})");
                } else
                {
                    Console.WriteLine($"Not Legit ({point.x1},{point.x2}) ({topPoint.x1},{topPoint.x2})");
                }
            }
        }


        double accuracy = 0.01;

        Tuple<bool, Constraint>[] checkPoint(Point point, Constraint[] constraints)
        {
            Tuple<bool, Constraint>[] result = new Tuple<bool, Constraint>[constraints.Length];
            
            for (int i = 0; i < constraints.Length; i++)
            {
                Constraint current = constraints[i];
                double left = (point.x1 * current.a1 + point.x2 * current.a2);
                if (current.isGreater)
                {
                    
                    bool isFriendly = left >= current.b || left >= current.b + accuracy || left >= current.b - accuracy;
                    result[i] = new Tuple<bool, Constraint>(isFriendly, current);
                } else
                {
                    bool isFriendly = left <= current.b || left <= current.b + accuracy || left <= current.b - accuracy;
                    result[i] = new Tuple<bool, Constraint>(isFriendly, current);
                }
                
            }
            return result;
        }

        bool isPointLegit(Tuple<bool, Constraint>[] checkLogs)
        {
            foreach(Tuple<bool, Constraint> log in checkLogs)
            {
                if (!log.Item1)
                {
                    return false;
                }
            }
            return true;
        }

        List<Intersection> getIntersForConstr(List<Intersection> intersections, Constraint cons)
        {
            List<Intersection> inters = new List<Intersection>();
            foreach(Intersection intersection in intersections)
            {
                if (intersection.firstConstraint == cons || intersection.secondConstraint == cons)
                {
                    inters.Add(intersection);
                }
            }
            return inters;
        }

        List<Intersection> getLegitInters(List<Intersection> intersections, Constraint[] constraints)
        {
            List<Intersection> inters = new List<Intersection>();
            foreach (Intersection intersection in intersections)
            {
                if (isPointLegit(checkPoint(intersection.intersectionPoint, constraints)))
                {
                    inters.Add(intersection);
                }
            }
            return inters;
        }

        void clear()
        {
            chart.Series.Clear();
            initFieldOnChart();
            clearConstraintsTextBoxes();
            clearFunctionTextBoxes();
            dataGridView.Rows.Clear();
            constraints.Clear();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double a1 = Convert.ToDouble(this.a1TextBox.Text);
                double a2 = Convert.ToDouble(this.a2TextBox.Text);
                double b = Convert.ToDouble(this.bTextBox.Text);

                Constraint constraint = new Constraint(a1, a2, b, signTextBox.Text == ">=");
                Console.WriteLine(constraint.ToString());
                add(constraint);
            }
            catch
            {
                clearConstraintsTextBoxes();
            }
        }
        
        private void proceedBtn_Click(object sender, EventArgs e)
        {


            try
            {
                double c1 = Convert.ToDouble(this.c1TextBox.Text);
                double c2 = Convert.ToDouble(this.c2TextBox.Text);

                Function function = new Function(c1, c2, constraints.ToArray());

                if (function != null)
                {
                    buildFunction(function);
                }
            }
            catch
            {
                clearConstraintsTextBoxes();
                c1TextBox.Text = "";
                c2TextBox.Text = "";
            }
        }

        double currentXMax = 250;
        double currentXMin = -50;
        double currentYMax = 250;
        double currentYMin = -50;
        
        void setScale()
        {
            chart.ChartAreas[0].AxisX.Maximum = currentXMax;
            chart.ChartAreas[0].AxisX.Minimum = currentXMin;
            chart.ChartAreas[0].AxisY.Maximum = currentYMax;
            chart.ChartAreas[0].AxisY.Minimum = currentYMin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void test1Btn_Click(object sender, EventArgs e)
        {
            clear();
            c1TextBox.Text = "2";
            c2TextBox.Text = "-1";
            add(new Constraint(-2, -3, 6, false));
            add(new Constraint(-1, 2, 6, false));
            add(new Constraint(1, 0, 3, false));
            add(new Constraint(1, 0, -1, true));
        }

        private void test2Btn_Click(object sender, EventArgs e)
        {
            clear();
            c1TextBox.Text = "1";
            c2TextBox.Text = "-2";
            add(new Constraint(1, 1, 4, false));
            add(new Constraint(3, 1, 4, true));
            add(new Constraint(1, 5, 4, true));
            add(new Constraint(1, 0, 3, false));
            add(new Constraint(0, 1, 3, false));
        }

        private void test3Btn_Click(object sender, EventArgs e)
        {
            clear();
            c1TextBox.Text = "1";
            c2TextBox.Text = "2";
            add(new Constraint(1, 2, 6, false));
            add(new Constraint(2, 1, 8, false));
            add(new Constraint(0, 1, 2, false));
            add(new Constraint(1, 0, 0, true));
            add(new Constraint(0, 1, 0, true));
        }

        private void test4Btn_Click(object sender, EventArgs e)
        {
            clear();
            c1TextBox.Text = "1";
            c2TextBox.Text = "1";
            add(new Constraint(10, 6, 10, true));
            add(new Constraint(1, 6, -4, true));
            add(new Constraint(2, 2, 3, false));
        }

        private void test5Btn_Click(object sender, EventArgs e)
        {
            clear();
            c1TextBox.Text = "1";
            c2TextBox.Text = "1";
            add(new Constraint(1, 1, 1, true));
            add(new Constraint(2, 1, 0, true));
            add(new Constraint(1, 4, 4, true));
        }

        private int rowIndex = 0;

        private void DataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView.CurrentCell = this.dataGridView.Rows[e.RowIndex].Cells[0];
                this.contextMenuStrip.Show(this.dataGridView, e.Location);
                contextMenuStrip.Show(System.Windows.Forms.Cursor.Position);
            }
        }

        private void ContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView.Rows[this.rowIndex].IsNewRow)
            {
                remove(this.rowIndex);
            }
        }
    }
}
