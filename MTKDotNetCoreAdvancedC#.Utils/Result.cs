
namespace MTKDotNetCoreAdvancedC_.Utils;

#region Result

public class Result<T>
{
    public T Data { get; set; } 
    public EnumHttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } 
    public bool IsSuccess { get; set; }

    #region Success 

    public static Result<T> Success (string message = "Success")
    {
        return new Result<T>
        {
            Message = message,
            IsSuccess = true,
            StatusCode = EnumHttpStatusCode.Success
        };
    }

    #endregion

    #region Success with data

    public static Result<T> Success(T data, string message = "Success")
    {
        return new Result<T>
        {
            Data = data,
            Message = message,
            IsSuccess = true,
            StatusCode = EnumHttpStatusCode.Success
        };
    }

    #endregion

    #region Fail

    public static Result<T> Fail(string message = "Fail.",EnumHttpStatusCode statusCode = EnumHttpStatusCode.BadRequest)
    {
        return new Result<T>
        {
            Message = message,
            IsSuccess = false,
            StatusCode = statusCode
        };
    }

    #endregion

    #region Fail 

    public static Result<T> Fail(Exception ex)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = ex.ToString(),
            StatusCode = EnumHttpStatusCode.InternalServerError
        };
    }

    #endregion
}

#endregion
