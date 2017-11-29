using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WCFTestClient.BLL
{
    public class CalcLogic
    {
        public int getresult(int a, int b, char op)
        {
            IChannelFactory<IWcfService> channel = new ChannelFactory<IWcfService>("calc");

            IWcfService proxy = channel.CreateChannel(new EndpointAddress("http://172.18.217.247:8000/calc"));

            int result = proxy.Operations(a, b, op);

            channel.Close();
            return result;

        }
    }
}
