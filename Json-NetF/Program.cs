using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Concepts
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var path = @"D:\Users\UchiTesting\Desktop\repos\C#\UT-Concepts\file.json";
			dynamic decoded = System.Web.Helpers.Json.Decode(File.ReadAllText(path));

			foreach (var item in decoded.Team)
			{
				Console.WriteLine(item.id);
				Console.WriteLine(item.Name);
				Console.WriteLine(item.Age);
			}
		}
	}
}
