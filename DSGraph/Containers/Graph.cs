/**
 * Graph
 * @author: Aldrin A. Navarro
 * CMSC 204 Data Structures and Algorithms
 *
 */

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
            for (int i = 0; i <= VERTEX_CAP; i++)
            {
                for (int j = 0; j <= VERTEX_CAP; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
        }

        public void AddVertex(string tag)
        {
            Vertices[VertexCount] = new Vertex(tag);
            VertexCount++;
        }

        public void AddEdge(int source, int dest)
        {
            // @NOTE: perhaps move 'Directed' as member
            // of class Graph?
            AddEdge(source, dest, true);  // default to directed
        }

        public void AddEdge(int source, int dest, bool directed)
        {
            Matrix[source, dest] = 1;
            if (!directed)  // if undirected, strict to one cell
                Matrix[dest, source] = 1;
        }

        public void DisplayVertex(int vertexID)
        {
            System.Console.Write(Vertices[vertexID].Tag + " ");
        }


    }

}