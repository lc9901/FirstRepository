using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib;

namespace ImplementService
{
    public class WcfTestService : IWcfService
    {

        public int Operations(int numberA, int numberB, char operators)
        {
            switch (operators)
            {
                case '+':
                    return numberA + numberB;
                case '-':
                    return numberA - numberB;
                case '*':
                    return numberA * numberB;
                default :
                    return numberA / numberB;
            }
        }
    }
}
