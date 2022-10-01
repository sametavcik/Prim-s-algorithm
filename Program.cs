using System;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
			int[] yol = new int[5];
			int numOfVertex = 5;
			int source = 0;
			Vertex[] graph = new Vertex[numOfVertex];

			// Dugumler yaratildi
			for (int i = 0; i < numOfVertex; i++)
				graph[i] = new Vertex();

			// Ornek kenarlar(edges) eklendi
			graph[0].neighbours.Add(new Edge(1, 3));
			graph[1].neighbours.Add(new Edge(0, 3));

			graph[0].neighbours.Add(new Edge(2, 4));
			graph[2].neighbours.Add(new Edge(0, 4));

			graph[3].neighbours.Add(new Edge(1, 6));
			graph[1].neighbours.Add(new Edge(3, 6));

			graph[4].neighbours.Add(new Edge(1, 2));
			graph[1].neighbours.Add(new Edge(4, 2));

			graph[1].neighbours.Add(new Edge(2, 5));
			graph[2].neighbours.Add(new Edge(1, 5));

			graph[2].neighbours.Add(new Edge(4, 7));
			graph[4].neighbours.Add(new Edge(2, 7));

			Console.WriteLine("Minimum Spanning tree'nin yol uzunluğu = {0}",runPrimsAlgorithm(graph, numOfVertex, source,yol));
			Console.Write("sırasıyla bakılan düğümler= ");
			foreach (int i in yol)
            {
				Console.Write("-{0}",i);
            }
		}


		public static int runPrimsAlgorithm(Vertex[] graph, int numOfVertex, int source,int[] yol)
		{

			bool[] visited = new bool[numOfVertex];
			yol[0] = source;
			//baslangic noktasi visited olarak isaretlendi
			visited[source] = true;

			PriorityQueue priorityQueue = new PriorityQueue(10);

			// Baslangic dugumun kenarlari(edgeleri) priority queue ya eklenir
			foreach (Edge e in graph[source].neighbours)
				priorityQueue.ekle(e);

			// minimumCost degiskenimiz tum dugumleri gezmemiz icin gereken minimum agirligi tutacak
			int minimumCost = 0;
			int i = 1;
			while (!priorityQueue.bosMu())
			{
				//priorityqueue dan agirligi en dusuk olan kenar alinir
				Edge edge = priorityQueue.sil();
				
				/**
				 * eger bu aldigimiz kenarin gittigi dugum onceden ziyaret edildiyse,
				 * bu dugum icin herhangi bir islem yapmamize gerek yok.
				 */
				if (visited[edge.to])
					continue;

				// eger ziyaret edilmediyse,bu kenar ziyaret edildi olarak isaretlenir.
				visited[edge.to] = true;
				yol[i] = edge.to;
				i += 1;

				// bu kenar ilk defa ziyaret edildigi icin agirligi minimumCost degiskenine eklenir
				minimumCost += edge.weight;

				// bu kenarin gittigi dugumun kenarlari priorityqueue ya eklenir
				foreach (Edge childEdge in graph[edge.to].neighbours)
				{
					priorityQueue.ekle(childEdge);
				}
			}
			return minimumCost;
		}
	}
}
