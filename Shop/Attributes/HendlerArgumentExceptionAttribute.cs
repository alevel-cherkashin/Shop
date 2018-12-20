using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Shop.Attributes
{
    public class HendlerArgumentExceptionAttribute : Attribute, IExceptionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, 
                                                CancellationToken cancellationToken)
        {
            if (actionExecutedContext != null && actionExecutedContext.Exception is ArgumentException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                                                                        HttpStatusCode.BadRequest, "Check you argument");
            }
            return Task.FromResult<object>(null);
        }
    }
}