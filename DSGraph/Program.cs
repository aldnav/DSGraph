/**
* Graph Program
* @author: Aldrin A. Navarro
* CMSC 204 Data Structures and Algorithms
* 
*/


using Containers;

namespace DSGraph
{
    class Program
    {
        static void DisplayMenu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("╔═══════ Data Structures: Graph ══════╗");
            System.Console.WriteLine("║ [1] Perform Depth First Traversal   ║");
            System.Console.WriteLine("║ [2] Perform Breadth First Traversel ║");
            System.Console.WriteLine("║ [3] Search Graph 1 (DFS)            ║");
            System.Console.WriteLine("║ [4] Search Graph 2 (BFS)            ║");
            System.Console.WriteLine("║ [5] Exit                            ║");
            System.Console.WriteLine("║ See https://i.imgur.com/AYo7QnY.png ║");
            System.Console.WriteLine("║ for graphs                          ║");
            System.Console.WriteLine("╚════ (c) 2018 Aldrin Navarro ════════╝");
            System.Console.Write("Enter option: ");
        }

        static void Main(string[] args)
        {
            // GRAPH 1
            Graph graph1 = new Graph();
            graph1.Insert("1", "->", "2");
            graph1.Insert("2", "->", "4");
            graph1.Insert("4", "->", "5");
            graph1.Insert("5", "->", "2");
            graph1.Insert("1", "->", "3");
            graph1.Insert("3", "->", "6");
            graph1.Insert("6", "->", "4");
            graph1.Insert("6", "->", "7");

            // GRAPH 2
            Graph graph2 = new Graph();
            graph2.Insert("A", "->", "B");
            graph2.Insert("B", "->", "E");
            graph2.Insert("E", "->", "C");
            graph2.Insert("E", "->", "D");

            DisplayMenu();
            string UserInput = System.Console.ReadLine();
            while(UserInput != "5")
            {
                switch(UserInput)
                {
                    case "1": // DFT
                        System.Console.WriteLine("Perform Depth Fist Traversal");
                        System.Console.Write("Which graph? [1 or 2]: ");
                        string GraphInput = System.Console.ReadLine();
                        Graph selectedGraph = GraphInput == "1" ? graph1 : GraphInput == "2" ?  graph2 : null;
                        while (selectedGraph == null)
                        {
                            System.Console.Write("Which graph? [1 or 2]: ");
                            GraphInput = System.Console.ReadLine();
                            selectedGraph = GraphInput == "1" ? graph1 : GraphInput == "2" ? graph2 : null;
                        }
                        System.Console.WriteLine("DFS on Graph {0}", GraphInput);
                        selectedGraph.DepthFirstSearchTraverse();
                        break;

                    case "2": // BFT
                        System.Console.WriteLine("Perform Breadth Fist Traversal");
                        System.Console.Write("Which graph? [1 or 2]: ");
                        string GraphInput2 = System.Console.ReadLine();
                        Graph selectedGraph2 = GraphInput2 == "1" ? graph1 : GraphInput2 == "2" ? graph2 : null;
                        while (selectedGraph2 == null)
                        {
                            System.Console.Write("Which graph? [1 or 2]: ");
                            GraphInput2 = System.Console.ReadLine();
                            selectedGraph2 = GraphInput2 == "1" ? graph1 : GraphInput2 == "2" ? graph2 : null;
                        }
                        System.Console.WriteLine("DFS on Graph {0}", GraphInput2);
                        selectedGraph2.BreadthFirstSearchTraverse();
                        break;

                    case "3": // DFS
                        System.Console.WriteLine("Search Graph 1 (DFS)");
                        System.Console.Write("Enter search key: ");
                        string Key = System.Console.ReadLine();
                        System.Console.Write("Searching ");
                        if (graph1.DepthFirstSearch(Key))
                        {
                            System.Console.WriteLine("...\n'{0}' found in graph!", Key);
                        } else
                        {
                            System.Console.WriteLine("...\n'{0}' not found in graph!", Key);
                        }
                        break;

                    case "4": // BFS
                        System.Console.WriteLine("Search Graph 2 (BFS)");
                        System.Console.Write("Enter search key: ");
                        string Key2 = System.Console.ReadLine();
                        System.Console.Write("Searching ");
                        if (graph2.DepthFirstSearch(Key2))
                        {
                            System.Console.WriteLine("...\n'{0}' found in graph!", Key2);
                        }
                        else
                        {
                            System.Console.WriteLine("...\n'{0}' not found in graph!", Key2);
                        }
                        break;

                    default:
                        break;
                }

                System.Console.WriteLine();
                DisplayMenu();
                UserInput = System.Console.ReadLine();
            }
            
        }
    }
}
