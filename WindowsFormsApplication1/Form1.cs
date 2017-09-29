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
            dataGridView.ColumnCount = 1;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Columns[0].Width = 220;
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.ClearSelection();
            setScale();

            this.KeyUp += new KeyEventHandler(Form1_KeyUp);

            test();
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            int addedValue = 50;
            double differenceX = currentXMax - currentXMin;
            double differenceY = currentYMax - currentYMin;
            if ((differenceX > 100) && (differenceY > 100))
            {
                addedValue = 50;
            }
            else if ((differenceX > 50) && (differenceX > 50))
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
                    
                    currentXMax += -addedValue;
                    currentXMin += addedValue;
                    currentYMax += -addedValue;
                    currentYMin += addedValue;
                    setScale();
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

        List<Point> getCommons(Constraint[] constraints)
        {
            List<Point> commons = new List<Point>();
            for (int j = 0; j < constraints.Length; j++)
            {

                for (int i = 0; i < constraints.Length; i++)
                {
                    if (i != j)
                    {
                        Constraint cons1 = constraints[i];
                        Constraint cons2 = constraints[j];

                        if ((cons1.a2 != 0 || cons2.a2 != 0) && cons1.a1 != 0 && cons2.a1 != 0)
                        {
                            Constraint c1 = new Constraint(cons1.a1 / cons1.a1, cons1.a2 / cons1.a1, cons1.b / cons1.a1, cons1.isGreater);
                            Constraint c2 = new Constraint(cons2.a1 / cons2.a1, cons2.a2 / cons2.a1, cons2.b / cons2.a1, cons2.isGreater);

                            double x2 = (c1.b - c2.b) / (c1.a2 - c2.a2);
                            double x1 = c1.b - c1.a2 * x2;
                            Point common = new Point(x1, x2);
                            if (!commons.Contains(common))
                            {
                                commons.Add(common);
                            }
                        }
                        else if (cons2.a1 == 0)
                        {
                            Constraint c1 = new Constraint(cons1.a1 / cons1.a1, cons1.a2 / cons1.a1, cons1.b / cons1.a1, cons1.isGreater);

                            double x2 = (c1.b - cons2.b) / (c1.a2 - cons2.a2);
                            double x1 = c1.b - c1.a2 * x2;
                            Point common = new Point(x1, x2);
                            if (!commons.Contains(common))
                            {
                                commons.Add(common);
                            }
                        }
                        else if (cons1.a1 == 0)
                        {
                            Constraint c2 = new Constraint(cons2.a1 / cons2.a1, cons2.a2 / cons2.a1, cons2.b / cons2.a1, cons2.isGreater);

                            double x2 = (c2.b - cons1.b) / (c2.a2 - cons1.a2);
                            double x1 = c2.b - c2.a2 * x2;
                            Point common = new Point(x1, x2);
                            if (!commons.Contains(common))
                            {
                                commons.Add(common);
                            }
                        }
                    }
                }
            }
            

            return commons;
        }

        void adjustAxis(Constraint[] constraints)
        {
            List <Point> commons = getCommons(constraints);
            Console.WriteLine(commons.Count);
            if (commons.Count > 0)
            {
                double maxX1 = commons[0].x1;
                foreach (Point common in commons)
                {
                    if (common.x1 > maxX1)
                    {
                        maxX1 = common.x1;
                    }
                }
                double maxX2 = commons[0].x2;
                foreach (Point common in commons)
                {
                    if (common.x2 > maxX2)
                    {
                        maxX2 = common.x2;
                    }
                }

                double minX1 = commons[0].x1;
                foreach (Point common in commons)
                {
                    if (common.x1 < minX1)
                    {
                        minX1 = common.x1;
                    }
                }
                double minX2 = commons[0].x2;
                foreach (Point common in commons)
                {
                    if (common.x2 < minX2)
                    {
                        minX2 = common.x2;
                    }
                }

                double widthX1 = maxX1 - minX1;
                double heightX2 = maxX2 - minX2;

                currentXMax = maxX1 + widthX1;
                currentXMin = minX1 - widthX1;
                currentYMax = maxX2 + heightX2;
                currentYMin = minX2 - heightX2;

                setScale();
            }
        }

        public List<Constraint> constraints = new List<Constraint>();

        void test()
        {
            c1TextBox.Text = "2";
            c2TextBox.Text = "-1";
            add(new Constraint(1,0,3,false));
            add(new Constraint(1, 0, -1, true));
            add(new Constraint(-2, -3, 6, false));
            add(new Constraint(-1, 2, 6, false));
            add(new Constraint(0, 1, 0, false));
            add(new Constraint(1, 0, 0, false));

        }

        void add(Constraint constraint)
        {
            constraints.Add(constraint);

            clearConstraintsTextBoxes();

            dataGridView.Rows.Add(constraint.ToString());
            dataGridView.ClearSelection();
        }

        void clearConstraintsTextBoxes()
        {
            a1TextBox.Text = "";
            a2TextBox.Text = "";
            bTextBox.Text = "";
            signTextBox.Text = "";
        }
        public double Interval { get; set; }
        void buildFunction(Function function)
        {
         //   public double Interval { get; set; }

        chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Interval = 2;
            chart.ChartAreas[0].AxisY.Interval = 2;
            chart.ChartAreas[0].AxisY.StripLines.Add(new StripLine());
            chart.ChartAreas[0].AxisY.StripLines[0].BackColor = Color.Black;
            chart.ChartAreas[0].AxisY.StripLines[0].StripWidth = 0.1;
            chart.ChartAreas[0].AxisX.StripLines.Add(new StripLine());
            chart.ChartAreas[0].AxisX.StripLines[0].BackColor = Color.Black;
            chart.ChartAreas[0].AxisX.StripLines[0].StripWidth = 0.1;
            //chart.ChartAreas[0].AxisY.StripLines[0].Interval = 10000;
            //chart.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = 20;
            //var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            //{
            //    Name = "osX",
            //    //Color = System.Drawing.Color.Green,
            //    IsVisibleInLegend = true,
            //    // IsXValueIndexed = true,
            //    ChartType = SeriesChartType.Line
            //};
            //chart.Series["osX"].BorderWidth = 2;
            ////chart.Invalidate();

            for (int i = 0; i < function.constraints.Length; i++)
            {
                Constraint current = function.constraints[i];
                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = current.ToString(),
                    //Color = System.Drawing.Color.Green,
                    IsVisibleInLegend = true,
                   // IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line
                };

                //series.Points.AddXY(0, 100);
                //series.Points.AddXY(0, -100);
                //series.Points.AddXY(100, 0);
                //series.Points.AddXY(-100, 0);


                this.chart.Series.Add(series);



                if (current.a1 == 0)
                {
                    double x2 = current.b / current.a2;
                    series.Points.AddXY(-30, x2);
                    series.Points.AddXY(30, x2);



                }
                else if (current.a2 == 0)
                {
                    double x1 = current.b / current.a1;
                    series.Points.AddXY(x1, -30);
                    series.Points.AddXY(x1, 30);
                } else
                {
                    double x1 = (current.b - current.a2 *30) / current.a1;
                    double x2 = (current.b - current.a2 * -30) / current.a1;
                    series.Points.AddXY(x1, 30);
                    series.Points.AddXY(x2, -30);

                }
            }

            List<Point> commons = getCommons(function.constraints);

            var odrSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "ODR",
                //Color = System.Drawing.Color.Green,
                IsVisibleInLegend = true,
                //IsXValueIndexed = true,
                ChartType = SeriesChartType.Area
            };

            this.chart.Series.Add(odrSeries);

            for (int i = 0; i < commons.Count; i++)
            {
                Point current = commons[i];

                odrSeries.Points.AddXY(current.x1, current.x2);
            }

            chart.Invalidate();
            adjustAxis(function.constraints);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double a1 = Convert.ToDouble(this.a1TextBox.Text);
                double a2 = Convert.ToDouble(this.a2TextBox.Text);
                double b = Convert.ToDouble(this.bTextBox.Text);

                Constraint constraint = new Constraint(a1, a2, b, signTextBox.Text == ">=");
                if (constraint != null)
                {
                    add(constraint);
                }
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
    }
}
