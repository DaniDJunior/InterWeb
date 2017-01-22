using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterWeb.Web.Controllers
{
    public class TokenController : ApiController
    {

        public class MachineInfo
        {
            public string CPUID { get; set; }
            public string DiskID { get; set; }
            public string MACID { get; set; }
            public string IP { get; set; }
            public string IPOut { get; set; }
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Código");
        }

        public HttpResponseMessage Post([FromBody]MachineInfo value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Código");
        }

    }
}
