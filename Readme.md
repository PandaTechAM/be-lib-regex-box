# Pandatech.RegexBox

Pandatech.RegexBox is a highly performant and robust C# library designed to simplify complex regex validations for various data formats. With 100% test coverage and a focus on security through a 50ms regex execution timeout, it's an ideal solution for applications requiring reliable and efficient data validation.


## Usage

To use Pandatech.RegexBox, simply add a reference to the package in your project and call the desired static validation methods:

```csharp
using Pandatech.RegexBox;

// URI validation
bool isValidUri = PandaValidator.IsUri("http://example.com", allowWildcards: false, allowNonSecure: true);

// US Social Security Number validation
bool isValidSsnUs = PandaValidator.IsUsSocialSecurityNumber("123-45-6789");

// Email validation
bool isValidEmail = PandaValidator.IsEmail("user@example.com");

// Username validation
bool isValidUsername = PandaValidator.IsUsername("user123");

// Armenian Social Security Number validation
bool isValidSsnAm = PandaValidator.IsArmeniaSocialSecurityNumber("12345678912");

//ArmenianIDCard validation
bool isValidArmenianIdCard = PandaValidator.IsArmeniaIdCard("AN1234567");

// Armenian Passport validation
bool isValidArmenianPassport = PandaValidator.IsArmeniaPassport("AN1234567");

// Armenian Tax code validation
bool isValidArmenianTaxCode = PandaValidator.IsArmeniaTaxCode("12345678");

// Panda Formatted Phone Number validation
bool isValidPhoneNumber = PandaValidator.IsPandaFormattedPhoneNumber("(374)94810553");

// Armenian State Registration Number validation
bool isValidArmenianStateRegistrationNumber = PandaValidator.IsArmeniaStateRegistryNumber("123.456.78");

// and many more...
```

## License

PandaTech.RegexBox is licensed under the MIT License.