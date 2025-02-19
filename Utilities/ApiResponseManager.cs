using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Utilities
{
    public static class ApiResponseManager
    {
        private static RestResponse _response;

        public static RestResponse Response
        {
            get => _response;
            set => _response = value;
        }
    }
}
