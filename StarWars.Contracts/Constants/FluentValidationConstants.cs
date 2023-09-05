namespace StarWars.Contracts.Constants;

/// <summary>
///     Константы используемые при валидации
/// </summary>
public static class FluentValidationConstants
{
    public const string EmptyPropertyErrorMessage = "Поле '{PropertyName}' не может быть пустым";
    
    public const string InvalidPropertyErrorMessage = "Некорректное значение поля '{PropertyName}'";
}