namespace Writer.Common;

public abstract record Result
{
    public bool Success { get; protected set; }
    public bool Failure => !Success;
}

public abstract record Result<T> : Result
{
    public T Value { get; }

    protected Result(T value)
    {
        Value = value;
    }

}

public record SuccessResult : Result
{
    public SuccessResult()
    {
        Success = true;
    }
}

public record SuccessResult<T> : Result<T>
{
    public SuccessResult(T value) : base(value)
    {
        Success = true;
    }
}

public record ErrorResult : Result
{
    public ErrorResult(string message)
    {
        Message = message;
        Success = false;
    }

    public string Message { get; }
}

public record ErrorResult<T> : Result<T>
{
    public ErrorResult(T value, string message) : base(value)
    {
        Message = message;
        Success = false;
    }

    public string Message { get; }
}
