namespace StatAspect.Application.General.Validation;

/// <summary>
/// Represents a validation localization manager that overrides default error messages.
/// </summary>
public sealed class ValidationLocalizationManager : LanguageManager
{
    /// <summary>
    /// Initializes a new instance of <see cref="ValidationLocalizationManager"/>.
    /// </summary>
    public ValidationLocalizationManager()
    {
        AddTranslation("en", "EmailValidator", "{PropertyName} is not a valid email address.");
        AddTranslation("en", "GreaterThanOrEqualValidator", "{PropertyName} must be greater than or equal to {ComparisonValue}.");
        AddTranslation("en", "GreaterThanValidator", "{PropertyName} must be greater than {ComparisonValue}.");
        AddTranslation("en", "LengthValidator", "{PropertyName} must be between {MinLength} and {MaxLength} characters. You entered {TotalLength} characters.");
        AddTranslation("en", "MinimumLengthValidator", "The length of {PropertyName} must be at least {MinLength} characters. You entered {TotalLength} characters.");
        AddTranslation("en", "MaximumLengthValidator", "The length of {PropertyName} must be {MaxLength} characters or fewer. You entered {TotalLength} characters.");
        AddTranslation("en", "LessThanOrEqualValidator", "{PropertyName} must be less than or equal to {ComparisonValue}.");
        AddTranslation("en", "LessThanValidator", "{PropertyName} must be less than {ComparisonValue}.");
        AddTranslation("en", "NotEmptyValidator", "{PropertyName} must not be empty.");
        AddTranslation("en", "NotEqualValidator", "{PropertyName} must not be equal to {ComparisonValue}.");
        AddTranslation("en", "NotNullValidator", "{PropertyName} must not be empty.");
        AddTranslation("en", "PredicateValidator", "The specified condition was not met for {PropertyName}.");
        AddTranslation("en", "AsyncPredicateValidator", "The specified condition was not met for {PropertyName}.");
        AddTranslation("en", "RegularExpressionValidator", "{PropertyName} is not in the correct format.");
        AddTranslation("en", "EqualValidator", "{PropertyName} must be equal to {ComparisonValue}.");
        AddTranslation("en", "ExactLengthValidator", "{PropertyName} must be {MaxLength} characters in length. You entered {TotalLength} characters.");
        AddTranslation("en", "InclusiveBetweenValidator", "{PropertyName} must be between {From} and {To}. You entered {PropertyValue}.");
        AddTranslation("en", "ExclusiveBetweenValidator", "{PropertyName} must be between {From} and {To} (exclusive). You entered {PropertyValue}.");
        AddTranslation("en", "CreditCardValidator", "{PropertyName} is not a valid credit card number.");
        AddTranslation("en", "ScalePrecisionValidator", "{PropertyName} must not be more than {ExpectedPrecision} digits in total, with allowance for {ExpectedScale} decimals. {Digits} digits and {ActualScale} decimals were found.");
        AddTranslation("en", "EmptyValidator", "{PropertyName} must be empty.");
        AddTranslation("en", "NullValidator", "{PropertyName} must be empty.");
        AddTranslation("en", "EnumValidator", "{PropertyName} has a range of values which does not include {PropertyValue}.");
        AddTranslation("en", "Length_Simple", "{PropertyName} must be between {MinLength} and {MaxLength} characters.");
        AddTranslation("en", "MinimumLength_Simple", "The length of {PropertyName} must be at least {MinLength} characters.");
        AddTranslation("en", "MaximumLength_Simple", "The length of {PropertyName} must be {MaxLength} characters or fewer.");
        AddTranslation("en", "ExactLength_Simple", "{PropertyName} must be {MaxLength} characters in length.");
        AddTranslation("en", "InclusiveBetween_Simple", "{PropertyName} must be between {From} and {To}.");
    }
}