using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphNS
{
    public class Vertex
    {
        public int Number { get; set; }
        public bool Visited { get; set; }

        public List<bool>? AdjVertices { get; set; }
    }
}