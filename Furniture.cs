using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem
{
	internal class Furniture : Product
	{
		private string material = "Unknown";

		public Furniture() : base() 
		{

		}

		public Furniture(int id, string name, int quantity, string material)
						: base(id, name, quantity)
		{
			SetMaterial(material);
		}

		public Furniture(Furniture f) : base(f)
		{
			SetMaterial(f.GetMaterial());
		}

		public string GetMaterial()
		{
			return material;
		}


		public void SetMaterial(string material)
		{
			if (string.IsNullOrWhiteSpace(material))
			{
				throw new ArgumentException(
					"Material cannot be empty.",
					nameof(material)
				);
			}

			this.material = material;
		}

		public override void DisplayInfo()
		{
			base.DisplayInfo();
			Console.WriteLine($"Material: {material}");
		}
	}
}
