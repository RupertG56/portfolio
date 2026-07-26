namespace Portfolio.Contracts.Common;


public class ResponseDto
{
	public bool Success { get; set; }
	public string? ErrorMessage { get; set; }
	public static ResponseDto SuccessResult()
	{
		return new ResponseDto
		{
			Success = true
		};
	}
	public static ResponseDto FailureResult(string errorMessage)
	{
		return new ResponseDto
		{
			Success = false,
			ErrorMessage = errorMessage
		};
	}
}


public class ResponseDto<T> : ResponseDto
{
    public T? Data { get; set; }

    public static ResponseDto<T?> SuccessResult(T? data)
    {
        return new ResponseDto<T?>
        {
            Success = true,
            Data = data
        };
    }

	public static new ResponseDto<T?> FailureResult(string errorMessage)
	{
		return new ResponseDto<T?>
		{
			Success = false,
			ErrorMessage = errorMessage
		};
	}
}