namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.c1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c2TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.proceedBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.a2TextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.a1TextBox = new System.Windows.Forms.TextBox();
            this.signTextBox = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "F = ";
            // 
            // c1TextBox
            // 
            this.c1TextBox.Location = new System.Drawing.Point(54, 16);
            this.c1TextBox.Name = "c1TextBox";
            this.c1TextBox.Size = new System.Drawing.Size(28, 20);
            this.c1TextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(81, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "* x1 + ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(156, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "* x2";
            // 
            // c2TextBox
            // 
            this.c2TextBox.Location = new System.Drawing.Point(129, 16);
            this.c2TextBox.Name = "c2TextBox";
            this.c2TextBox.Size = new System.Drawing.Size(28, 20);
            this.c2TextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(56, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "c1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(132, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "c2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 12;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(17, 71);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(199, 105);
            this.dataGridView.TabIndex = 13;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(17, 238);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(199, 24);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "ADD CONSTRAINT";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // proceedBtn
            // 
            this.proceedBtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.proceedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proceedBtn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.proceedBtn.ForeColor = System.Drawing.Color.White;
            this.proceedBtn.Location = new System.Drawing.Point(17, 300);
            this.proceedBtn.Name = "proceedBtn";
            this.proceedBtn.Size = new System.Drawing.Size(199, 24);
            this.proceedBtn.TabIndex = 22;
            this.proceedBtn.Text = "PROCEED";
            this.proceedBtn.UseVisualStyleBackColor = false;
            this.proceedBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(194, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "b";
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(190, 184);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(26, 20);
            this.bTextBox.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(91, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "a2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(18, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "a1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(116, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "* x2";
            // 
            // a2TextBox
            // 
            this.a2TextBox.Location = new System.Drawing.Point(91, 185);
            this.a2TextBox.Name = "a2TextBox";
            this.a2TextBox.Size = new System.Drawing.Size(26, 20);
            this.a2TextBox.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(42, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 20);
            this.label14.TabIndex = 24;
            this.label14.Text = "* x1 +";
            // 
            // a1TextBox
            // 
            this.a1TextBox.Location = new System.Drawing.Point(18, 186);
            this.a1TextBox.Name = "a1TextBox";
            this.a1TextBox.Size = new System.Drawing.Size(26, 20);
            this.a1TextBox.TabIndex = 5;
            // 
            // signTextBox
            // 
            this.signTextBox.Location = new System.Drawing.Point(156, 184);
            this.signTextBox.Name = "signTextBox";
            this.signTextBox.Size = new System.Drawing.Size(26, 20);
            this.signTextBox.TabIndex = 7;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(259, 12);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(832, 511);
            this.chart.TabIndex = 31;
            this.chart.Text = "chart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1103, 535);
            this.Controls.Add(this.c2TextBox);
            this.Controls.Add(this.c1TextBox);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.a2TextBox);
            this.Controls.Add(this.a1TextBox);
            this.Controls.Add(this.signTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.proceedBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Input";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox c1TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox c2TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button proceedBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox a2TextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox a1TextBox;
        private System.Windows.Forms.TextBox signTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

