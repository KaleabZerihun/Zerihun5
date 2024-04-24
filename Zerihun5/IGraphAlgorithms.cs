/********************************************************************
*** NAME : Kaleab Zerihun
*** CLASS : CSc 346
*** ASSIGNMENT : Assignment 5
*** DUE DATE : 04-24-24
*** INSTRUCTOR : GAMRADT
*********************************************************************
*** DESCRIPTION : the IGraphAlgorithms interface has methods for 
breadth-first and depth-first search algorithms on a graph
data from a file.  ***
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphNS
{
    public interface  IGraphAlgorithms
    {
        Queue<Vertex> GAQueue{ get{ return GAQueue;} set{ GAQueue = value;} }

        Stack<Vertex> GAStack{ get{ return GAStack;} set{ GAStack = value;} }

        public void BFS(int start);
        public void DFS(int start);
    }
}