using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using NetworkMarketingCore.Contracts.Attributes;

namespace MarketingAPI
{
    public class RequiredFieldFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameters = context.ActionArguments.ToList().Select(i => i.Value);

            foreach (var parameter in parameters)
            {
                var type = parameter.GetType();
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var requiredFieldAttributes =
                        property.GetCustomAttributes(typeof(RequiredFieldAttribute), false).ToList();

                    if (!requiredFieldAttributes.Any()) continue;

                    if (property.GetValue(parameter) is null || 
                        (property.PropertyType == typeof(string) && ((string)property.GetValue(parameter)).IsNullOrEmpty()))
                    {
                        context.Result = new BadRequestObjectResult("Please Fill Required Fields");
                        return;
                    }
                }
            }

            await next.Invoke();

        }
    }
}
