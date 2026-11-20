using System;
using System.Collections.Generic;
using System.IO;

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


		public void SaveProducts()
		{
			string filePath = "products.txt";

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				foreach (Product product in products)
				{
					if (product is Electronics electronics)
					{
						writer.WriteLine(
							$"Electronics|{electronics.GetId()}|{electronics.GetName()}|{electronics.GetQuantity()}|{electronics.GetWarrantyPeriod()}"
						);
					}
					else if (product is Furniture furniture)
					{
						writer.WriteLine(
							$"Furniture|{furniture.GetId()}|{furniture.GetName()}|{furniture.GetQuantity()}|{furniture.GetMaterial()}"
						);
					}
				}
			}

			Console.WriteLine("Products saved successfully.");
		}


		public void LoadProducts()
		{
			string filePath = "products.txt";

			// Check if the file exists
			if (!File.Exists(filePath))
			{
				Console.WriteLine("No saved products found.");
				return;
			}

			try
			{
				string[] lines = File.ReadAllLines(filePath);

				foreach (string line in lines)
				{
					try
					{
						// Split product information
						string[] data = line.Split('|');

						// Validate number of fields
						if (data.Length != 5)
						{
							Console.WriteLine("Invalid product record. Skipping.");
							continue;
						}

						string type = data[0];

						// Validate Product ID
						if (!int.TryParse(data[1], out int id) || id <= 0)
						{
							Console.WriteLine("Invalid Product ID. Skipping.");
							continue;
						}

						// Validate Product Name
						string name = data[2];

						if (string.IsNullOrWhiteSpace(name) || name.Contains('|'))
						{
							Console.WriteLine("Invalid Product Name. Skipping.");
							continue;
						}

						// Validate Product Quantity
						if (!int.TryParse(data[3], out int quantity) || quantity < 0)
						{
							Console.WriteLine("Invalid Product Quantity. Skipping.");
							continue;
						}

						// Load Electronics
						if (type == "Electronics")
						{
							if (!int.TryParse(data[4], out int warranty) || warranty < 0)
							{
								Console.WriteLine("Invalid warranty. Skipping.");
								continue;
							}

							Electronics electronics =
								new Electronics(id, name, quantity, warranty);

							AddProduct(electronics);
						}

						// Load Furniture
						else if (type == "Furniture")
						{
							string material = data[4];

							if (string.IsNullOrWhiteSpace(material) || material.Contains('|'))
							{
								Console.WriteLine("Invalid material. Skipping.");
								continue;
							}

							Furniture furniture =
								new Furniture(id, name, quantity, material);

							AddProduct(furniture);
						}

						// Unknown product type
						else
						{
							Console.WriteLine("Unknown product type. Skipping.");
						}
					}
					catch (ArgumentException ex)
					{
						Console.WriteLine($"Invalid product record: {ex.Message}");
					}
				}

				Console.WriteLine("Product loading completed.");
			}
			catch (IOException ex)
			{
				Console.WriteLine($"Error reading products file: {ex.Message}");
			}
			catch (UnauthorizedAccessException ex)
			{
				Console.WriteLine($"Access denied: {ex.Message}");
			}
		}


	}
}
