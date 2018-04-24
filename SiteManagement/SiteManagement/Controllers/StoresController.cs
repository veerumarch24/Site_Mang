using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace SiteManagement.Controllers
{
    public class StoresController : ApiController
    {

        Stores store = new Stores();

        public class Params
        {
            public string info { get; set; }
        }



    }
}
