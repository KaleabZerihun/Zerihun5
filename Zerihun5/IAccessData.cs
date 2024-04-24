/********************************************************************
*** NAME : Kaleab Zerihun
*** CLASS : CSc 346
*** ASSIGNMENT : Assignment 5
*** DUE DATE : 04-24-24
*** INSTRUCTOR : GAMRADT
*********************************************************************
*** DESCRIPTION : the IAccessData interface has a GetData method that reads
data from a file.  ***
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphNS
{
    public interface IAccessData
    {
        private void GetData(string path) {}
    }
}