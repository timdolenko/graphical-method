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
            
            test();
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

        void buildFunction(Function function)
        {

            chart.Series.Clear();

            for (int i = 0; i < function.constraints.Length; i++)
            {
                Constraint current = function.constraints[i];
                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = current.ToString(),
                    //Color = System.Drawing.Color.Green,
                    IsVisibleInLegend = true,
                    //IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line
                };

                this.chart.Series.Add(series);
                chart.Scale(0.5);
                if (current.a1 == 0)
                {
                    double x2 = current.b / current.a2;
                    series.Points.AddXY(-100, x2);
                    series.Points.AddXY(100, x2);
                } else if (current.a2 == 0)
                {
                    double x1 = current.b / current.a1;
                    series.Points.AddXY(x1, -100);
                    series.Points.AddXY(x1, 100);
                } else
                {
                    double x1 = (current.b - current.a2 * 100) / current.a1;
                    double x2 = (current.b - current.a1 * 100) / current.a2;
                    series.Points.AddXY(x1, 100);
                    series.Points.AddXY(100, x2);
                }
            }
            chart.Invalidate();

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
    }
}
