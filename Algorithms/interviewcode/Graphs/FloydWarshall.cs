using System;
namespace InterviewCode
{
	public class FloydWarshall
	{

		public int[,] FloydWarshallSP(int[,] graph, int nodeCount)
		{

			// matrix with shortest paths between every pair of vertices
			int[,] distMatrix = new int[nodeCount, nodeCount];
			int i, j, k;


			// init with values from graph
			for (i = 0; i < nodeCount; i++)
			{
				for (j = 0; j < nodeCount; j++)
				{
					distMatrix[i, j] = graph[i, nodeCount];
				}
			}
			/*Add all vertices one by one to the set of intermediate vertices
			 * 
			*/
			for (k = 0; k < nodeCount; k++)
			{

				// Source
				for (i = 0; i < nodeCount; i++)
				{
					// destination
					for (j = 0; j < nodeCount; j++)
					{

						if (distMatrix[i, k] + distMatrix[k, j] < distMatrix[i, j])
							distMatrix[i, j] = distMatrix[i, k] + distMatrix[k, j];
					}
				}
			}
			return distMatrix;

		}

		public int[,] FloydWarshallTwo(int[,] graph)
		{
			int[,] distance = new int[graph.Length, graph.Length];
			int[,] path = new int[graph.Length, graph.Length];

			for (int i = 0; i < graph.Length; i++)
			{
				for (int j = 0; j < graph.GetLength(i); j++)
				{
					distance[i, j] = graph[i, j];
					if (graph[i, j] != int.MaxValue && i != j)
					{
						path[i, j] = i;
					}
					else
					{
						path[i, j] = -1;
					}
				}
			}

			for (int k = 0; k < graph.Length; k++)
			{
				for (int i = 0; i < graph.Length; i++)
				{
					for (int j = 0; j < graph.Length; j++)
					{

						if (distance[i, k] == int.MaxValue || distance[k, j] == int.MaxValue)
						{
							continue;
						}

						if (distance[i, j] > distance[i, k] + distance[k, j])
						{
							distance[i, j] = distance[i, k] + distance[k, j];
							path[i, j] = path[k, j];
						}
					}

				}
			}


			// look for negative weight cycle by checking the diagonal of distance matrix
			for (int i = 0; i < distance.Length; i++)
			{

				if (distance[i, i] < 0)
				{
					throw new Exception("Negative Weight Cycle Exception");
				}
			}
			return distance;
		}
	}
}