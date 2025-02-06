using System.Net;

namespace MyBank.Services;

public class ServiceResult<T>
{
    public T? Data { get; set; }
    public List<string>? ErrorMessage { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public bool IsSuccess => ErrorMessage is null || ErrorMessage.Count == 0;
    public bool IsFail => !IsSuccess;

    public static ServiceResult<T> Success(T data, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        return new ServiceResult<T>()
        {
            Data = data,
            HttpStatusCode = httpStatusCode
        };
    }

    public static ServiceResult<T> Fail(List<string> errorMessages, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>()
        {
            ErrorMessage = errorMessages,
            HttpStatusCode = httpStatusCode
        };
    }

    public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>()
        {
            ErrorMessage = new List<string>() { errorMessage },
            HttpStatusCode = httpStatusCode
        };
    }
}
public class ServiceResult
{
    public List<string>? ErrorMessage { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public bool IsSuccess => ErrorMessage is null || ErrorMessage.Count == 0;
    public bool IsFail => !IsSuccess;

    public static ServiceResult Success(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        return new ServiceResult()
        {
            HttpStatusCode = httpStatusCode
        };
    }

    public static ServiceResult Fail(List<string> errorMessages, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult()
        {
            ErrorMessage = errorMessages,
            HttpStatusCode = httpStatusCode
        };
    }

    public static ServiceResult Fail(string errorMessage, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult()
        {
            ErrorMessage = new List<string>() { errorMessage },
            HttpStatusCode = httpStatusCode
        };
    }
}