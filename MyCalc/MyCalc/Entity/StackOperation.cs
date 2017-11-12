using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc.Entity
{
    public class StackOperation
    {
        private char[] box;
        private int top = 0;
        private int bottom = 0;

        public StackOperation(int Size)
        {
            box = new char[Size];
        }

        /// <summary>
        /// Adds the item to the stack.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Push(char t)
        {
            if (top >= box.Length)
            {
                return false;
            }
            box[top++] = t;
            return true;
        }

        /// <summary>
        /// Pops the value from the stack.
        /// </summary>
        /// <returns></returns>
        public char Pop()
        {
            char result = ' ';
            if (top < 1)
            {
                return result;
            }
            result = box[--top];
            return result;
        }

        /// <summary>
        /// Gets the top value.
        /// </summary>
        /// <returns></returns>
        public char ViewTop()
        {
            return box[top - 1];
        }
    }
}
