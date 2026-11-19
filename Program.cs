
using System;

namespace WarehouseManagementSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Warehouse warehouse = new Warehouse();

			int choice = -1;

			do
			{
				Console.WriteLine("\n=== Warehouse Management System ===");
				Console.WriteLine("1. Add Product");
				Console.WriteLine("2. Remove Product");
				Console.WriteLine("3. Display Products");
				Console.WriteLine("4. Exit");

				Console.Write("Enter your choice: ");

				if (int.TryParse(Console.ReadLine(), out choice))
				{
					switch (choice)
					{
						case 1:
							Console.WriteLine("Choose product type:");
							Console.WriteLine("1. Electronics");
							Console.WriteLine("2. Furniture");
							Console.Write("Enter choice: ");

							if (!int.TryParse(Console.ReadLine(), out int type)
								|| (type != 1 && type != 2))
							{
								Console.WriteLine("Invalid product type.");
								break;
							}

							Console.Write("Enter ID: ");
							if (!int.TryParse(Console.ReadLine(), out int id))
							{
								Console.WriteLine("Invalid ID.");
								break;
							}

							Console.Write("Enter Name: ");
							string name = Console.ReadLine() ?? "";


							int quantity;

							Console.Write("Enter Quantity: ");

							while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
							{
								Console.WriteLine("Invalid quantity. Please enter a valid number.");
								Console.Write("Enter Quantity: ");
							}


							if (type == 1)
							{
								Console.Write("Enter Warranty (months): ");

								if (!int.TryParse(Console.ReadLine(), out int warranty)
									|| warranty < 0)
								{
									Console.WriteLine("Invalid warranty.");
									break;
								}

								Electronics electronics =
									new Electronics(id, name, quantity, warranty);

								warehouse.AddProduct(electronics);
							}
							else
							{
								Console.Write("Enter Material: ");
								string material = Console.ReadLine() ?? "";

								if (string.IsNullOrWhiteSpace(material))
								{
									Console.WriteLine("Invalid material.");
									break;
								}

								Furniture furniture =
									new Furniture(id, name, quantity, material);

								warehouse.AddProduct(furniture);
							}

							break;

						case 2:
							Console.Write("Enter ID to remove: ");

							if (int.TryParse(Console.ReadLine(), out int removeId))
							{
								warehouse.RemoveProduct(removeId);
							}
							else
							{
								Console.WriteLine("Invalid ID.");
							}

							break;

						case 3:
							Console.WriteLine("Displaying Warehouse Products...");
							warehouse.DisplayProducts();
							break;


						case 4:
							Console.WriteLine("Exiting program... Goodbye!");
							break;

						default:
							Console.WriteLine("Invalid option. Choose 1 to 4.");
							break;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a number.");
					choice = -1;
				}

			} while (choice != 4);
		}
	}
}
