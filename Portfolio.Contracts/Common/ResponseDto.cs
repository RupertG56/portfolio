namespace Portfolio.Api.Common;

public class ResponseDto<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public static ResponseDto<T> SuccessResult(T data)
    {
        return new ResponseDto<T>
        {
            Success = true,
            Data = data
        };
    }

    public static ResponseDto<T> FailureResult(string errorMessage)
    {
        return new ResponseDto<T>
        {
            Success = false,
            ErrorMessage = errorMessage
        };
    }
}