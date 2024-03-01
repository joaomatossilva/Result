namespace Kspace.Result;

public static class Result
{
    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
}