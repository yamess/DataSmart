using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmart.Helpers;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSmart.Models
{
    public class ProductStructure: BaseModel
    {
		[Key]
		public int Id { get; set; }

		private string _Category_1;
		public string Category_1
		{
			get { return _Category_1; }
			set { _Category_1 = value; RaisePropertyChanged("Category_1"); }
		}

		private string _Category_2;
		public string Category_2
		{
			get { return _Category_2; }
			set { _Category_2 = value; RaisePropertyChanged("Category_2"); }
		}
	}
}
