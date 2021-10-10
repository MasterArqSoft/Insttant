using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Middlewares
{
    public class GlobalErrorException
    {
        private readonly RequestDelegate _next;

        public GlobalErrorException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case CoreException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case InfrastructureException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.Errors = e.Errors;
                        break;

                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonConvert.SerializeObject(responseModel, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                await response.WriteAsync(result).ConfigureAwait(false);
            }
        }
    }
}