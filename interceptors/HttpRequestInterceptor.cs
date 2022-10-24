using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using System.Security.Claims;

namespace hot_demo.interceptors;

public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    public override ValueTask OnCreateAsync(HttpContext context,
        IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        Console.WriteLine(context.User.Identity);


        return base.OnCreateAsync(context, requestExecutor, requestBuilder,
            cancellationToken);
    }
}