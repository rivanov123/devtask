using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TeamRankings.Extensions;

namespace TeamRankings.Filters
{
    public class AjaxErrorHandleFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public AjaxErrorHandleFilter (IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled || !context.HttpContext.Request.IsAjaxRequest())
            {
                return;
            }

            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var viewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
            {
                Model = context.Exception.Message
            };
            var result = new PartialViewResult
            {
                ViewName = @"~/Views/Shared/Error.cshtml",
                ViewData = viewData
            };
            context.Result = result;
        }
    }
}
