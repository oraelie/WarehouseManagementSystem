namespace WarehouseManagementSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{



			Warehouse warehouse = new Warehouse();

			// Create an Electronics object
			Electronics e1 = new Electronics(101, "Laptop", 5, 24);

			// Create a Furniture object
			Furniture f1 = new Furniture(201, "Office Desk", 10, "Wood");

			// Create an Electronics object
			Electronics e3 = new Electronics(102, "Laptop3", 5, 36);

			// Create a Furniture object
			Furniture f3 = new Furniture(202, "Office Desk3", 10, "Wood3");


			// Add both products
			warehouse.AddProduct(e1);
			warehouse.AddProduct(f1);
			warehouse.AddProduct(e3);
			warehouse.AddProduct(f3);

			// Test duplicate product ID
			Electronics e2 = new Electronics(101, "Monitor", 8, 12);
			warehouse.AddProduct(e2);

			Console.ReadKey();

			//warehouse.RemoveProduct(101);


			Console.WriteLine("\n--- Testing RemoveProduct ---");

			// Remove an existing product
			warehouse.RemoveProduct(101);

			// Try removing a product that does not exist
			warehouse.RemoveProduct(999);

			// Try removing the same product again
			warehouse.RemoveProduct(101);
			Console.WriteLine();


			Console.WriteLine("\n--- Testing FindProduct ---");

			// Search for an existing product

			Product? foundProduct = warehouse.FindProduct(201);

			if (foundProduct != null)
			{
				Console.WriteLine("Product found:");
				foundProduct.DisplayInfo();
			}
			else
			{
				Console.WriteLine("Product not found.");
			}

			// Search for a nonexistent product
			Product? missingProduct = warehouse.FindProduct(999);

			if (missingProduct != null)
			{
				missingProduct.DisplayInfo();
			}
			else
			{
				Console.WriteLine("Product not found.");
			}


			Console.WriteLine("\n--- Testing DisplayProducts ---");

			// Display all remaining products
			warehouse.DisplayProducts();


			Console.WriteLine("\n--- Testing GetTotalQuantity ---");

			int totalQuantity = warehouse.GetTotalQuantity();

			Console.WriteLine($"Total Quantity in Warehouse: {totalQuantity}");

			warehouse.GetProductQuantity(202);
			warehouse.GetProductQuantity(999);




		}
	}
}