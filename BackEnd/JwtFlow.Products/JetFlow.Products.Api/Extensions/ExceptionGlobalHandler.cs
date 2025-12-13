using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;

namespace JetFlow.Products.Api.Extensions;

public static class ExceptionGlobalHandler
{
    public static WebApplication  UseGlobalException(this WebApplication app)
        => (WebApplication)app.UseExceptionHandler(x
            => x.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var error = context.Features.Get<IExceptionHandlerFeature>();

                if (error is not null)
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        Menssage = error.Error.Message,
                        StackTrace = error.Error.StackTrace,
                        StatusCode = context.Response.StatusCode
                    }));
            }));
}