﻿#region Copyright Syncfusion Inc. 2001 - 2006
//
//  Copyright Syncfusion Inc. 2001 - 2006. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms;

namespace VirtualGridControlPerf
{
	/// <summary>
	/// Summary description for VirtualGridControlForm.
	/// </summary>
	public class VirtualGridControlForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel gridPanel;
		private GridControl grid;
        private Syncfusion.Windows.Forms.ButtonAdv btnInitGrid;
		private DataTable table;

		int randomKey = 100;
		int zipCount = 100;
		int recordCount = 20000;
		bool calculateMaxColumnWidth = false;
		bool useDataTableList = false;
		bool useOptimizedListChangedEvent = true;
		bool optimizeScrolling = true;
		int batchSize = 50;
		int repeatCount = 300;
		string[] states = new string[]{"North Carolina", "South Carolina", "Washington", "Nevada", "Ohio"};
        private Syncfusion.Windows.Forms.ButtonAdv btnResetGrid;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label labelRecordCount;
		private System.Windows.Forms.Label labelZipCount;
		private System.Windows.Forms.CheckBox checkBoxCalculateMaximumWidth;
		private System.Windows.Forms.CheckBox checkBoxUseDataViewSort;
		private System.Windows.Forms.TextBox textBoxRecordCount;
		private System.Windows.Forms.TextBox textBoxZipCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxRepeatCount;
        private Syncfusion.Windows.Forms.ButtonAdv buttonInsertRecords;
        private Syncfusion.Windows.Forms.ButtonAdv buttonRemoveRecords;
		private System.Windows.Forms.CheckBox checkBoxUseOptimizedListChangedEvent;
		private System.Windows.Forms.CheckBox checkBoxUseScrollWindow;
		private System.Windows.Forms.GroupBox grpInitializeTable;
		private System.Windows.Forms.GroupBox grpgroupBox1;
		private System.Windows.Forms.Label lbllabel2;
		private System.Windows.Forms.TextBox txtBatchSize;
        private Syncfusion.Windows.Forms.ButtonAdv buttonChangeRecords;
		private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnChangeNames;
        private Hashtable hashTable;
		
		public VirtualGridControlForm()
		{
			InitializeComponent();
            this.BackColor = Color.FromArgb(223, 227, 239);
            this.StartPosition = FormStartPosition.CenterParent;
			System.Drawing.Icon ico = new System.Drawing.Icon(GetIconFile(@"common\Images\Grid\Icon\sfgrid.ico"));
			this.Icon = ico ;	

			this.textBoxRepeatCount.Text = repeatCount.ToString();
			this.textBoxRecordCount.Text = recordCount.ToString();
			this.textBoxZipCount.Text = zipCount.ToString();
			this.checkBoxUseDataViewSort.Checked = this.useDataTableList;
			this.checkBoxCalculateMaximumWidth.Checked = this.calculateMaxColumnWidth;
			checkBoxUseOptimizedListChangedEvent.Checked = this.useOptimizedListChangedEvent;
			this.txtBatchSize.Text = this.batchSize.ToString();
			checkBoxUseScrollWindow.Checked = optimizeScrolling;
            this.hashTable = new Hashtable();
			InitializeDataTable();
		}

        void grid_RowHeightsChanged(object sender, GridRowColSizeChangedEventArgs e)
        {
            this.grid.BeginUpdate();
            this.grid.UpdateStyles();
            this.grid.EndUpdate(true);
        }
		
		private string GetIconFile(string bitmapName)
        {
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(bitmapName))
                    return bitmapName;

