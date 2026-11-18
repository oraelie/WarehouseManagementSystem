using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem
{
	class Electronics : Product
	{
		private int warrantyPeriod;

		public Electronics() : base()
		{
			warrantyPeriod = 0;

		}

		public Electronics(int id, string name, int quantity, int warrantyPeriod) : base(id, name, quantity)
		{
			SetWarrantyPeriod(warrantyPeriod);
		}


		public Electronics(Electronics e) : base(e)
		{
			this.warrantyPeriod = e.warrantyPeriod;
		}

		public int GetWarrantyPeriod()
		{
			return warrantyPeriod;
		}

		public void SetWarrantyPeriod(int warrantyPeriod)
		{
			if (warrantyPeriod >= 0)
			{
				this.warrantyPeriod = warrantyPeriod;
			}
			else
			{
				Console.WriteLine("Warranty period cannot be negative.");
			}
		}


		public override void DisplayInfo()
		{
			base.DisplayInfo();
			Console.WriteLine($"Warranty Period: {warrantyPeriod} months");
		}



	}
}
