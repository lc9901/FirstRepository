using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementService;
using System.ServiceModel;
using System.Threading;

namespace WcfTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WcfTestService)))
            {

                host.Opened += host_Opened;
                host.Open();

                
                Thread.Sleep(-1);
                host.Close();
            }
        }

        static void host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("服务已启动" + System.DateTime.Now.ToString());
        }
    }
}
