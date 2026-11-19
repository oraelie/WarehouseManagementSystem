using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem
{
	internal class Product
	{
		private int id;
		private string name;
		private int quantity;

		public Product()
		{
			id = 0;
			name = "Unknown";
			quantity = 0;
		}

		public Product(int id,string name, int quantity) 
		{
			this.id = id;
			this.name = name;
			SetQuantity(quantity);
		}

		public Product(Product p)
		{ 
			this.id=p.id;
			this.name=p.name;
			this.quantity=p.quantity;
		}

		public int GetId()
		{
			return id;
		}

		public void SetId(int id) 
		{
			this.id = id;
		}

		public string GetName() 
		{
		return name;
		}
		public void SetName(string name)
		{
			this.name = name;
		}
		public int GetQuantity()
		{
			return quantity;
		}

		public void SetQuantity(int quantity)
		{

			if (quantity >= 0)
			{
				this.quantity = quantity;
			}
			else
			{
				Console.WriteLine("Quantity cannot be a negative number");
			}
		}

		public virtual void DisplayInfo()
		{
			Console.WriteLine("Product Information");
			Console.WriteLine("-------------------");
			Console.WriteLine($"Product ID: {id}");
			Console.WriteLine($"Product Name: {name}");
			Console.WriteLine($"Quantity: {quantity}");
		}
	}
}
