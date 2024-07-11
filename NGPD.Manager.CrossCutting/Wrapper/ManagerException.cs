namespace NGPD.Manager.CrossCutting.Wrapper;

/// <summary>
/// Global exception utilized to throw application errors
/// Using Primary Constructor
/// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors
/// </summary>
/// <param name="message"></param>
/// <param name="statusCode"></param>
/// <param name="errors"></param>
/// <param name="errorCode"></param>
/// <param name="refLink"></param>
public class ManagerException(
    string message,
    int statusCode = 400,
    IEnumerable<ValidationError> errors = null,
    string errorCode = "",
    string refLink = "")
    : Exception(message)
{
    public int StatusCode { get; set; } = statusCode;

    public IEnumerable<ValidationError> Errors { get; set; } = errors;

    public string ReferenceErrorCode { get; set; } = errorCode;
    public string ReferenceDocumentLink { get; set; } = refLink;
}