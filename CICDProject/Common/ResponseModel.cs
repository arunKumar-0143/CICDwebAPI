namespace CICDProject.Common;

public class ResponseModel<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ResponseModel<T> SuccessResponse(T data, string message = ResponseConstants.SUCCESS_FETCH)
    {
        return new ResponseModel<T>
        {
            IsSuccess = true,
            Message = message,
            Data = data,
            Errors = null
        };
    }

    public static ResponseModel<T> FailureResponse(string message, List<string>? errors = null)
    {
        return new ResponseModel<T>
        {
            IsSuccess = false,
            Message = message,
            Data = default,
            Errors = errors
        };
    }
}
