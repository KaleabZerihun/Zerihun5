/********************************************************************
*** NAME : Kaleab Zerihun
*** CLASS : CSc 346
*** ASSIGNMENT : Assignment 5
*** DUE DATE : 04-24-24
*** INSTRUCTOR : GAMRADT
*********************************************************************
*** DESCRIPTION : The Graph class uses a queue and a stack to implement BFS and DFS. It represents the graph with a list
 of  vertices after reading a graph data file in JSON format. ***
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.NetworkInformation;


namespace GraphNS
{
    public class Graph : IGraphAlgorithms, IAccessData
    {
        private List<Vertex> _vertices = new();
        public Stack<Vertex> GAStack = new();
        public Queue<Vertex> GAQueue = new();
/********************************************************************
*** METHOD <Graph>
*********************************************************************
*** DESCRIPTION : Copy constructor for GraphNS class
*** INPUT ARGS : value
*** OUTPUT ARGS : N/A
*** IN/OUT ARGS : N/A
*** RETURN : N/A
********************************************************************/
        public Graph(string value)
        {
            _vertices = new List<Vertex>();
            GetData(value);
        }
/************************************************************************
*  Method: GetData                                                   **
*  **********************************************************************
*  Description:  Reads graph data in JSON format from a file                              **
*  **********************************************************************
*  Input Arguments: Path                                               **
*  Output Arguments: N/A                                              **
*  Return: Void                                                        **
*  *********************************************************************/
        private void GetData(string path)
        {
            string? jsonString = null;

            try
            {
                jsonString = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error reading the file:");
                Console.WriteLine(ex.Message);
            }

            if(jsonString != null)
            {
                var vertex = JsonSerializer.Deserialize<List<Vertex>>(jsonString)!;
                _vertices = new List<Vertex>();
                _vertices =(List<Vertex>)vertex;
            }
            else
            {
                jsonString = JsonSerializer.Serialize<List<Vertex>>(_vertices);
                File.WriteAllText(path, jsonString);
            }
        }
/************************************************************************
*  Method: BFS                                                   **
*  **********************************************************************
*  Description:  use BFS to traverese the graph from a given vertex                              **
*  **********************************************************************
*  Input Arguments: start                                               **
*  Output Arguments: N/A                                              **
*  Return: Void                                                        **
*  *********************************************************************/
        public void BFS(int start)
        {
           Vertex current = new Vertex();
            Console.WriteLine($"BFS Starting from  {start}");
            // Mark the current node as visited and enqueue it
            _vertices[start].Visited = true;
            GAQueue.Enqueue(_vertices[start]);
            // Iterate over the queue
            while (GAQueue.Count > 0) 
            {
                
                // Dequeue a vertex from queue and print it
                current = GAQueue.Dequeue();
                ViewVertex(current);
                while(GetAdjUnvisitedVertex(current) != null)
                { 
                    Vertex next = GetAdjUnvisitedVertex(current)!;
                    if(!next.Visited)
                    {
                        GAQueue.Enqueue(next);
                        next.Visited = true;
                    }
                }
            }
            ResetVisitedSet();
            Console.WriteLine(" ");

        }
/************************************************************************
*  Method: DFS                                                   **
*  **********************************************************************
*  Description:  use DFS to traverese the graph from a given vertex                              **
*  **********************************************************************
*  Input Arguments: start                                               **
*  Output Arguments: N/A                                              **
*  Return: Void                                                        **
*  *********************************************************************/
        public void DFS(int start)
        {
            Console.WriteLine($"DFS Starting from {start}");
            Vertex? temp = new Vertex();
            Vertex? current = new Vertex();
            if(_vertices.Count == 0)
            {
                return;
            }
            GAStack.Push(_vertices[start]);
            
            while(GAStack.Any()) 
            {
                current = GAStack.Peek();
                if (!current.Visited)
                {
                    current.Visited = true;
                    ViewVertex(current);
                }
                temp = GetAdjUnvisitedVertex(current);
                
                if (temp != null)
                {
                    GAStack.Push(temp);
                }
                else
                {
                    GAStack.Pop();
                }
            }
            ResetVisitedSet();
            Console.WriteLine();
        }
/************************************************************************
*  Method: ResetVisitedSet                                                   **
*  **********************************************************************
*  Description:  Set the Visited flag to false                             **
*  **********************************************************************
*  Input Arguments: N/A                                               **
*  Output Arguments: N/A                                              **
*  Return: Void                                                        **
*  *********************************************************************/
        private void ResetVisitedSet()
        {
            foreach(Vertex vertex in _vertices)
            {
                vertex.Visited = false;
            }
        }
/************************************************************************
*  Method: GetAdjUnvisitedVertex                                                   **
*  **********************************************************************
*  Description:  search adjacent vertex to find the first unvisted vertex                             **
*  **********************************************************************
*  Input Arguments: vertex                                               **
*  Output Arguments: N/A                                              **
*  Return: Vertex                                                        **
*  *********************************************************************/
        private Vertex? GetAdjUnvisitedVertex(Vertex vertex)
        {
            if(vertex.AdjVertices == null)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < vertex.AdjVertices.Count; i++)
                {
                    if (_vertices[i].Number == vertex.Number)
                        continue;
                    if(vertex.AdjVertices[i] == true)
                    {
                        if(_vertices[i].Visited == false)
                           return _vertices[i];
                    }
                }
                return null;
            }
        }
/************************************************************************
*  Method: ViewVertex                                                   **
*  **********************************************************************
*  Description:  display current vertex value                        **
*  **********************************************************************
*  Input Arguments: vertex                                               **
*  Output Arguments: N/A                                              **
*  Return: Void                                                        **
*  *********************************************************************/
        private void ViewVertex(Vertex vertex)
        {
            if(vertex == null)
            {
                return;
            }
            else
            {
                Console.WriteLine(vertex.Number.ToString());
            }
            
        }
    }
}