/**
* Graph
* @author: Aldrin A. Navarro
* CMSC 204 Data Structures and Algorithms
*
* DFS
* BFS
* Search DFS
* Search BFS
* 
*/

using System.Collections;

namespace Containers
{
    public class Vertex
    {
        public string Tag;
        public bool IsVisited;

        public Vertex(string tag)
        {
            Tag = tag;
            IsVisited = false;
        }
    }

    public class Graph
    {
        private const int VERTEX_CAP = 20;
        private Vertex[] Vertices;
        private int[,] Matrix;
        public int VertexCount;

        public Graph()
        {
            Vertices = new Vertex[VERTEX_CAP];
            Matrix = new int[VERTEX_CAP, VERTEX_CAP];
            VertexCount = 0;
            // init matrix
            for (int i = 0; i < VERTEX_CAP; i++)
            {
                for (int j = 0; j < VERTEX_CAP; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
        }

        /**
         * Add a vertex to the set of vertices 
         */
        public int AddVertex(string tag)
        {
            Vertices[VertexCount] = new Vertex(tag);
            VertexCount++;
            return VertexCount - 1;
        }

        // See next 'AddEdge'
        public void AddEdge(int source, int dest)
        {
            AddEdge(source, dest, true);  // default to directed
        }

        /**
         * Add an edge to the adjacency matrix linking source edge
         * and destination edge. Supports both directed and undirected
         * edges.
         */
        public void AddEdge(int source, int dest, bool directed)
        {
            Matrix[source, dest] = 1;
            if (!directed)  // only add symmetry if undirected
                Matrix[dest, source] = 1;
        }

        /**
         * Check if a vertex exists in the set of vertices
         */
        public int SearchVertex(string tag)
        {
            int index = -1;
            for (int i = 0; i < Vertices.Length; i++)
            {
                if (Vertices[i] != null && Vertices[i].Tag == tag)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /**
         * Easy helper function instead of doing 
         *   AddVertex(A)
         *   AddVertex(B)
         *   AddEdge(A, B)
         * 
         * do this:
         *   A -> B for directed
         *   2 <- 6 for directed inverse
         *   a <-> B  or a - B  for undirected
         */
        public void Insert(string A, string Direction, string B)
        {
            var Source = A;
            var Destination = B;
            bool directed = false;
            switch (Direction)
            {
                case "<-":
                    Source = A;
                    Destination = B;
                    directed = true;
                    break;
                case "->":
                    directed = true;
                    break;
                case "<->":  // not required but put anyway
                case "-":    // for readability
                default:
                    break;
            }
            int SourceIndex = SearchVertex(Source);
            if (SourceIndex < 0)
                SourceIndex = AddVertex(Source);
            int DestinationIndex = SearchVertex(Destination);
            if (DestinationIndex < 0)
                DestinationIndex = AddVertex(Destination);
            AddEdge(SourceIndex, DestinationIndex, directed);
        }

        /**
         * Display the vertex's tag
         */
        public void DisplayVertex(int vertexID)
        {
            System.Console.Write(Vertices[vertexID].Tag + " ");
        }

        /**
         * Returns the next unvisited adjacent vertex
         */
        private int GetAdjacentUnvisitedVertex(int v)
        {
            for (int j = 0; j <= VertexCount - 1; j++)
                if ((Matrix[v, j] == 1) && (!Vertices[j].IsVisited))
                    return j;
            return -1;
        }

        /**
         * Reset all vertices as unvisited
         */
        public void ResetVisits()
        {
            for (int j = 0; j <= VertexCount - 1; j++)
                Vertices[j].IsVisited = false;
        }

        /**
         * Perform a DF Traversal
         */
        public void DepthFirstSearchTraverse()
        {
            Vertices[0].IsVisited = true;
            DisplayVertex(0);
            Stack nodeStack = new Stack();
            nodeStack.Push(0);  // remember to backtrack here
            int vNext;
            while (nodeStack.Count > 0)
            {
                vNext = GetAdjacentUnvisitedVertex((int) nodeStack.Peek());
                if (vNext == -1)
                    nodeStack.Pop();  // last vertex nowhere to go but back
                else
                {
                    Vertices[vNext].IsVisited = true;
                    DisplayVertex(vNext);
                    nodeStack.Push(vNext);  // remember to backtrack here
                }
            }

            ResetVisits();
        }

        /**
         * Perform a DF Search
         */
        public bool DepthFirstSearch(string Key)
        {
            bool IsFound = false;
            Vertices[0].IsVisited = true;
            DisplayVertex(0);
            if (Vertices[0].Tag == Key)
            {
                IsFound = true;
                goto Breakdown;
            }

            Stack nodeStack = new Stack();
            nodeStack.Push(0);  // remember to backtrack here
            int vNext;
            while (nodeStack.Count > 0)
            {
                vNext = GetAdjacentUnvisitedVertex((int)nodeStack.Peek());
                if (vNext == -1)
                    nodeStack.Pop();  // last vertex nowhere to go but back
                else
                {
                    Vertices[vNext].IsVisited = true;
                    DisplayVertex(vNext);
                    nodeStack.Push(vNext);  // remember to backtrack here

                    if (Vertices[vNext].Tag == Key)
                    {
                        IsFound = true;
                        goto Breakdown;
                    }
                }
            }
            goto Breakdown;

            Breakdown:
                ResetVisits();
                return IsFound;
        }

        /**
         * Perform a BF Traversal
         */
        public void BreadthFirstSearchTraverse()
        {
            Queue nodeQueue = new Queue();
            Vertices[0].IsVisited = true;
            DisplayVertex(0);
            nodeQueue.Enqueue(0);
            int currentVertex, nextVertex;
            while (nodeQueue.Count > 0)
            {
                currentVertex = (int) nodeQueue.Dequeue();
                nextVertex = GetAdjacentUnvisitedVertex(currentVertex);
                while (nextVertex != -1) {
                    Vertices[nextVertex].IsVisited = true;
                    DisplayVertex(nextVertex);
                    nodeQueue.Enqueue(nextVertex);
                    nextVertex = GetAdjacentUnvisitedVertex(currentVertex);
                }
            }

            ResetVisits();
        }

        /**
         * Perform a BF Search
         */
        public bool BreadthFirstSearch(string Key)
        {
            bool IsFound = false;
            Queue nodeQueue = new Queue();
            Vertices[0].IsVisited = true;
            DisplayVertex(0);
            nodeQueue.Enqueue(0);

            if (Vertices[0].Tag == Key)
            {
                IsFound = true;
                goto Breakdown;
            }

            int currentVertex, nextVertex;
            while (nodeQueue.Count > 0)
            {
                currentVertex = (int)nodeQueue.Dequeue();
                nextVertex = GetAdjacentUnvisitedVertex(currentVertex);
                while (nextVertex != -1)
                {
                    Vertices[nextVertex].IsVisited = true;
                    DisplayVertex(nextVertex);
                    nodeQueue.Enqueue(nextVertex);

                    if (Vertices[nextVertex].Tag == Key)
                    {
                        IsFound = true;
                        goto Breakdown;
                    }

                    nextVertex = GetAdjacentUnvisitedVertex(currentVertex);
                }
            }
            goto Breakdown;

            Breakdown:
                ResetVisits();
                return IsFound;
        }

    }

}