                bitmapName = @"..\" + bitmapName;
            }

            return bitmapName;
        }


		private void grid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
		{
			if(e.ColIndex > 0 && e.RowIndex > 0)
			{
				e.Style.CellValue = this.table.Rows[e.RowIndex-1][e.ColIndex-1];
				e.Handled = true;
			}
		}

		private void grid_QueryColCount(object sender, GridRowColCountEventArgs e)
		{
			e.Count = this.table.Columns.Count;
			e.Handled = true;
		}

		private void grid_QueryRowCount(object sender, GridRowColCountEventArgs e)
		{
			e.Count = this.table.Rows.Count;
			e.Handled = true;
		}

		private void grid_SaveCellInfo(object sender, GridSaveCellInfoEventArgs e)
		{
			if(e.ColIndex > 0 && e.RowIndex > 0)
			{
				this.table.Rows[e.RowIndex-1][e.ColIndex-1] = e.Style.CellValue;
				e.Handled = true;
			}
		}

        void grid_SaveColWidth(object sender, GridRowColSizeEventArgs e)
        {
            if (e.Index > 0)
            {
                hashTable[e.Index] = e.Size;
                e.Handled = true;
            }
            grid.Refresh();
        }

        void grid_QueryColWidth(object sender, GridRowColSizeEventArgs e)
        {
            if (e.Index > 0)
            {
                e.Size = int.Parse(hashTable[e.Index].ToString());
                e.Handled = true;
            }
        }

		private void InitializeDataTable()
		{
			Random random = new Random(randomKey++);
			int numStates = states.GetLength(0);
			string nameFormat = "Name{0:00000}";

			this.table = new DataTable("Test");

			DataColumn col = table.Columns.Add();
			col.DataType = typeof(string);
			col.ColumnName = "Name";

			col = table.Columns.Add();
			col.DataType = typeof(string);
			col.ColumnName = "State";

			col = table.Columns.Add();
			col.DataType = typeof(int);
			col.ColumnName = "Zip";

			for(int i = 0; i < recordCount; i++)
			{
				DataRow row = this.table.NewRow();
				row["Name"] = string.Format(nameFormat, i);
				row["State"] = states[random.Next(numStates-1)];
				row["Zip"] = random.Next(zipCount);
				this.table.Rows.Add(row);
			}

			this.table.DefaultView.RowStateFilter = DataViewRowState.CurrentRows;
		}

		void ResetGrid()
		{
			if (this.grid != null)
			{
				this.gridPanel.Controls.Remove(this.grid);
				this.table.Disposed += new EventHandler(table_Disposed);
				this.table.DefaultView.Disposed += new EventHandler(table_Disposed);
				this.grid.Dispose();
				this.grid = null;
				this.LogMemoryUsage();
			}
		}

		void LogMemoryUsage()
		{
			if (grid != null)
			{
				this.textBox1.Text += String.Format("Total Row Count {0}\r\n", this.table.Rows.Count);
			}
			// Force garbage collection and get used memory size
			GC.Collect();
			System.Threading.Thread.Sleep(randomKey++);
			Process myProcess = Process.GetCurrentProcess();
#if SyncfusionFramework2_0
            double workingSetSizeinKiloBytes = myProcess.WorkingSet64 / 1000;
#else
            double workingSetSizeinKiloBytes = myProcess.WorkingSet / 1000;
#endif
			string s = "Process's physical memory usage: " + workingSetSizeinKiloBytes.ToString() + " kb \r\n";
			this.textBox1.Text += s;
			ScrollTextBox();
		}

		void ScrollTextBox()
		{
			this.textBox1.SelectionStart = this.textBox1.Text.Length;
			this.textBox1.ScrollBars = ScrollBars.Vertical;
			this.textBox1.ScrollToCaret();
			this.textBox1.Focus();
		}

		private void InitializeGrid()
		{
			if (this.grid != null)
			{
				this.grid.QueryCellInfo -= new GridQueryCellInfoEventHandler(grid_QueryCellInfo);
				this.grid.QueryColCount -= new GridRowColCountEventHandler(grid_QueryColCount);
				this.grid.QueryRowCount -= new GridRowColCountEventHandler(grid_QueryRowCount);
				this.grid.SaveCellInfo -= new GridSaveCellInfoEventHandler(grid_SaveCellInfo);
                this.grid.QueryColWidth -= new GridRowColSizeEventHandler(grid_QueryColWidth);
                this.grid.SaveColWidth -= new GridRowColSizeEventHandler(grid_SaveColWidth);
                this.grid.RowHeightsChanged -= new GridRowColSizeChangedEventHandler(grid_RowHeightsChanged);
				this.grid.Dispose();
			}

			DateTime dtStart = DateTime.Now;

			Cursor.Current = Cursors.WaitCursor;

			// Fill DataTable
			InitializeDataTable();

			DateTime dtFill = DateTime.Now;

			// Show an empty grid - triggers JIT compilation when run first time
			this.grid = new GridControl();
						
			this.grid.Dock = DockStyle.Fill;
			this.grid.VerticalThumbTrack = true;
            this.grid.ThemesEnabled = true;
            this.grid.GridVisualStyles = GridVisualStyles.Office2007Blue;
            this.grid.DefaultGridBorderStyle = GridBorderStyle.Solid;
            this.grid.Properties.GridLineColor = Color.FromArgb(208, 215, 229);
            GridStyleInfo style = grid.BaseStylesMap["Header"].StyleInfo;
            style.TextColor = Color.MidnightBlue;
            style.Font.Facename = "Verdana";
            this.grid.Properties.BackgroundColor = SystemColors.Window;

            this.grid.DefaultColWidth = 70;
            this.grid.DefaultRowHeight = 18;

			hashTable.Clear();
            for (int col = 0; col < table.Columns.Count; col++)
                hashTable.Add(col + 1, this.grid.ColWidths[col]);		

			// DataView has performance issues when inserting new records into a large
			// dataset. Instead of getting the DataTable.DefaultView, the engine
			// can wrap the data table with a more efficient DataTableList class. 
			// This allows instantenoues inserts for DataTable with > 100000 records.
			
			DateTime dtCount = DateTime.Now;
			this.grid.BeginUpdate();
			this.gridPanel.Controls.Add(this.grid);
			this.grid.ResetVolatileData();
			this.grid.Update();

			
			this.grid.QueryCellInfo += new GridQueryCellInfoEventHandler(grid_QueryCellInfo);
			this.grid.QueryColCount += new GridRowColCountEventHandler(grid_QueryColCount);
			this.grid.QueryRowCount += new GridRowColCountEventHandler(grid_QueryRowCount);
			this.grid.SaveCellInfo += new GridSaveCellInfoEventHandler(grid_SaveCellInfo);
            this.grid.QueryColWidth += new GridRowColSizeEventHandler(grid_QueryColWidth);
            this.grid.SaveColWidth += new GridRowColSizeEventHandler(grid_SaveColWidth);
            this.grid.RowHeightsChanged += new GridRowColSizeChangedEventHandler(grid_RowHeightsChanged);
			
			this.grid.DefaultGridBorderStyle = GridBorderStyle.Solid;
			this.grid.Properties.GridLineColor = System.Drawing.Color.Silver;

			// paint the grid.
			//this.gridPanel.Controls.Add(this.grid);
			//this.grid.Update();
			this.grid.Refresh();

			Cursor.Current = Cursors.Default;

			DateTime dtPaint = DateTime.Now;

			string settings = String.Format("DataTableList={0}", useDataTableList);
			string time1 = String.Format("Fill Datatable: {0}\r\n", dtFill-dtStart);
			string time3 = String.Format("Set data source and categorize: {0}\r\n", dtCount-dtFill);
			string time4 = String.Format("Repaint: {0}\r\n", dtPaint-dtCount);
			string time6 = String.Format("Total time: {0}\r\n", dtPaint-dtStart);

			this.textBox1.Text += "\r\n\r\n" + settings + time1 + time3 + time4 + time6;
			this.LogMemoryUsage();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gridPanel = new System.Windows.Forms.Panel();
            this.btnInitGrid = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnResetGrid = new Syncfusion.Windows.Forms.ButtonAdv();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelRecordCount = new System.Windows.Forms.Label();
            this.labelZipCount = new System.Windows.Forms.Label();
            this.checkBoxCalculateMaximumWidth = new System.Windows.Forms.CheckBox();
            this.checkBoxUseDataViewSort = new System.Windows.Forms.CheckBox();
            this.textBoxRecordCount = new System.Windows.Forms.TextBox();
            this.textBoxZipCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRepeatCount = new System.Windows.Forms.TextBox();
            this.buttonInsertRecords = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonRemoveRecords = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonChangeRecords = new Syncfusion.Windows.Forms.ButtonAdv();
            this.checkBoxUseOptimizedListChangedEvent = new System.Windows.Forms.CheckBox();
            this.checkBoxUseScrollWindow = new System.Windows.Forms.CheckBox();
            this.grpInitializeTable = new System.Windows.Forms.GroupBox();
            this.grpgroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangeNames = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.lbllabel2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpInitializeTable.SuspendLayout();
            this.grpgroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Location = new System.Drawing.Point(16, 16);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(544, 352);
            this.gridPanel.TabIndex = 0;
            // 
            // btnInitGrid
            // 
            this.btnInitGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInitGrid.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnInitGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitGrid.Location = new System.Drawing.Point(27, 214);
            this.btnInitGrid.Name = "btnInitGrid";
            this.btnInitGrid.Size = new System.Drawing.Size(72, 24);
            this.btnInitGrid.TabIndex = 1;
            this.btnInitGrid.TabStop = false;
            this.btnInitGrid.Text = "Load Grid";
            this.btnInitGrid.UseVisualStyle = true;
            this.btnInitGrid.Click += new System.EventHandler(this.btnInitGrid_Click);
            // 
            // btnResetGrid
            // 
            this.btnResetGrid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnResetGrid.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnResetGrid.Location = new System.Drawing.Point(680, 230);
            this.btnResetGrid.Name = "btnResetGrid";
            this.btnResetGrid.Size = new System.Drawing.Size(72, 24);
            this.btnResetGrid.TabIndex = 1;
            this.btnResetGrid.TabStop = false;
            this.btnResetGrid.Text = "Reset Grid";
            this.btnResetGrid.UseVisualStyle = true;
            this.btnResetGrid.Click += new System.EventHandler(this.btnResetGrid_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(16, 384);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(544, 160);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Results:\r\n-----------";
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRecordCount.Location = new System.Drawing.Point(593, 54);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Size = new System.Drawing.Size(72, 23);
            this.labelRecordCount.TabIndex = 4;
            this.labelRecordCount.Text = "RecordCount";
            this.labelRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelZipCount
            // 
            this.labelZipCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelZipCount.Location = new System.Drawing.Point(594, 78);
            this.labelZipCount.Name = "labelZipCount";
            this.labelZipCount.Size = new System.Drawing.Size(56, 23);
            this.labelZipCount.TabIndex = 5;
            this.labelZipCount.Text = "Zip Count";
            this.labelZipCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxCalculateMaximumWidth
            // 
            this.checkBoxCalculateMaximumWidth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxCalculateMaximumWidth.Checked = true;
            this.checkBoxCalculateMaximumWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCalculateMaximumWidth.Enabled = false;
            this.checkBoxCalculateMaximumWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCalculateMaximumWidth.Location = new System.Drawing.Point(591, 152);
            this.checkBoxCalculateMaximumWidth.Name = "checkBoxCalculateMaximumWidth";
            this.checkBoxCalculateMaximumWidth.Size = new System.Drawing.Size(184, 24);
            this.checkBoxCalculateMaximumWidth.TabIndex = 3;
            this.checkBoxCalculateMaximumWidth.Text = "Use ResizeToFit on ColWidths";
            // 
            // checkBoxUseDataViewSort
            // 
            this.checkBoxUseDataViewSort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxUseDataViewSort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxUseDataViewSort.Location = new System.Drawing.Point(591, 176);
            this.checkBoxUseDataViewSort.Name = "checkBoxUseDataViewSort";
            this.checkBoxUseDataViewSort.Size = new System.Drawing.Size(160, 24);
            this.checkBoxUseDataViewSort.TabIndex = 4;
            this.checkBoxUseDataViewSort.Text = "Use DataTableList ";
            // 
            // textBoxRecordCount
            // 
            this.textBoxRecordCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxRecordCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRecordCount.Location = new System.Drawing.Point(680, 55);
            this.textBoxRecordCount.Name = "textBoxRecordCount";
            this.textBoxRecordCount.Size = new System.Drawing.Size(64, 20);
            this.textBoxRecordCount.TabIndex = 0;
            this.textBoxRecordCount.Text = "50000";
            // 
            // textBoxZipCount
            // 
            this.textBoxZipCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxZipCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxZipCount.Location = new System.Drawing.Point(680, 80);
            this.textBoxZipCount.Name = "textBoxZipCount";
            this.textBoxZipCount.Size = new System.Drawing.Size(64, 20);
            this.textBoxZipCount.TabIndex = 1;
            this.textBoxZipCount.Text = "1000";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.Location = new System.Drawing.Point(591, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Repeat Count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRepeatCount
            // 
            this.textBoxRepeatCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxRepeatCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRepeatCount.Location = new System.Drawing.Point(680, 317);
            this.textBoxRepeatCount.Name = "textBoxRepeatCount";
            this.textBoxRepeatCount.Size = new System.Drawing.Size(64, 20);
            this.textBoxRepeatCount.TabIndex = 6;
            this.textBoxRepeatCount.Text = "100";
            // 
            // buttonInsertRecords
            // 
            this.buttonInsertRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsertRecords.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.buttonInsertRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsertRecords.Location = new System.Drawing.Point(56, 168);
            this.buttonInsertRecords.Name = "buttonInsertRecords";
            this.buttonInsertRecords.Size = new System.Drawing.Size(104, 23);
            this.buttonInsertRecords.TabIndex = 12;
            this.buttonInsertRecords.TabStop = false;
            this.buttonInsertRecords.Text = "Insert Records";
            this.buttonInsertRecords.UseVisualStyle = true;
            this.buttonInsertRecords.Click += new System.EventHandler(this.buttonInsertRecords_Click);
            // 
            // buttonRemoveRecords
            // 
            this.buttonRemoveRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveRecords.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.buttonRemoveRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveRecords.Location = new System.Drawing.Point(56, 139);
            this.buttonRemoveRecords.Name = "buttonRemoveRecords";
            this.buttonRemoveRecords.Size = new System.Drawing.Size(104, 23);
            this.buttonRemoveRecords.TabIndex = 12;
            this.buttonRemoveRecords.TabStop = false;
            this.buttonRemoveRecords.Text = "Remove Records";
            this.buttonRemoveRecords.UseVisualStyle = true;
            this.buttonRemoveRecords.Click += new System.EventHandler(this.buttonRemoveRecords_Click);
            // 
            // buttonChangeRecords
            // 
            this.buttonChangeRecords.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.buttonChangeRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeRecords.Location = new System.Drawing.Point(56, 197);
            this.buttonChangeRecords.Name = "buttonChangeRecords";
            this.buttonChangeRecords.Size = new System.Drawing.Size(104, 23);
            this.buttonChangeRecords.TabIndex = 16;
            this.buttonChangeRecords.TabStop = false;
            this.buttonChangeRecords.Text = "Change Records";
            this.buttonChangeRecords.UseVisualStyle = true;
            this.buttonChangeRecords.Click += new System.EventHandler(this.buttonChangeRecords_Click);
            // 
            // checkBoxUseOptimizedListChangedEvent
            // 
            this.checkBoxUseOptimizedListChangedEvent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxUseOptimizedListChangedEvent.Checked = true;
            this.checkBoxUseOptimizedListChangedEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseOptimizedListChangedEvent.Enabled = false;
            this.checkBoxUseOptimizedListChangedEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxUseOptimizedListChangedEvent.Location = new System.Drawing.Point(591, 128);
            this.checkBoxUseOptimizedListChangedEvent.Name = "checkBoxUseOptimizedListChangedEvent";
            this.checkBoxUseOptimizedListChangedEvent.Size = new System.Drawing.Size(184, 24);
            this.checkBoxUseOptimizedListChangedEvent.TabIndex = 2;
            this.checkBoxUseOptimizedListChangedEvent.Text = "Use OptimzedListChangeEvent";
            // 
            // checkBoxUseScrollWindow
            // 
            this.checkBoxUseScrollWindow.Enabled = false;
            this.checkBoxUseScrollWindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxUseScrollWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseScrollWindow.Location = new System.Drawing.Point(18, 104);
            this.checkBoxUseScrollWindow.Name = "checkBoxUseScrollWindow";
            this.checkBoxUseScrollWindow.Size = new System.Drawing.Size(152, 16);
            this.checkBoxUseScrollWindow.TabIndex = 8;
            this.checkBoxUseScrollWindow.Text = "Use ScrollWindow";
            // 
            // grpInitializeTable
            // 
            this.grpInitializeTable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.grpInitializeTable.Controls.Add(this.btnInitGrid);
            this.grpInitializeTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInitializeTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInitializeTable.Location = new System.Drawing.Point(576, 16);
            this.grpInitializeTable.Name = "grpInitializeTable";
            this.grpInitializeTable.Size = new System.Drawing.Size(208, 256);
            this.grpInitializeTable.TabIndex = 14;
            this.grpInitializeTable.TabStop = false;
            this.grpInitializeTable.Text = "Initialize Table";
            // 
            // grpgroupBox1
            // 
            this.grpgroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.grpgroupBox1.Controls.Add(this.btnChangeNames);
            this.grpgroupBox1.Controls.Add(this.txtBatchSize);
            this.grpgroupBox1.Controls.Add(this.lbllabel2);
            this.grpgroupBox1.Controls.Add(this.checkBoxUseScrollWindow);
            this.grpgroupBox1.Controls.Add(this.buttonRemoveRecords);
            this.grpgroupBox1.Controls.Add(this.buttonChangeRecords);
            this.grpgroupBox1.Controls.Add(this.buttonInsertRecords);
            this.grpgroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpgroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpgroupBox1.Location = new System.Drawing.Point(576, 280);
            this.grpgroupBox1.Name = "grpgroupBox1";
            this.grpgroupBox1.Size = new System.Drawing.Size(208, 264);
            this.grpgroupBox1.TabIndex = 15;
            this.grpgroupBox1.TabStop = false;
            this.grpgroupBox1.Text = "Manipulate Grid";
            // 
            // btnChangeNames
            // 
            this.btnChangeNames.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnChangeNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeNames.Location = new System.Drawing.Point(56, 226);
            this.btnChangeNames.Name = "btnChangeNames";
            this.btnChangeNames.Size = new System.Drawing.Size(104, 23);
            this.btnChangeNames.TabIndex = 17;
            this.btnChangeNames.TabStop = false;
            this.btnChangeNames.Text = "Change Names";
            this.btnChangeNames.UseVisualStyle = true;
            this.btnChangeNames.Click += new System.EventHandler(this.btnChangeNames_Click);
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSize.Location = new System.Drawing.Point(104, 64);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(64, 20);
            this.txtBatchSize.TabIndex = 7;
            this.txtBatchSize.Text = "1";
            // 
            // lbllabel2
            // 
            this.lbllabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllabel2.Location = new System.Drawing.Point(15, 64);
            this.lbllabel2.Name = "lbllabel2";
            this.lbllabel2.Size = new System.Drawing.Size(72, 16);
            this.lbllabel2.TabIndex = 0;
            this.lbllabel2.Text = "Batch Size";
            this.lbllabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 566);
            this.panel1.TabIndex = 16;
            // 
            // VirtualGridControlForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.textBoxRepeatCount);
            this.Controls.Add(this.textBoxRecordCount);
            this.Controls.Add(this.checkBoxCalculateMaximumWidth);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxZipCount);
            this.Controls.Add(this.checkBoxUseOptimizedListChangedEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxUseDataViewSort);
            this.Controls.Add(this.labelZipCount);
            this.Controls.Add(this.labelRecordCount);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.btnResetGrid);
            this.Controls.Add(this.grpInitializeTable);
            this.Controls.Add(this.grpgroupBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "VirtualGridControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Grid Control Performance Demo";
            this.grpInitializeTable.ResumeLayout(false);
            this.grpgroupBox1.ResumeLayout(false);
            this.grpgroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		

		private void btnInitGrid_Click(object sender, System.EventArgs e)
		{

			this.useDataTableList = this.checkBoxUseDataViewSort.Checked;
            this.calculateMaxColumnWidth = this.checkBoxCalculateMaximumWidth.Checked;
			this.recordCount = Convert.ToInt32(this.textBoxRecordCount.Text);
			this.zipCount = Convert.ToInt32(this.textBoxZipCount.Text);
			this.useOptimizedListChangedEvent = checkBoxUseOptimizedListChangedEvent.Checked;

			this.InitializeGrid();
		}

		private void table_Disposed(object sender, EventArgs e)
		{
		}

		private void btnResetGrid_Click(object sender, System.EventArgs e)
		{
			this.ResetGrid();
		}

		private void buttonInsertRecords_Click(object sender, System.EventArgs e)
		{
			if (grid == null)
				return;

			repeatCount = Convert.ToInt32(this.textBoxRepeatCount.Text);
			batchSize = Convert.ToInt32(this.txtBatchSize.Text);
			optimizeScrolling = checkBoxUseScrollWindow.Checked;

			Cursor.Current = Cursors.WaitCursor;

			DateTime dtStart = DateTime.Now;

			Random random = new Random(randomKey++);
			int numStates = states.GetLength(0);
			string nameFormat = "Ins{0:00000}";

			
			for(int i = 0; i < repeatCount; i++)
			{
				DataRow row = this.table.NewRow();
				row["Name"] = string.Format(nameFormat, this.table.Rows.Count);
				row["State"] = states[random.Next(numStates-1)];
				row["Zip"] = random.Next(zipCount);
				this.table.Rows.Add(row);

				// Force immediate update of visible area and scrollbars after each operation
				// when grouped, record will automatically be inserted in the correct group
				// and sort order.
				if ((i+1) % batchSize == 0)
					grid.Update();
			}
			//this.grid.ResetVolatileData();
			//this.grid.Update();
			this.grid.Refresh();


			DateTime dtEnd = DateTime.Now;

			Cursor.Current = Cursors.Default;

			string time1 = String.Format("Inserted {0} Records: {1}\r\n", repeatCount, dtEnd-dtStart);
			this.textBox1.Text += "\r\n\r\n" + time1;
			this.LogMemoryUsage();
		}

		private void buttonRemoveRecords_Click(object sender, System.EventArgs e)
		{
			if (grid == null)
				return;

			repeatCount = Convert.ToInt32(this.textBoxRepeatCount.Text);
			batchSize = Convert.ToInt32(this.txtBatchSize.Text);
			optimizeScrolling = checkBoxUseScrollWindow.Checked;

			Cursor.Current = Cursors.WaitCursor;

			DateTime dtStart = DateTime.Now;

			Random random = new Random(randomKey++);


            try
            {
                for (int i = 0; i < repeatCount; i++)
                {
                    int record = random.Next(table.Rows.Count - 1);

                    this.table.Rows.RemoveAt(record);

                    if ((i + 1) % batchSize == 0)
                        grid.Update();

                    if (table.Rows.Count == 0)
                        break;
                }
                //this.grid.ResetVolatileData();
                //this.grid.Update();
                this.grid.Refresh();

                DateTime dtEnd = DateTime.Now;

                Cursor.Current = Cursors.Default;

                string time1 = String.Format("Removed {0} Records: {1}\r\n", repeatCount, dtEnd - dtStart);
                this.textBox1.Text += "\r\n\r\n" + time1;
                this.LogMemoryUsage();
            }
            catch
            {
                MessageBox.Show("No Records in the Table");
            }
		}

		private void btnChangeNames_Click(object sender, System.EventArgs e)
		{
			if (grid == null)
				return;

			repeatCount = Convert.ToInt32(this.textBoxRepeatCount.Text);
			batchSize = Convert.ToInt32(this.txtBatchSize.Text);
			optimizeScrolling = checkBoxUseScrollWindow.Checked;

			Cursor.Current = Cursors.WaitCursor;

			DateTime dtStart = DateTime.Now;

			Random random = new Random(randomKey++);
			string nameFormat = "Chg{0:00000}";
			int numStates = states.GetLength(0);


			for(int i = 0; i < repeatCount; i++)
			{
				int record = (int) Math.Min(table.Rows.Count-1, random.Next(table.Rows.Count));
				if (record >= 0)
				{
					DataRow row = this.table.Rows[record];
					row["Name"] = string.Format(nameFormat, i);
				}

				// Force immediate update of visible area and scrollbars after each operation
				// If grid is sorted by name, the record will be removed and reinserted at correct
				// sort position.
				if ((i+1) % batchSize == 0)
					grid.Update();
			}
			//this.grid.ResetVolatileData();
			//this.grid.Update();
			this.grid.Refresh();


			DateTime dtEnd = DateTime.Now;

			Cursor.Current = Cursors.Default;

			string time1 = String.Format("Changed {0} Records: {1}\r\n", repeatCount, dtEnd-dtStart);
			this.textBox1.Text += "\r\n\r\n" + time1;
			this.LogMemoryUsage();
		}

		private void buttonChangeRecords_Click(object sender, System.EventArgs e)
		{
			if (grid == null)
				return;

			repeatCount = Convert.ToInt32(this.textBoxRepeatCount.Text);
			batchSize = Convert.ToInt32(this.txtBatchSize.Text);
			optimizeScrolling = checkBoxUseScrollWindow.Checked;

			Cursor.Current = Cursors.WaitCursor;

			DateTime dtStart = DateTime.Now;

			Random random = new Random(randomKey++);
			string nameFormat = "Chg{0:00000}";
			int numStates = states.GetLength(0);


			for(int i = 0; i < repeatCount; i++)
			{
				int record = (int) Math.Min(table.Rows.Count-1, random.Next(table.Rows.Count));
				if (record >= 0)
				{
					DataRow row = this.table.Rows[record];
					row.BeginEdit();
					row["Name"] = string.Format(nameFormat, i);
					row["State"] = states[random.Next(numStates-1)];
					row["Zip"] = random.Next(zipCount);
					row.EndEdit();
				}

				// Force immediate update of visible area and scrollbars after each operation
				// If grid is sorted by name, the record will be removed and reinserted at correct
				// sort position.
				if ((i+1) % batchSize == 0)
					grid.Update();
			}
			//this.grid.ResetVolatileData();
			//this.grid.Update();
			this.grid.Refresh();

			DateTime dtEnd = DateTime.Now;

			Cursor.Current = Cursors.Default;

			string time1 = String.Format("Changed {0} Records: {1}\r\n", repeatCount, dtEnd-dtStart);
			this.textBox1.Text += "\r\n\r\n" + time1;
			this.LogMemoryUsage();		
		}

		


	}
}

