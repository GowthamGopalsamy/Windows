#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Forms;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Forms.PdfViewer;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Graphics;

namespace GettingStarted
{
    public partial class Form1 : Form
    {
        # region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        # endregion

        # region Events

        DateTime st;
        DateTime end;
        private void Form1_Load(object sender, EventArgs e)
        {
            pdfViewerControl1.Load("../../../../../../../../Common/Data/PDF/PDF_Succinctly.pdf");
        }

        void pdfViewerControl1_DocumentLoaded(object sender, EventArgs args)
        {
            end = DateTime.Now;
            TimeSpan span= end - st;

            MessageBox.Show("Time taken to Load : "+ span.Milliseconds +"ms");
        }
        # endregion

        # region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName)
        {
            string fullPath = @"..\..\..\..\..\..\..\..\..\Common\Data\PDF\";

            return string.Format(@"{0}{1}", fullPath, fileName);
        }
        #endregion

        
    }
}