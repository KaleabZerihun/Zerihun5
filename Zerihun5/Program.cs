/********************************************************************
*** NAME : Kaleab Zerihun
*** CLASS : CSc 346
*** ASSIGNMENT : Assignment 5
*** DUE DATE : 04-24-24
*** INSTRUCTOR : GAMRADT
*********************************************************************
*** DESCRIPTION : se Visual Studio Code to create a user-defined Abstract Data Type (ADT) using C# classes named Graph,
Vertex and interfaces IAccessData, IGraphAlgorithms and an appropriate set of C# files as discussed in class ***
********************************************************************/
using System;
using static System.Console;

namespace GraphNS
{
    class Program
    {

        static void Main()
        {
            Graph kb = new Graph("C:\\Users\\Kalea\\Documents\\Projects\\Zerihun5\\Zerihun5\\Kaleab.json");
            kb.BFS(0);
            kb.DFS(0);
            
    
        }
    }
}

