namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Handler;

public class GlobalExceptionHandler : IExceptionHandler
{

    #region TryHandleAsync

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
       var result =  Result<object>.Fail(exception);
        httpContext.Response.StatusCode = (int)EnumHttpStatusCode.Success;

        await httpContext.Response.WriteAsJsonAsync(result,cancellationToken);

        return true;
    }

    #endregion
}
