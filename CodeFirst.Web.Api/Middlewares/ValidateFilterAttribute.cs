using CodeFirst.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Middlewares
{
    public class ValidateFilterAttribute : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                (string Key, IEnumerable<string>)[] prueba = context.ModelState
                                    .Where(x => x.Value.Errors.Count > 0).Select(x => (x.Key, x.Value.Errors.Select(x => x.ErrorMessage))).ToArray();

                List<string> Errors = new();

                foreach ((string Key, IEnumerable<string>) item in prueba)
                {
                    foreach (string item2 in item.Item2)
                    {
                        Errors.Add(item2);
                    };
                }
                if (Errors.Count != 0)
                {
                    throw new ValidationException(Errors);
                }
            }

            await next();
        }
    }
}