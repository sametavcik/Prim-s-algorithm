using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp28
{
    class Vertex
    {
        public List<Edge> neighbours;

        public Vertex()
        {
            neighbours = new List<Edge>();
        }
    }
}
