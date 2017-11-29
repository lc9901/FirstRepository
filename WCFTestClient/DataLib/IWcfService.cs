using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        int Operations(int numberA, int numberB, char operators);
    }
}
