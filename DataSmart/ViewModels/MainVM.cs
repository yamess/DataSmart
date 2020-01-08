using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmart.Helpers;
using DataSmart.Models;
using DataSmart.Views;

namespace DataSmart.ViewModels
{
    public class MainVM:BaseModel
    {
		public ProductVM ProductVM { get; set; }
		public DashboardVM DashboardVM { get; set; }
		public EmployeeVM EmployeeVM { get; set; }

		public int MyProperty { get; set; }
		private string _Title;

		public string Title
		{
			get { return _Title; }
			set { _Title = value; RaisePropertyChanged("Title"); }
		}

		public MainVM()
		{
			ProductVM = new ProductVM() { };
			DashboardVM = new DashboardVM() { };
			EmployeeVM = new EmployeeVM() { };
		}
	}
}
