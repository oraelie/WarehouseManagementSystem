namespace WarehouseManagementSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{


			Electronics e1 = new Electronics(101, "Laptop", 5, 24);

			e1.DisplayInfo();

			Console.ReadKey();




		}
	}
}