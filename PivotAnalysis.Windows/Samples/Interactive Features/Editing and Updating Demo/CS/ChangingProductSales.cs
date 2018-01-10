#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

namespace EditingDemo
{
    public class ProductSales : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private string product = "";

        private string date = "";

        private string country = "";

        private string state = "";

        private int quantity = 0;

        private double amount = 0;

        private int extra = 0;

        private DateTime date2;



        public string Product
        {
            get
            {
                return product;
            }
            set
            {
                if (product != value)
                {
                    OnPropertyChanging("Product");
                    product = value;
                    OnPropertyChanged("Product");
                }
            }
        }

        public string Date 
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    OnPropertyChanging("Date");
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (country != value)
                {
                    OnPropertyChanging("Country");
                    country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (state != value)
                {
                    OnPropertyChanging("State");
                    state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (quantity != value)
                {
                    OnPropertyChanging("Quantity");
                    quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (amount != value)
                {
                    OnPropertyChanging("Amount");
                    amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        public int Extra
        {
            get
            {
                return extra;
            }
            set
            {
                if (extra != value)
                {
                    OnPropertyChanging("Extra");
                    extra = value;
                    OnPropertyChanged("Extra");
                }
            }
        }

         public DateTime Date2
        {
            get
            {
                return date2;
            }
            set
            {
                if (date2 != value)
                {
                    OnPropertyChanging("Date2");
                    date2 = value;
                    OnPropertyChanged("Date2");
                }
            }
        }

         public static int count = 2000;
         private static ProductSalesCollection singleListDataSource = null;
     
        public static ProductSalesCollection GetSalesData()
        {
            if (singleListDataSource != null)
                return singleListDataSource;

            /// Geography
            string[] countries = new string[] { "Australia", "Canada", "France", "Germany", "United Kingdom", "United States" };
            string[] ausStates = new string[] { "New South Wales", "Queensland", "South Australia", "Tasmania", "Victoria" };
            string[] canadaStates = new string[] { "Alberta", "British Columbia", "Brunswick", "Manitoba", "Ontario", "Quebec" };
            string[] franceStates = new string[] { "Charente-Maritime", "Essonne", "Garonne (Haute)", "Gers", };
            string[] germanyStates = new string[] { "Bayern", "Brandenburg", "Hamburg", "Hessen", "Nordrhein-Westfalen", "Saarland" };
            string[] ukStates = new string[] { "England" };
            string[] ussStates = new string[] { "New York", "North Carolina", "Alabama", "California", "Colorado", "New Mexico", "South Carolina" };

            /// Time
            string[] dates = new string[] { "FY 2005", "FY 2006", "FY 2008", "FY 2009" };
            DateTime date0 = new DateTime(2005, 1, 1);
            /// Products
            string[] products = new string[] { "Bike", "Car" , "Truck", "Scooters"};
            products = new string[] { "Bike", "Car" };
            Random r = new Random(123345345);

            int numberOfRecords = ProductSales.count;
            ProductSalesCollection listOfProductSales = new ProductSalesCollection();
            for (int i = 0; i < numberOfRecords; i++)
            {
                ProductSales sales = new ProductSales();
                sales.Country = countries[r.Next(1, countries.GetLength(0))];
                sales.Quantity = r.Next(1, 12);
                /// 1 percent discount for 1 quantity
                double discount = (30000 * sales.Quantity) * (double.Parse(sales.Quantity.ToString()) / 100);
                sales.Amount = (30000 * sales.Quantity) - discount;
                sales.Date = dates[r.Next(r.Next(dates.GetLength(0) + 1))];
                sales.Product = products[r.Next(r.Next(products.GetLength(0) + 1))];
                sales.Extra = i % 2;
                  sales.Date2 = date0.AddDays(r.Next(1500));
                switch (sales.Country)
                {
                    case "Australia":
                        {
                            sales.State = ausStates[r.Next(ausStates.GetLength(0))];
                            break;
                        }
                    case "Canada":
                        {
                            sales.State = canadaStates[r.Next(canadaStates.GetLength(0))];
                            break;
                        }
                    case "France":
                        {
                            sales.State = franceStates[r.Next(franceStates.GetLength(0))];
                            break;
                        }
                    case "Germany":
                        {
                            sales.State = germanyStates[r.Next(germanyStates.GetLength(0))];
                            break;
                        }
                    case "United Kingdom":
                        {
                            sales.State = ukStates[r.Next(ukStates.GetLength(0))];
                            break;
                        }
                    case "United States":
                        {
                            sales.State = ussStates[r.Next(ussStates.GetLength(0))];
                            break;
                        }
                }
                listOfProductSales.Add(sales);
            }
            singleListDataSource = listOfProductSales;
            return listOfProductSales;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.Country, this.State, this.Product);
        }

        public class ProductSalesCollection : ObservableCollection<ProductSales>
        {
            protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                //Console.WriteLine(e.Action);
                base.OnCollectionChanged(e);
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging(string name)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(name));
            }
        }
        #endregion
    }
}
