using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc.Logic
{
    public class CalcUtils
    {
        private static int Convert(char a)
        {
            switch (a)
            {
                case '+':
                    return 0;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 3;
                case '(':
                    return 4;
                case ')':
                    return 5;
                case '#':
                    return 6;
                default:
                    return 7;
            }
        }

        /// <summary>
        /// Compares the level.
        /// </summary>
        /// <param name="a">The last one operation.</param>
        /// <param name="b">The current operation</param>
        /// <returns>
        /// The level of the last one operation is hight return 1;
        /// The level of the current operation is hight return -1;
        /// The operation need sub a ) return 0;
        /// The express error return 2;
        /// </returns>
        public static int Compare(char a, char b)
        {
            int x = Convert(a);
        	int y = Convert(b);
            int[,] count = {
        		{1,1,-1,-1,-1,1,1},
        		{1,1,-1,-1,-1,1,1},
        		{1,1,1,1,-1,1,1},
        		{1,1,1,1,-1,1,1},
        	    {-1,-1,-1,-1,-1,0,2},
        		{1,1,1,1,2,1,1},
        	    {-1,-1,-1,-1,-1,2,0}
        	};
        	return count[x,y];
        }


        internal static int ExcuteCalc(int number1, int number2, char operatorTop)
        {
            switch (operatorTop)
            {
                case '+':
                    return number1 + number2;
                case '-' :
                    return number1 - number2;
                case '*' :
                    return number1 * number2;
                case '/':
                    if (number2 == 0)
                    {
                        Exception e = new Exception("Express is wrong");
                    }
                    return number1 / number2;
                default:
                    return 0;
            }
        }
    }
}
