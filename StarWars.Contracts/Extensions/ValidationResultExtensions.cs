using FluentValidation.Results;

namespace StarWars.Contracts.Extensions;

/// <summary>
///     Расширения для <see cref="ValidationResult"/>
/// </summary>
public static class ValidationResultExtensions
{
    /// <summary>
    ///     Создать ошибку валидации
    /// </summary>
    /// <param name="validationResult"><see cref="ValidationResult"/></param>
    /// <param name="propertyName">Наименование поля</param>
    /// <param name="errorMessage">Текст ошибки</param>
    /// <param name="errorCode">Код ошибки</param>
    /// <returns></returns>
    public static ValidationResult CreateError(this ValidationResult validationResult, string propertyName, string errorMessage, string errorCode)
    {
        validationResult.Errors ??= new List<ValidationFailure>();
        validationResult.Errors.Add(new ValidationFailure { PropertyName = propertyName, ErrorMessage = errorMessage, ErrorCode = errorCode });
        return validationResult;
    }
}