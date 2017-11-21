using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Cibertec.Mvc
{
    public class CustomerHub : Hub
    {        
        public void Message(string message)
        {
            Clients.All.getMessage(message);
        }
    }
}