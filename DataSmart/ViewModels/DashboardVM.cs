using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmart.ViewModels;
using DataSmart.Models;
using DataSmart.Helpers;
using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;

namespace DataSmart.ViewModels
{
    public class DashboardVM:BaseModel
    {
        public ProductVM ProductVM { get; set; }

        public SeriesCollection BarChartSeriesCollection { get; set; }
        public SeriesCollection LineChartSeriesCollection { get; set; }
        public Product Product_1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        #region Initialisation
        public DashboardVM()
        {
            ProductVM = new ProductVM();

            BarChartSeriesCollection = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double>{20000,24000,25000,40000,32000,34000,20000,76000,23450,34750,78900,110000}
                },
                new ColumnSeries
                {
                    Title = "2016",
                    Values = new ChartValues<double>{25200,67000,58000,41000,3000,24000,98000,120000,88500,68000,55000,49900}
                }
            };

            LineChartSeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double>{20000,24000,25000,40000,32000,34000,20000,76000,23450,34750,78900,110000}
                },
                new LineSeries
                {
                    Title = "2016",
                    Values = new ChartValues<double>{25200,67000,58000,41000,3000,24000,98000,120000,88500,68000,55000,49900}
                }
            };

            Labels = new[] { "Jan", "Fev", "Mars", "Avr", "Mai", "Juin", "Juillet", "Aôut", "Sept", "Oct", "Nov", "Déc" };
            Formatter = (value) => (value.ToString("N", CultureInfo.InvariantCulture));
        }
        #endregion
    }
}
