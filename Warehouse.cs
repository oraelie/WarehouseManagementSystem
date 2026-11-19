
using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem
{
	internal class Warehouse
	{
		private List<Product> products;

		public Warehouse()
		{
			products = new List<Product>();
		}

		public bool AddProduct(Product p)
		{
			if (p == null)
			{
				Console.WriteLine("Invalid product.");
				return false;
			}

			foreach (Product product in products)
			{
				if (product.GetId() == p.GetId())
				{
					Console.WriteLine("Product ID already exists.");
					return false;
				}
			}

			products.Add(p);

			Console.WriteLine("Product added successfully.");
			return true;
		}


		public bool RemoveProduct(int id)
		{
			foreach (Product product in products)
			{
				if (product.GetId() == id)
				{
					products.Remove(product);

					Console.WriteLine("Product removed successfully.");
					return true;
				}
			}

			Console.WriteLine("Product not found.");
			return false;
		}


		public Product? FindProduct(int id)
		{
			foreach (Product product in products)
			{
				if (product.GetId() == id)
				{
					return product;
				}
			}

			return null;
		}


		public void DisplayProducts()
		{
			if (products.Count == 0)
			{
				Console.WriteLine("The warehouse is empty.");
				return;
			}

			Console.WriteLine("\n--- Warehouse Products ---");

			foreach (Product product in products)
			{
				product.DisplayInfo();
				Console.WriteLine("------------------------");
			}
		}


		public int GetTotalQuantity()
		{
			int totalQuantity = 0;

			foreach (Product product in products)
			{
				totalQuantity += product.GetQuantity();
			}

			return totalQuantity;
		}


		public int GetProductQuantity(int id)
		{
			Product? product = FindProduct(id);

			if (product != null)
			{
				Console.WriteLine($"Quantity Of Product {product.GetName()} ({product.GetId()}) : {product.GetQuantity()}");
				return product.GetQuantity();
			}
			else
			{
				Console.WriteLine("Product not Found");
				return -1;
			}
		}


	}
}
