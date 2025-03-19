using System.Net;

namespace Pandorax.Mot.Core;

public class MotHistoryResponse<T>(T? value, string rawJson, bool isSuccess, HttpStatusCode statusCode)
{
    public bool IsSuccess { get; } = isSuccess;
    public T? Value { get; } = value;
    public string? RawJson { get; } = rawJson;
    public HttpStatusCode StatusCode { get; } = statusCode;
}
