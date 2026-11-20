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



		public Product(int id, string name, int quantity)
		{
			SetId(id);
			SetName(name);
			SetQuantity(quantity);
		}




		public Product(Product p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}

			SetId(p.GetId());
			SetName(p.GetName());
			SetQuantity(p.GetQuantity());
		}


		public int GetId()
		{
			return id;
		}


		public void SetId(int id)
		{
			if (id > 0)
			{
				this.id = id;
			}
			else
			{
				Console.WriteLine("Invalid Product ID. ID must be greater than zero.");
			}
		}


		public string GetName() 
		{
		return name;
		}


		public void SetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name) || name.Contains('|'))
			{
				throw new ArgumentException(
					"Product name cannot be empty or contain '|'.",
					nameof(name)
				);
			}

			this.name = name;
		}


		public int GetQuantity()
		{
			return quantity;
		}


		public void SetQuantity(int quantity)
		{
			if (quantity < 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(quantity),
					"Quantity cannot be negative."
				);
			}

			this.quantity = quantity;
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
