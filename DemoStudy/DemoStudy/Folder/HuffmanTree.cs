using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStudy.Folder
{
    public class HuffmanTree
    {
        public  int Weight;
        public int Parent, LChild, Rchild;
    }

    public class HuffmanCode 
    {
        public char[] code;

        public HuffmanCode(int length)
        {
            code = new char[length];
        }
    }
}
