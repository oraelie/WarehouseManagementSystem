
using System;

namespace WarehouseManagementSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Warehouse warehouse = new Warehouse();

			int choice;

			do
			{
				Console.WriteLine();
				Console.WriteLine("=== Warehouse Management System ===");
				Console.WriteLine("1. Add Product");
				Console.WriteLine("2. Remove Product");
				Console.WriteLine("3. Display Products");
				Console.WriteLine("4. Exit");

				Console.Write("Enter your choice: ");

				if (!int.TryParse(Console.ReadLine(), out choice))
				{
					Console.WriteLine("Invalid choice. Please enter a number.");
					continue;
				}

				switch (choice)
				{
					case 1:
						// ADD PRODUCT

						int type;

						Console.WriteLine("Choose product type:");
						Console.WriteLine("1. Electronics");
						Console.WriteLine("2. Furniture");
						Console.Write("Enter choice: ");

						while (!int.TryParse(Console.ReadLine(), out type)
							   || (type != 1 && type != 2))
						{
							Console.WriteLine("Invalid product type.");
							Console.Write("Enter choice (1 or 2): ");
						}

						// Product ID validation
						int id;

						Console.Write("Enter ID: ");

						while (!int.TryParse(Console.ReadLine(), out id)
							   || id <= 0)
						{
							Console.WriteLine("Invalid ID. ID must be greater than zero.");
							Console.Write("Enter ID: ");
						}

						// Product Name validation
						string name;

						Console.Write("Enter Name: ");
						name = Console.ReadLine() ?? "";

						while (string.IsNullOrWhiteSpace(name))
						{
							Console.WriteLine("Invalid name. Name cannot be empty.");
							Console.Write("Enter Name: ");
							name = Console.ReadLine() ?? "";
						}

						// Product Quantity validation
						int quantity;

						Console.Write("Enter Quantity: ");

						while (!int.TryParse(Console.ReadLine(), out quantity)
							   || quantity < 0)
						{
							Console.WriteLine("Invalid quantity. Please enter a valid number.");
							Console.Write("Enter Quantity: ");
						}

						// Create product according to selected type
						if (type == 1)
						{
							// ELECTRONICS

							int warranty;

							Console.Write("Enter Warranty (months): ");

							while (!int.TryParse(Console.ReadLine(), out warranty)
								   || warranty < 0)
							{
								Console.WriteLine("Invalid warranty. Please enter a valid number.");
								Console.Write("Enter Warranty (months): ");
							}

							Electronics electronics =
								new Electronics(id, name, quantity, warranty);

							warehouse.AddProduct(electronics);
						}
						else
						{
							// FURNITURE

							string material;

							Console.Write("Enter Material: ");
							material = Console.ReadLine() ?? "";

							while (string.IsNullOrWhiteSpace(material))
							{
								Console.WriteLine("Invalid material. Material cannot be empty.");
								Console.Write("Enter Material: ");
								material = Console.ReadLine() ?? "";
							}

							Furniture furniture =
								new Furniture(id, name, quantity, material);

							warehouse.AddProduct(furniture);
						}

						break;

					case 2:
						// REMOVE PRODUCT

						int removeId;

						Console.Write("Enter Product ID to remove: ");

						while (!int.TryParse(Console.ReadLine(), out removeId)
							   || removeId <= 0)
						{
							Console.WriteLine("Invalid Product ID.");
							Console.Write("Enter Product ID to remove: ");
						}

						warehouse.RemoveProduct(removeId);

						break;


					case 3:
						// DISPLAY PRODUCTS

						warehouse.DisplayProducts();

						Console.WriteLine($"Total Warehouse Quantity: {warehouse.GetTotalQuantity()}");
						
						break;


					case 4:
						// EXIT

						Console.WriteLine("Exiting Warehouse Management System...");
						break;

					default:
						Console.WriteLine("Invalid choice. Please select 1 to 4.");
						break;
				}

			} while (choice != 4);
		}
	}
}
