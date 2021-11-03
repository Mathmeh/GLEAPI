using System;
using System.Linq;
using System.Threading.Tasks;
using GLE.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GLEAPI.MiddleWare
{
    public sealed class IsAutorizedMiddleware
    {
        private RequestDelegate next;

        public IsAutorizedMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, GLEContext gleCont)
        {
            Console.WriteLine(context.Request.Path);
            if ((context.Request.Path == "/User" || context.Request.Path == "/User/Login") && context.Request.Method == "POST")
            {
                await next.Invoke(context);
            }

            else
            if (context.Request.Headers.TryGetValue("password", out var password) && context.Request.Headers.TryGetValue("id", out var id))
            {
                if (!int.TryParse(id, out var Id))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("unautorized");
                }
                else
                {
                    var user=await gleCont.Users.FirstOrDefaultAsync(user => user.Id == Id);
                    if (user!=null)
                    {
                        if (user.PasswordSaltedHashed == password)
                        {
                            await next.Invoke(context);
                        }
                        else
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("unautorized");
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("unautorized");
                    }
}
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("unautorized");
            }


        }
    }
}