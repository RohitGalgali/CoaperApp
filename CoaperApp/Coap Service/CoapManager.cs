using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoAP;

namespace CoaperApp.Coap_Service
{
    class CoapManager
    {
        public void Send(Request req)
        {
            req.Send();
        }
    }
}
