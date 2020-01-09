using System;
using DataSmart.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataSmart.Models
{
	public class Product : BaseModel
	{
		[Key]
		public int ProductId { get; set; }

		public int EmployeeId { get; set; }

		//private string _ProductSKU;
		//[Required]
		//[Index(IsUnique = true)]
		//public string ProductSKU
		//{
		//	get { return _ProductSKU; }
		//	set { _ProductSKU = value; RaisePropertyChanged("ProductSKU"); }
		//}

		private string _ProductName;
		public string ProductName
		{
			get { return _ProductName; }
			set
			{
				_ProductName = value;
				RaisePropertyChanged("ProductName");
			}
		}

		private string _ProductCategory_1;
		public string ProductCategory_1
		{
			get { return _ProductCategory_1; }
			set
			{
				_ProductCategory_1 = value;
				RaisePropertyChanged("ProductCategory_1");
			}
		}

		private string _ProductCategory_2;
		public string ProductCategory_2
		{
			get { return _ProductCategory_2; }
			set
			{
				_ProductCategory_2 = value;
				RaisePropertyChanged("ProductCategory_2");
			}
		}

		private string _ProductCategory_3;
		public string ProductCategory_3
		{
			get { return _ProductCategory_3; }
			set
			{
				_ProductCategory_3 = value;
				RaisePropertyChanged("ProductCategory_3");
			}
		}

		private decimal _UnitPurchasePrice;
		public decimal UnitPurchasePrice
		{
			get { return _UnitPurchasePrice; }
			set
			{
				_UnitPurchasePrice = value;
				RaisePropertyChanged("UnitPurchasePrice");
			}
		}

		private int _Quantity;
		public int Quantity
		{
			get { return _Quantity; }
			set
			{
				_Quantity = value;
				RaisePropertyChanged("Quantity");
			}
		}

		private string _DateOfPurchase;
		public string DateOfPurchase
		{
			get { return _DateOfPurchase; }
			set
			{
				_DateOfPurchase = value;
				RaisePropertyChanged("DateOfPurchase");
			}
		}

		private DateTime _DateOfRecord;
		public DateTime DateOfRecord
		{
			get { return _DateOfRecord; }
			set
			{
				_DateOfRecord = value;
				RaisePropertyChanged("DateOfRecord");
			}
		}

		private decimal _UnitSalePrice;
		public decimal UnitSalePrice
		{
			get { return _UnitSalePrice; }
			set { _UnitSalePrice = value; RaisePropertyChanged("UnitSalePrice"); }
		}

		private decimal _MaxDiscount;
		public decimal MaxDiscount
		{
			get { return _MaxDiscount; }
			set { _MaxDiscount = value; RaisePropertyChanged("MaxDiscount"); }
		}

		private string _Supplier;

		public string Supplier
		{
			get { return _Supplier; }
			set { _Supplier = value; RaisePropertyChanged("Supplier"); }
		}

	}
}
