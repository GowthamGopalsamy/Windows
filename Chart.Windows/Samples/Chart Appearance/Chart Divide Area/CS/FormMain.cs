
#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.Drawing;
using System.Collections.Generic;

namespace Syncfusion.Windows.Forms.Chart.Samples
{
    /// <summary>
    /// The ChartControl sample form.
    /// </summary>
    public class FormMain : MetroForm
    {
        private Syncfusion.Windows.Forms.Chart.ChartControl chartControl1;
        private DesignerPanel designerPanel1;
        private ButtonAdv buttonAdv3;
        private ButtonAdv buttonAdv2;
        private ButtonAdv buttonAdv1;
        private ButtonAdv buttonAdv4;
        private CheckBox checkBox1;
        private IContainer components = null;
        private Color[] color1, color2, color3, color4, color5, color6, color7, color8;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;

        #region Form's  Constructor, Main And Dispose
        public FormMain()
        {
            //
            // Required for Windows Form Designer support
            //
            BorderColor = Color.FromArgb(0xFF, 0xCD, 0xCD, 0xCD);
            BorderThickness = 3;
            CaptionBarHeight = 75;
            CaptionBarColor = Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2);
            CaptionFont = new Font("Segoe UI", 22.0f);
            CaptionForeColor = Color.White;
            CaptionAlign = HorizontalAlignment.Left;
            ShowIcon = false;
            CaptionButtonColor = Color.White;
            CaptionButtonHoverColor = Color.White;                     
            InitializeComponent();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new FormMain());
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.designerPanel1 = new DesignerPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv4 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonAdv3 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv2 = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.designerPanel1)).BeginInit();
            this.designerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chartControl1.DataSourceName = "";
            this.chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl1.Legend.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chartControl1.Legend.Location = new System.Drawing.Point(58, 464);
            this.chartControl1.Legend.Orientation = Syncfusion.Windows.Forms.Chart.ChartOrientation.Horizontal;
            this.chartControl1.Legend.Position = Syncfusion.Windows.Forms.Chart.ChartDock.Bottom;
            this.chartControl1.Localize = null;
            this.chartControl1.Location = new System.Drawing.Point(12, 22);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PrimaryXAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryXAxis.Margin = true;
            this.chartControl1.PrimaryXAxis.SmartDateZoomMonthLevelLabelFormat = "m";
            this.chartControl1.PrimaryYAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryYAxis.Margin = true;
            this.chartControl1.PrimaryYAxis.SmartDateZoomMonthLevelLabelFormat = "m";
            this.chartControl1.Size = new System.Drawing.Size(700, 541);
            this.chartControl1.TabIndex = 2;
            this.chartControl1.Text = "Students Admission Statistics - Pie Chart";
            // 
            // 
            // 
            this.chartControl1.Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Title.Margin = 2;
            this.chartControl1.Title.Name = "Def_title";
            this.chartControl1.Title.Text = "Students Admission Statistics - Pie Chart";
            this.chartControl1.Titles.Add(this.chartControl1.Title);
            this.chartControl1.ZoomOutIncrement = 1.5D;
            this.chartControl1.ChartAreaPaint += new System.Windows.Forms.PaintEventHandler(this.chartControl1_ChartAreaPaint);
            // 
            // designerPanel1
            // 
            this.designerPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.designerPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.designerPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, new System.Drawing.Color[] {
            System.Drawing.Color.Transparent,
            System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(242))))),
            System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(243))))),
            System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(239)))), ((int)(((byte)(245))))),
            System.Drawing.Color.Transparent});
            this.designerPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.designerPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.designerPanel1.Controls.Add(this.label5);
            this.designerPanel1.Controls.Add(this.label4);
            this.designerPanel1.Controls.Add(this.label3);
            this.designerPanel1.Controls.Add(this.label2);
            this.designerPanel1.Controls.Add(this.label1);
            this.designerPanel1.Controls.Add(this.buttonAdv1);
            this.designerPanel1.Controls.Add(this.buttonAdv4);
            this.designerPanel1.Controls.Add(this.checkBox1);
            this.designerPanel1.Controls.Add(this.buttonAdv3);
            this.designerPanel1.Controls.Add(this.buttonAdv2);
            this.designerPanel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designerPanel1.ForeColor = System.Drawing.Color.Black;
            this.designerPanel1.HeaderImage = null;
            this.designerPanel1.HeaderText = "";
            this.designerPanel1.Location = new System.Drawing.Point(718, 1);
            this.designerPanel1.Name = "designerPanel1";
            this.designerPanel1.Size = new System.Drawing.Size(244, 586);
            this.designerPanel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label5.Location = new System.Drawing.Point(136, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pyramid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label4.Location = new System.Drawing.Point(33, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Funnel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label3.Location = new System.Drawing.Point(136, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Doughnut";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label2.Location = new System.Drawing.Point(47, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart Type";
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv1.BackColor = System.Drawing.Color.White;
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(76, 76);
            this.buttonAdv1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv1.ForeColor = System.Drawing.Color.White;
            this.buttonAdv1.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdv1.Image")));
            this.buttonAdv1.IsBackStageButton = false;
            this.buttonAdv1.Location = new System.Drawing.Point(25, 120);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(76, 76);
            this.buttonAdv1.TabIndex = 1;
            this.buttonAdv1.Text = "Pie";
            this.buttonAdv1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdv1.UseVisualStyle = true;
            this.buttonAdv1.Click += new System.EventHandler(this.buttonAdv_Click);
            // 
            // buttonAdv4
            // 
            this.buttonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv4.BackColor = System.Drawing.Color.White;
            this.buttonAdv4.BeforeTouchSize = new System.Drawing.Size(76, 76);
            this.buttonAdv4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv4.ForeColor = System.Drawing.Color.White;
            this.buttonAdv4.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdv4.Image")));
            this.buttonAdv4.IsBackStageButton = false;
            this.buttonAdv4.Location = new System.Drawing.Point(140, 120);
            this.buttonAdv4.Name = "buttonAdv4";
            this.buttonAdv4.Size = new System.Drawing.Size(76, 76);
            this.buttonAdv4.TabIndex = 4;
            this.buttonAdv4.Text = "Doughnut";
            this.buttonAdv4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdv4.UseVisualStyle = true;
            this.buttonAdv4.Click += new System.EventHandler(this.buttonAdv_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.checkBox1.Location = new System.Drawing.Point(26, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 25);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Enable 3D";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonAdv3
            // 
            this.buttonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv3.BackColor = System.Drawing.Color.White;
            this.buttonAdv3.BeforeTouchSize = new System.Drawing.Size(76, 76);
            this.buttonAdv3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv3.ForeColor = System.Drawing.Color.White;
            this.buttonAdv3.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdv3.Image")));
            this.buttonAdv3.IsBackStageButton = false;
            this.buttonAdv3.Location = new System.Drawing.Point(140, 252);
            this.buttonAdv3.Name = "buttonAdv3";
            this.buttonAdv3.Size = new System.Drawing.Size(76, 76);
            this.buttonAdv3.TabIndex = 3;
            this.buttonAdv3.Text = "Pyramid";
            this.buttonAdv3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdv3.UseVisualStyle = true;
            this.buttonAdv3.Click += new System.EventHandler(this.buttonAdv_Click);
            // 
            // buttonAdv2
            // 
            this.buttonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv2.BackColor = System.Drawing.Color.White;
            this.buttonAdv2.BeforeTouchSize = new System.Drawing.Size(76, 76);
            this.buttonAdv2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv2.ForeColor = System.Drawing.Color.White;
            this.buttonAdv2.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdv2.Image")));
            this.buttonAdv2.IsBackStageButton = false;
            this.buttonAdv2.Location = new System.Drawing.Point(25, 252);
            this.buttonAdv2.Name = "buttonAdv2";
            this.buttonAdv2.Size = new System.Drawing.Size(76, 76);
            this.buttonAdv2.TabIndex = 2;
            this.buttonAdv2.Text = "Funnel";
            this.buttonAdv2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdv2.UseVisualStyle = true;
            this.buttonAdv2.Click += new System.EventHandler(this.buttonAdv_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 584);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.designerPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(767, 590);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart Divide Area";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.designerPanel1)).EndInit();
            this.designerPanel1.ResumeLayout(false);
            this.designerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Form Load
        private void FormMain_Load(object sender, System.EventArgs e)
        {
            InitializeChartData();
            ChartAppearance.ApplyChartStyles(this.chartControl1);
        }
        #endregion

        #region InitializeChartData
        /// <summary>
        /// Initializes the ChartControl's data and sets the Chart type
        /// </summary>
        protected void InitializeChartData()
        {
         
            ChartSeries series1 = new ChartSeries();
            series1.Name = "Year 2004";
            series1.Text = series1.Name;     
            series1.Points.Add(0, 10);
            //series1.Points.Add(1, 2);
            series1.Points.Add(2, 8);
            series1.Points.Add(3, 11);
            series1.Points.Add(4, 23);
            series1.Points.Add(5, 24);
            series1.Points.Add(6, 10);
            series1.Points.Add(7, 24);
            SeriesSettings(series1);
            this.chartControl1.Series.Add(series1);
            series1.ConfigItems.PieItem.ShowSeriesTitle = true;
            series1.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Inside;
           

            ChartSeries series2 = new ChartSeries();
            series2.Name = "Year 2005";
            series2.Text = series2.Name;
            series2.Points.Add(0, 12);
            series2.Points.Add(2, 11);
            series2.Points.Add(3, 8);
            series2.Points.Add(4, 25);
            series2.Points.Add(5, 22);
            series2.Points.Add(6, 13);
            series2.Points.Add(7, 22);
            SeriesSettings(series2);
            this.chartControl1.Series.Add(series2);
            series2.ConfigItems.PieItem.ShowSeriesTitle = true;
            series2.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Inside;

            this.chartControl1.ChartArea.DivideArea = true;
            ChartLegend chartLegend = new ChartLegend();
            chartLegend.Name = "Legend 1";
            string[] label = new string[] { "Engineering", "Medical Sciences", "BioTechnology", "Information Services", "Art and Humanities", "Geography", "Economics" };
            List<ChartLegendItem> items = new List<ChartLegendItem>();
            for (int i = 0; i < 7; i++)
            {
                ChartLegendItem legendItem = new ChartLegendItem(label[i]);
                legendItem.Font = new Font("Segoe UI", 10F);
                legendItem.RepresentationSize = new Size(15, 15);
                legendItem.TextColor = Color.Black;
                legendItem.Border.Color = Color.Transparent;
                items.Add(legendItem);
            }
            chartControl1.Legend.RepresentationType = ChartLegendRepresentationType.SeriesType;

            chartControl1.Legend.CustomItems = items.ToArray();
            chartControl1.Legend.RowsCount = 2;
            this.chartControl1.LegendAlignment = ChartAlignment.Center;
            this.chartControl1.LegendPosition = ChartDock.Bottom;
            this.chartControl1.LegendsPlacement = ChartPlacement.Outside;
             this.chartControl1.LegendsPlacement = ChartPlacement.Outside;
            this.chartControl1.ShowLegend = true;
            this.chartControl1.SmoothingMode = SmoothingMode.AntiAlias;
            

        }

        protected void SeriesSettings(ChartSeries series)
        {
            ChartSeries newSeries = series;
            newSeries.Style.DisplayText = true;
            newSeries.Type = ChartSeriesType.Pie;
            newSeries.LegendName = "Legend 1";
            newSeries.PrepareStyle += new ChartPrepareStyleInfoHandler(series1_PrepareStyle);

            for (int i = 0; i < 7; i++)
            {
                series.Styles[i].Font.Size = 8f;
                series.Styles[i].TextFormat = string.Format("{0}%", series.Points[i].YValues[0]);
            }
        }
        #endregion

        #region Events
        #region Series_PrepareStyle
        /// <summary>
        /// Handler for the PrepareStyle event of ChartSeries. 
        /// </summary>
        /// <param name="sender">The ChartSeries object that raises this event.</param>
        /// <param name="args">The event data. Can be modified to change series appearance.</param>
        void series1_PrepareStyle(object sender, ChartPrepareStyleInfoEventArgs args)
        {
            ChartSeries series = sender as ChartSeries;
            series.Style.Border.Color = Color.Transparent;
            series.ConfigItems.PieItem.PieType = ChartPieType.None;
            if (series != null)
            {   color1 = new Color[] { Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2) };
                color2 = new Color[] { Color.FromArgb(0xFF, 0xA0, 0x50, 0x00) };
                color3 = new Color[] { Color.FromArgb(0xFF, 0x33, 0x99, 0x33) };
                color4 = new Color[] { Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39) };
                color5 = new Color[] { Color.FromArgb(0xFF, 0xD8, 0x00, 0x73) };
                color6 = new Color[] { Color.FromArgb(0xFF, 0xF0, 0x96, 0x09) };
                color7 = new Color[] { Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8) };
                color8 = new Color[] { Color.FromArgb(0xFF, 0xA2, 0x00, 0xFF) };

                if (args.Index == 0)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color1);
                    this.chartControl1.Legend.Items[0].Interior = new BrushInfo(GradientStyle.None, color1);
                    if(chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else if (args.Index == 1)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color2);
                    this.chartControl1.Legend.Items[1].Interior = new BrushInfo(GradientStyle.None, color2);
                    if (chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else if (args.Index == 2)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color6);
                    this.chartControl1.Legend.Items[2].Interior = new BrushInfo(GradientStyle.None, color6);
                    if (chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else if (args.Index == 3)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color4);
                    this.chartControl1.Legend.Items[3].Interior = new BrushInfo(GradientStyle.None, color4);
                    if (chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else if (args.Index == 4)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color5);
                    this.chartControl1.Legend.Items[4].Interior = new BrushInfo(GradientStyle.None, color5);
                    if (chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else if (args.Index == 5)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color3);
                    this.chartControl1.Legend.Items[5].Interior = new BrushInfo(GradientStyle.None, color3);
                    if (chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else if (args.Index == 6)
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color7);
                    this.chartControl1.Legend.Items[6].Interior = new BrushInfo(GradientStyle.None, color7);
                    if (chartControl1.Series[0].Type != ChartSeriesType.Funnel && chartControl1.Series[0].Type != ChartSeriesType.Pyramid)
                    args.Style.TextColor = Color.White;
                }
                else
                {
                    args.Style.Interior = new BrushInfo(GradientStyle.None, color1);
                }
            }
        }
        Rectangle rectY;
        private void chartControl1_ChartAreaPaint(object sender, PaintEventArgs e)
        {
            foreach (ChartSeries series in this.chartControl1.Series)
            {
                RectangleF rectX = this.chartControl1.ChartArea.GetSeriesBounds(series);
                rectY = new Rectangle(Convert.ToInt16(rectX.X), Convert.ToInt16(rectX.Y), Convert.ToInt16(rectX.Width), Convert.ToInt16(rectX.Height));

                e.Graphics.DrawRectangle(new Pen(Color.DimGray, 1), rectY);
            }
        }

        #endregion

        private void buttonAdv_Click(object sender, EventArgs e)
        {
            ButtonAdv buttonAdv = sender as ButtonAdv;
            if (buttonAdv.Text == "Pie")
            {
                foreach (ChartSeries series in this.chartControl1.Series)
                {
                    series.Type = ChartSeriesType.Pie;
                    series.ConfigItems.PieItem.ShowSeriesTitle = true;
                    series.ConfigItems.PieItem.DoughnutCoeficient = 0;
                    series.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Inside;
                    this.chartControl1.Text = "Students Admission Statistics - Pie Chart";
                }
            }
            else if (buttonAdv.Text == "Doughnut")
            {
                foreach (ChartSeries series in this.chartControl1.Series)
                {
                    series.Type = ChartSeriesType.Pie;
                    series.ConfigItems.PieItem.DoughnutCoeficient = 0.5f;
                    series.ConfigItems.PieItem.ShowSeriesTitle = true;
                    series.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Inside; ;
                    this.chartControl1.Text = "Students Admission Statistics - Doughnut Chart";
                }
            }
            else if (buttonAdv.Text == "Funnel")
            {
                foreach (ChartSeries series in this.chartControl1.Series)
                {
                    series.Type = ChartSeriesType.Funnel;
                    series.ConfigItems.FunnelItem.ShowSeriesTitle = true;
                    series.ConfigItems.FunnelItem.LabelStyle = ChartAccumulationLabelStyle.OutsideInArea;
                    series.ConfigItems.FunnelItem.FigureBase = ChartFigureBase.Square;
                    this.chartControl1.Text = "Students Admission Statistics - Funnel Chart";
                }
            }
            else if (buttonAdv.Text == "Pyramid")
            {
                foreach (ChartSeries series in this.chartControl1.Series)
                {
                    series.Type = ChartSeriesType.Pyramid;
                    series.ConfigItems.PyramidItem.ShowSeriesTitle = true;
                    series.ConfigItems.PyramidItem.LabelStyle = ChartAccumulationLabelStyle.OutsideInArea;
                    series.ConfigItems.PyramidItem.FigureBase = ChartFigureBase.Square;
                    this.chartControl1.Text = "Students Admission Statistics - Pyramid Chart";
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.chartControl1.Series3D = checkBox1.Checked;
        }

        
       
        #endregion
    }
}