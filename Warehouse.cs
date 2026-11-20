
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
			// Check if the product is null
			if (p == null)
			{
				Console.WriteLine("Invalid product.");
				return false;
			}

			// Validate Product ID
			if (p.GetId() <= 0)
			{
				Console.WriteLine("Cannot add product. Invalid Product ID.");
				return false;
			}

			// Validate Product Name
			if (string.IsNullOrWhiteSpace(p.GetName()))
			{
				Console.WriteLine("Cannot add product. Invalid Product Name.");
				return false;
			}

			// Validate Product Quantity
			if (p.GetQuantity() < 0)
			{
				Console.WriteLine("Cannot add product. Invalid Product Quantity.");
				return false;
			}

			// Check for duplicate Product IDs
			foreach (Product product in products)
			{
				if (product.GetId() == p.GetId())
				{
					Console.WriteLine("Product ID already exists.");
					return false;
				}
			}

			// Add the product to the warehouse
			products.Add(p);

			Console.WriteLine("Product added successfully.");
			return true;
		}




		public bool RemoveProduct(int id)
		{
			Product? product = FindProduct(id);

			if (product == null)
			{
				Console.WriteLine("Product not found.");
				return false;
			}

			products.Remove(product);

			Console.WriteLine("Product removed successfully.");
			return true;
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
