namespace MyBank.Services;

public class ServiceResult<T>
{
    public T? Data { get; set; }
    public List<string>? ErrorMessage { get; set; }
    public bool IsSuccess => ErrorMessage is null || ErrorMessage.Count == 0;
    public bool IsFail => !IsSuccess;
}
