using System.Text.Json.Serialization;

namespace Shared;

public record Envelope
{
    public object? Result { get; }
    
    public Failure? Failure { get; }
    
    public bool IsError => Failure != null || (Failure != null && Failure.Any());
    
    public DateTime Timestamp { get; }
    
    [JsonConstructor]
    public Envelope(object? result, Failure? failure)
    {
        Result = result;
        Failure = failure;
        Timestamp = DateTime.UtcNow;
    }
    
    public static Envelope Ok(object? result) => new(result, null);
    
    public static Envelope Error(Failure? failure) => new(null, failure);
}

public record Envelope<T>
{
    public T? Result { get; }
    
    public Failure? Failure { get; }
    
    public bool IsError => Failure != null || (Failure != null && Failure.Any());
    
    public DateTime Timestamp { get; }
    
    [JsonConstructor]
    public Envelope(T? result, Failure? failure)
    {
        Result = result;
        Failure = failure;
        Timestamp = DateTime.UtcNow;
    }
    
    public static Envelope<T> Ok(T? result) => new(result, null);
    
    public static Envelope<T> Error(Failure? failure) => new(default, failure);
}