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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
using Syncfusion.Windows.Forms;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Chart;

namespace ChartImportData
{
	public class Form1 : MetroForm
    {
        #region Private Members
        private DateTime lastTime = DateTime.Now;
        private ChartControl chartControl1;
		private System.ComponentModel.Container components = null;
        #endregion

        #region Form's Constructor, Main And Dispose
        public Form1()
		{
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
            Application.EnableVisualStyles();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.White, System.Drawing.Color.White);
            this.chartControl1.BorderAppearance.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(113)))), ((int)(((byte)(173)))));
            this.chartControl1.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.Pinned;
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.DataSourceName = "";
            this.chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl1.Legend.Location = new System.Drawing.Point(748, 110);
            this.chartControl1.Localize = null;
            this.chartControl1.Location = new System.Drawing.Point(10, 7);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PrimaryXAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryXAxis.Margin = true;
            this.chartControl1.PrimaryYAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryYAxis.ForceZero = true;
            this.chartControl1.PrimaryYAxis.Margin = true;
            this.chartControl1.Rotation = 40F;
            this.chartControl1.Size = new System.Drawing.Size(892, 564);
            this.chartControl1.TabIndex = 5;
            this.chartControl1.Text = "chartControl1";
            // 
            // 
            // 
            this.chartControl1.Title.Name = "Default";
            this.chartControl1.Titles.Add(this.chartControl1.Title);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 581);
            this.Controls.Add(this.chartControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(543, 488);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data from an Array";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}
		#endregion

        #region Form Load
		private void Form1_Load(object sender, System.EventArgs e)
		{
            InitializeChartFromArray();
            ChartAppearance.ApplyChartStyles(this.chartControl1);
            //Updates the datagrid.
            FillDataset(this.chartControl1.Series[0]);
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
  | System.Windows.Forms.AnchorStyles.Left)
  | System.Windows.Forms.AnchorStyles.Right)));
            
   
    	}	
	    #endregion

        #region Helper Methods
        #region InitializeChartFromArray
        /// <summary>
		/// Initializes chart data from array.
		/// </summary>
        protected void InitializeChartFromArray()
        {
            //Initializes new chart series.
            ChartSeries series = new ChartSeries();
            series.Type = ChartSeriesType.Pie;
            string[] names = { "New York", "Houston", "Tokyo", "London", "Los Angeles" };
            double[] values = { 13, 11, 17, 15, 14 };
            //Turns on the text display.
            series.Style.DisplayText = true;

            for (int i = 0; i < values.Length; i++)
            {
                series.Points.Add(i, values[i]);
                series.Styles[i].Text = names[i].ToString();
            }

            //Adds the series to the ChartSeriesCollection.
            this.chartControl1.Series.Add(series);
            series.PrepareStyle += new ChartPrepareStyleInfoHandler(series_PrepareStyle);
            this.chartControl1.Series[0].ConfigItems.PieItem.AngleOffset = 13;

            //Turns off the legend.
            this.chartControl1.Legend.Visible = false;
            this.chartControl1.Text = "Highest populated cities in the world";
         
        }
        #endregion     
		
        #region FillDataset
        /// <summary>
        /// Fills the dataset with the chart series.
        /// </summary>
        /// <param name="serie"></param>
        protected void FillDataset(ChartSeries serie)
        {
            //Creates data table
            DataTable dt = new DataTable("Data Table");

            //Initializes and adds the datarow to the table.
            DataRow dr;
            for (int i = 0; i < serie.Points.Count; i++)
            {
                dr = dt.NewRow();
                dt.Rows.Add(dr);
            }

            //Initializes and adds the datacolumn to the table.
            DataColumn XValue = dt.Columns.Add("X Value", typeof(string));
            DataColumn YValue = dt.Columns.Add("Y Value", typeof(int));

            //Populate the datatable with the series points.
            for (int i = 0; i < serie.Points.Count; i++)
            {
                dt.Rows[i]["X Value"] = serie.Styles[i].Text;                
                dt.Rows[i]["Y Value"] = serie.Points[i].YValues[0];
            }

            //Creates a new dataset.
            DataSet arrayDataSet = new DataSet("Data DataSet");

            //Add the populated datatable to the dataset.
            arrayDataSet.Tables.Add(dt);

           
        }
        #endregion
        #endregion

        #region Series_PrepareStyle Event
        void series_PrepareStyle(object sender, ChartPrepareStyleInfoEventArgs args)
		{
			ChartSeries series = sender as ChartSeries;
			series.ConfigItems.PieItem.PieType=ChartPieType.OutSide;
            series.ConfigItems.PieItem.LabelStyle = ChartAccumulationLabelStyle.Inside;
            series.Style.TextColor = Color.White;
		}
        #endregion
       
     }
}