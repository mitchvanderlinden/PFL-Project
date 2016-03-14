using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFLOrderApp
{
    public class APIError
    {

        public string dataElement
        {
            get;
            set;
        }
        public List<string> dataElementErrors
        {
            get;
            set;
        }

    }
}