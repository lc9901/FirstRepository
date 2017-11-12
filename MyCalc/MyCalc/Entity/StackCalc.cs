using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc.Entity
{
    public class StackCalc
    {
        private int[] box;
        private int top = 0;
        private int bottom = 0;

        public StackCalc(int Size) 
        {
            box = new int[Size];
        }

        /// <summary>
        /// Adds the item to the stack.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Push(int t) 
        {
            if (top > box.Length) 
            {
                return false;
            }
            box[top++] = t;
            return true;
        }

        public int Pop()
        {
            int result = default(int); 
            if (top < 1) 
            {
                return result;
            }
            result = box[--top];
            return result;
        }

        public int ViewTop() 
        {
            return box[top - 1];
        }
    }
}
