namespace CICDProject.Common;

public static class ResponseConstants
{
    public const string SUCCESS_FETCH = "Data retrieved successfully.";
    public const string SUCCESS_CREATE = "Record created successfully.";
    public const string SUCCESS_UPDATE = "Record updated successfully.";
    public const string SUCCESS_DELETE = "Record deleted successfully.";
    public const string RECORD_NOT_FOUND = "Requested record was not found.";
    public const string INVALID_INPUT = "Invalid request payload provided.";
    public const string INTERNAL_SERVER_ERROR = "An unexpected error occurred while processing the request.";
}
