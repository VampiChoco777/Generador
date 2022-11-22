using System;
using System.IO;
using System.Collections.Generic;

namespace Generico
{
	public class Program
	{
		static void Main(string[] args)
		{
			try
			{
				using (Lenguaje a = new Lenguaje())
				{
					a.programa();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
