using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using ETag.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ETag.Misc
{
    public class ETagFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var reqHeaders = context.HttpContext.Request.Headers;
            if (reqHeaders.ContainsKey("If-None-Match"))
            {
                var etag = reqHeaders["If-None-Match"];
                var data = Data.GetData();
                if (data.Id == Int32.Parse(etag[0]))
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status304NotModified);
                }
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("ETag", Data.GetData().Id.ToString());
        }
    }
}