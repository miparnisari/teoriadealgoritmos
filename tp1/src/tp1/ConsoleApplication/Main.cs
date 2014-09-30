using System;
using Model;

namespace ConsoleApplication
{
	class MainClass
	{
		public static void Main ()
		{
			Node<string> node = new Node<string>("hello world!");
			Console.WriteLine (node.Data);
		}
	}
}
