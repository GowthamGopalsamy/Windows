#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Drawing;
namespace EssentialXlsIOSamples
{
    class Customer
    {
        #region Members
        private string m_salesPerson;
        private string m_salesJanJune;
        private string m_salesJulyDec;
        private int m_change;
        private byte[] m_image;
        #endregion

        #region Properties
        public string SalesPerson
        {
            get
            {
                return m_salesPerson;
            }
            set
            {
                m_salesPerson = value;
            }
        }

        public string SalesJanJune
        {
            get
            {
                return m_salesJanJune;
            }
            set
            {
                m_salesJanJune = value;
            }
        }
        public string SalesJulyDec
        {
            get
            {
                return m_salesJulyDec;
            }
            set
            {
                m_salesJulyDec = value;
            }

        }
        public int Change
        {
            get
            {
                return m_change;
            }
            set
            {
                m_change = value;
            }

        }
        public byte[] Image
        {
            get
            {
                return m_image;
            }
            set
            {
                m_image = value;
            }
        }
        #endregion

        #region Intialization
        public Customer()
        {
        }
        public Customer(string name,string juneToJuly,string julyToDec,int change,byte[] image)
        {
            this.m_salesPerson = name;
            this.m_salesJanJune = juneToJuly;
            this.m_salesJulyDec = julyToDec;
            this.m_change = change;
            this.m_image = image;
        }
        #endregion
    }
}