using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            //Check if vertext already exists in dictionary
            if (!vertexMap.ContainsKey(name))
            {
                vertexMap.TryAdd(name, new Vertex(name));
            }
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            if (!vertexMap.ContainsKey(name))
            {
                AddVertex(name);
                return vertexMap.GetValueOrDefault(name);
            }
            else
            {
                return vertexMap.GetValueOrDefault(name);
            }
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            //check if source exists
            if (!vertexMap.ContainsKey(source))
            {
                AddVertex(source);
            }
            //check if dest exist
            if (!vertexMap.ContainsKey(dest))
            {
                AddVertex(dest);
            }
            //add line from source -> dest
            vertexMap.GetValueOrDefault(source).adj.AddLast(new Edge(vertexMap.GetValueOrDefault(dest), cost));
            //add line from dest -> source -> I dunno if this should be implemented 🤷🏽‍♂️

        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (var vertex in vertexMap)
            {
                vertex.Value.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            Queue<Vertex> vQueue = new Queue<Vertex>();

            foreach (var vertex in vertexMap)
            {
                vertex.Value.distance = System.Double.MaxValue;
            }

            vertexMap.GetValueOrDefault(name).distance = 0;

            vQueue.Enqueue(vertexMap.GetValueOrDefault(name));

            while (vQueue.Count != 0)
            {
                Vertex v = vQueue.Dequeue();
                //loop through all the available edges in the vertex
                foreach (Edge e in v.adj)
                {
                    if (e.dest.distance == System.Double.MaxValue)
                    {
                        e.dest.distance = v.distance + 1;
                        e.dest.prev = v;
                        vQueue.Enqueue(e.dest);
                    }
                }
            }

        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            PriorityQueue<Vertex> pvQueue = new PriorityQueue<Vertex>();

            foreach (var vertex in vertexMap)
            {
                vertex.Value.distance = System.Double.MaxValue;
                vertex.Value.prev = null;
                vertex.Value.known = false;
            }

            vertexMap.GetValueOrDefault(name).distance = 0;

            pvQueue.Add(vertexMap.GetValueOrDefault(name));

            while (pvQueue.Size() > 0)
            {
                Vertex v = pvQueue.Remove();

                v.known = true;

                foreach (Edge e in v.adj)
                {
                    Vertex w = e.dest;

                    if (w.known == false)
                    {
                        if (v.distance + e.cost < w.distance)
                        {
                            w.distance = v.distance + e.cost;
                            w.prev = v;
                        }
                        pvQueue.Add(w);
                    }
                }
            }


        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {

            string text = "";

            foreach (string key in vertexMap.Keys.OrderBy(x => x))
            {
                text += $"{vertexMap.GetValueOrDefault(key)} \n";
            }

            return text;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------



        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }

    }
}