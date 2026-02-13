using System.Text.Json.Serialization;

namespace Shared;

public record Error
{
    public string Code { get; }
    public string Message { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; }
    public string? InvalidField { get; }

    [JsonConstructor]
    private Error(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }

    public static readonly Error None = new Error(string.Empty, string.Empty, ErrorType.None, string.Empty);

    public static Error NotFound(string? code, string message, Guid? id) =>
        new(code ?? "record.not.found", message, ErrorType.NotFound);

    public static Error Validation(string? code, string message, string? invalidField) =>
        new(code ?? "value.is.invalid", message, ErrorType.Validation, invalidField);

    public static Error Conflict(string? code, string message) =>
        new(code ?? "value.is.conflict", message, ErrorType.Conflict);

    public static Error Failure(string? code, string message) =>
        new(code ?? "failure", message, ErrorType.Failure);
    
    public Failure ToFailure() => this;
}

public enum ErrorType
{
    /// <summary>
    /// Нет ошибки/ошибка неизвестна
    /// </summary>
    None,
    
    /// <summary>
    /// Ошибка валидации
    /// </summary>
    Validation,

    /// <summary>
    /// Не найдено
    /// </summary>
    NotFound,

    /// <summary>
    /// Конфликт в базе данных
    /// </summary>
    Conflict,

    /// <summary>
    /// Необрабатываемое исключение
    /// </summary>
    Failure
}