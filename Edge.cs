using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
	class Edge
	{
		//Edge in nereye gittigini temsil ediyor
		public int to;

		//Edge in agirligini temsil ediyor
		public int weight;


		public Edge(int to, int weight)
		{
			this.to = to;
			this.weight = weight;
		}
	}
}
