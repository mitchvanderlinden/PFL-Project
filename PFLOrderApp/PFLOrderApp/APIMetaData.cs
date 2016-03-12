using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PFLOrderApp
{
    public class APIMetaData
    {

        public string time
        {
            get;
            set;
        }
        public HttpStatusCode statusCode
        {
            get;
            set;
        }

    }
}