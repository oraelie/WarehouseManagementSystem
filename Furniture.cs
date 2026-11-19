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
		: base(id,name,quantity)
		{
			this.material = material;
		}

		public Furniture(Furniture f) : base(f)
		{
			SetMaterial(material);
		}


		public string GetMaterial()
		{
			return material;
		}

		public void SetMaterial(string material)
		{
			if (!string.IsNullOrWhiteSpace(material))
			{
				this.material = material;
			}
			else
			{
				Console.WriteLine("Material cannot be empty.");
			}
		}

		public override void DisplayInfo()
		{
			base.DisplayInfo();
			Console.WriteLine($"Material: {material}");
		}


	}
}
