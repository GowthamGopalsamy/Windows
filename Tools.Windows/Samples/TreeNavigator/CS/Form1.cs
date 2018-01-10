#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace TreeNavigatorDemo
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            this.groupBar1.SelectedItem = 0;
            this.comboBoxAdv2.Text = this.treeNavigator1.NavigationMode.ToString();
            this.comboBoxAdv3.Text = this.treeNavigator1.TextAlign.ToString();
            this.checkBox2.CheckState = CheckState.Unchecked;
            this.checkBox1.CheckState = CheckState.Checked;
            this.treeNavigator1.SelectedItem = treeMenuItem1;
            this.treeNavigator1.Header.TextBounds = new Rectangle(80, 0, 0, 0);
            this.richTextBox1.Text = "Windows Forms";
            this.richTextBox3.Text = "Essential Studio for WindowsForms contains all the controls that you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents.";
            this.treeNavigator1.SelectionChanged += new SelectionStateChangedEventHandler(treeNavigator1_SelectionChanged);
            this.groupBar1.HeaderBackColor = ColorTranslator.FromHtml("#2D2E2D");
            this.colorPickerButton5.BackColor = this.treeNavigator1.Header.HeaderBackColor;
            this.colorPickerButton6.BackColor = this.treeNavigator1.Header.HeaderForeColor;
            this.CaptionImages[0].Size = new Size(this.CaptionImages[0].Size.Width, this.CaptionBarHeight+this.Icon.Height);
            try
            {
                System.Drawing.Icon ico = new System.Drawing.Icon(GetIconFile(@"common\Images\Grid\Icon\sfgrid.ico"));
                this.Icon = ico;
            }
            catch { }
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panel6.Paint += new PaintEventHandler(panel6_Paint);
            this.panel7.Height = 50;
            this.panel6.Location = new Point(this.panel6.Location.X, this.panel7.Height);
            this.panel5.Location = new Point(this.panel7.Width, this.panel5.Location.Y);
            this.richTextBox1.GotFocus += new EventHandler(richTextBox1_GotFocus);
            this.richTextBox3.GotFocus += new EventHandler(richTextBox1_GotFocus);
        }

        void richTextBox1_GotFocus(object sender, EventArgs e)
        {
            this.ActiveControl = (this.treeNavigator1.SelectedItem as TreeMenuItem).Parent;
        }

        void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel5.Bounds, Color.FromArgb(211, 211, 211), ButtonBorderStyle.Solid);
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.panel7.Height = 50;
            this.panel6.Location = new Point(this.panel6.Location.X, this.panel7.Height);
            this.panel5.Location = new Point(this.panel7.Width, this.panel5.Location.Y);
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

        void treeNavigator1_SelectionChanged(TreeNavigator sender, SelectionStateChangedEventArgs e)
        {
            TreeMenuItem tm = e.SelectedItem;
            switch (tm.Text)
            {
                case "Windows Forms":
                    this.richTextBox1.Text = "Windows Forms";
                    this.richTextBox3.Text = "Essential Studio for WindowsForms contains all the controls that you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents.";              
                    break;
                case "ASP.NET":
                    this.richTextBox1.Text = "ASP.NET";
                    this.richTextBox3.Text = "Excellent toolset and a great support team. I’ve been using Syncfusion’s products" +
    " for a couple of years, and they save me a lot of time on ASP/MVC development. ";
                    break;
                case "WinRT":
                    this.richTextBox1.Text = "WinRT";
                    this.richTextBox3.Text = "Essential Studio for WinRT contains all the controls you need to build line-of-business applications, including charts, gauges, maps, diagrams, and radial menus. It also includes a unique set of controls for reading and writing Excel, Word, and PDF documents in Windows store apps.";
                    break;
                case "WPF":
                    this.richTextBox1.Text = "WPF";
                    this.richTextBox3.Text = "Essential Studio for WPF contains all the controls that you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents.";
                    break;
                case "SilverLight":
                    this.richTextBox1.Text = "SilverLight";
                    this.richTextBox3.Text = "Essential Studio for Silverlight contains all the controls you need for building typical line-of-business web applications including grids, charts, gauges, menus, calendars, editors, and much more. It also includes some unique controls that enable your applications to read and write Excel, Word, and PDF documents.";
                    break;
                case "Windows Phone":
                    this.richTextBox1.Text = "Windows Phone";
                    this.richTextBox3.Text = "Essential Studio for Windows Phone 7 contains all the controls you need to build line-of-business mobile applications including charts, gauges, maps, editors, and much more.";
                    break;
                case "Orubase Studio":
                    this.richTextBox1.Text = "Orubase Studio";
                    this.richTextBox3.Text = "Essential Studio for Windows Phone 7 contains all the controls you need to build line-of-business mobile applications including charts, gauges, maps, editors, and much more.";
                    break;
                case "Metro Studio" :
                    this.richTextBox1.Text = "Metro Studio";
                    this.richTextBox3.Text = "Essential Studio for Windows Phone 7 contains all the controls you need to build line-of-business mobile applications including charts, gauges, maps, editors, and much more.";
                    break;
                case "Ribbon" :
                    this.richTextBox1.Text = "Ribbon";
                    this.richTextBox3.Text = "Our collection of Office 2007-style UI controls let you create Office-style menus, toolbars, window frames, etc. Bringing your application UI on par with industry standards and leaders has never been easier.";
                    break;
                case "TreeViewAdv" :
                    this.richTextBox1.Text = "TreeViewAdv";
                    this.richTextBox3.Text="The TreeViewAdv control provides all the advanced capabilities that are missing in the framework version. Advanced features such as multiple columns, drag-and-drop, multi-node selection, and inline editing support are also available. It also has a feature for adding images, and it contains the built-in ability to perform item sorting on a tree view.";
                    break;
                case "Diagram":
                    this.richTextBox1.Text = "Diagram";
                    this.richTextBox3.Text = "Essential Diagram for WindowsForms has the ability to present powerful and feature-rich diagrams. It provides an intuitive user-interaction model for creating and editing diagrams and data binding support. Its programmatic interface also places at your disposal many useful commands and methods that enable the performance of functionalities such as printing, data binding, serializing, and automatic layout algorithms. Virtualized rendering optimizes the rendering of large diagrams. It is fully localizable for any culture";
                    break;
                case "Gauge":
                    this.richTextBox1.Text = "Gauge";
                    this.richTextBox3.Text = "Essential Gauge allows the use of code to draw gauges of various designs. It comes with sophisticated support to provide endless possibilities for customization. With Essential Gauge, users can display several data points or data ranges in a concise and compact area. Data in the control can be easily depicted and quickly understood by users of any level";
                    break;
                case "XlsIO":
                    this.richTextBox1.Text = "XlsIO";
                    this.richTextBox3.Text = "Essential XlsIO is a .NET library that can read and write Microsoft Excel files. It features a full-fledged object model similar to the Microsoft Office Automation libraries. It can be used on systems that do not have Microsoft Excel installed, making it an excellent report engine for tabular data. Essential XlsIO enables users to create document-based reports in Windows Forms";
                    break;
                case "Chart":
                    this.richTextBox1.Text = "Chart";
                    this.richTextBox3.Text = "Essential Chart for WinRT is a high-performance, visually stunning charting component that is easy to use. It includes common chart types ranging from line charts to specialized financial charts. It incorporates DirectX rendering to deliver the best possible performance";
                    break;
                case "Maps":
                    this.richTextBox1.Text = "Maps";
                    this.richTextBox3.Text = "Essential Maps for WinRT is a powerful data-visualization control that can be used to articulate data as a map. It is frequently used in financial dashboards for plotting sales across geography";
                    break;
                case "Carousel":
                    this.richTextBox1.Text = "Carousel";
                    this.richTextBox3.Text = "The carousel arranges items in an album-cover browser similar to iTunes. This layout is optimized for browsing a list of items on a touch device. Simply swipe to reveal the next item in a list.";
                    break;
                case "GridData Control":
                    this.richTextBox1.Text = "GridDatControl";
                    this.richTextBox3.Text = "The GridData control for WPF is the most advanced data grid available in the market with unmatched performance and versatility. Its advanced feature set is exposed through a powerful yet easy-to-use API with countless customization options. You can easily get started data-binding the grid to any data source; format the data with a rich selection of cell types; and enable editing, sorting, filtering, and grouping within a few minutes. The seamless editing experience rivals that of Microsoft Excel itself. The GridData control has been designed especially for the WPF platform and makes use of all the nuances the platform has to offer. It is also MVVM compatible.";
                    break;
                case "Spreadsheet":
                    this.richTextBox1.Text = "Spreadsheet";
                    this.richTextBox3.Text = "Essential Spreadsheet is a control for viewing and editing Microsoft Excel files in a familiar Excel-like interface without Excel installed. It combines some of our most popular components like our Grid control, Ribbon control, formula engine, and others to create a first of its kind offering for WPF for viewing and editing Excel files.";
                    break;
                default:
                    this.richTextBox1.Text = tm.Text;
                    this.richTextBox3.Text = "Enterprise-Grade Applications in Less Time We can build web, mobile, and desktop applications better and faster than anyone because we build on top of our award-winning suite of components and frameworks, saving you time and money.";
                    break;
          }

        }
   
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel5.Bounds, Color.FromArgb(211, 211, 211), ButtonBorderStyle.Solid);
            base.OnPaint(e);
        }

               
        private void comboBoxAdv2_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBoxAdv2.SelectedItem.ToString())
            {
                case "Default":
                    this.treeNavigator1.NavigationMode = NavigationMode.Default;
                    break;
                case "Extended":
                    this.treeNavigator1.NavigationMode = NavigationMode.Extended;
                    break;
            }
        }

   

        private void comboBoxAdv3_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBoxAdv3.SelectedItem.ToString())
            {
                case "Left":
                    this.treeNavigator1.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Left;
                    break;
                case "Right":
                    this.treeNavigator1.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Right;
                    break;
                case "Center":
                    this.treeNavigator1.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Center;
                    break;

            }
        }

      //Customizes the header area

    
        private void colorPickerButton5_ColorSelected(object sender, EventArgs e)
        {
            this.treeNavigator1.Header.HeaderBackColor = colorPickerButton5.SelectedColor;
            this.colorPickerButton5.BackColor = colorPickerButton5.SelectedColor;
            this.Refresh();
        }

        private void colorPickerButton6_ColorSelected(object sender, EventArgs e)
        {
            this.treeNavigator1.Header.HeaderForeColor = colorPickerButton6.SelectedColor;
            this.Refresh();
            this.colorPickerButton6.BackColor = colorPickerButton6.SelectedColor;
        }

   

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.CheckState==CheckState.Checked)
                this.treeNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            else if(checkBox2.CheckState==CheckState.Unchecked)
                this.treeNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                this.treeNavigator1.ShowHeader = true;
            else if (checkBox1.CheckState == CheckState.Unchecked)
                this.treeNavigator1.ShowHeader = false;
        }

        private void colorPickerButton1_ColorSelected(object sender, EventArgs e)
        {
            this.treeNavigator1.ItemBackColor = colorPickerButton1.SelectedColor;
            this.colorPickerButton1.BackColor = colorPickerButton1.SelectedColor;
           // this.Refresh();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

       



    }
}
