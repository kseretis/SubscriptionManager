namespace API.Helpers;

/// <summary>
/// A class that represents the result of an API response.
/// </summary>
public class ResponseResult
{
    // FIXME: If we can't return a different than 200 code with this object, then this status code might be useless
    public required int StatusCode { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public Exception? Exception { get; set; }
}

public static class ResponseResultBuilder
{
    /// <summary>
    /// Builds a new instance of <see cref="ResponseResult"/> with the specified parameters.
    /// </summary>
    /// <param name="statusCode">Use <see cref="StatusCodes"/> to declare a status code</param>
    /// <returns></returns>
    public static ResponseResult Build(int statusCode)
    {
        return new ResponseResult
        {
            StatusCode = statusCode
        };
    }

    /// <summary>
    /// Builds a new instance of <see cref="ResponseResult"/> with the specified parameters.
    /// </summary>
    /// <param name="statusCode">Use <see cref="StatusCodes"/> to declare a status code</param>
    /// <param name="message">An optional response message</param>
    /// <returns></returns>
    public static ResponseResult Build(int statusCode, string message)
    {
        return new ResponseResult
        {
            StatusCode = statusCode,
            Message = message
        };
    }

    /// <summary>
    /// Builds a new instance of <see cref="ResponseResult"/> with the specified parameters.
    /// </summary>
    /// <param name="statusCode">Use <see cref="StatusCodes"/> to declare a status code</param>
    /// <param name="data">A generic object</param>
    /// <param name="message">An optional response message</param>
    /// <returns></returns>
    public static ResponseResult Build(int statusCode, object data, string? message = null)
    {
        return new ResponseResult
        {
            StatusCode = statusCode,
            Data = data,
            Message = message
        };
    }

    /// <summary>
    /// Builds a new instance of <see cref="ResponseResult"/> with the specified parameters.
    /// </summary>
    /// <param name="statusCode">Use <see cref="StatusCodes"/> to declare a status code</param>
    /// <param name="exception">An exception</param>
    /// <param name="message">An optional response message</param>
    /// <returns></returns>
    public static ResponseResult Build(int statusCode, Exception exception, string? message = null)
    {
        return new ResponseResult
        {
            StatusCode = statusCode,
            Exception = exception,
            Message = message
        };
    }

    /// <summary>
    /// Builds a new instance of <see cref="ResponseResult"/> with the specified parameters.
    /// </summary>
    /// <param name="statusCode">Use <see cref="StatusCodes"/> to declare a status code</param>
    /// <param name="data">An optional generic response object</param>
    /// <param name="exception">An optional exception type (Only when an error occured)</param>
    /// <param name="message">An optional response message</param>
    /// <returns></returns>
    public static ResponseResult Build(int statusCode, object? data, Exception? exception, string? message = null)
    {
        return new ResponseResult
        {
            StatusCode = statusCode,
            Message = message,
            Data = data,
            Exception = exception
        };
    }
}
