# Pandatech.RegexBox

Pandatech.RegexBox is a highly performant and robust C# library designed to simplify complex regex validations for
various data formats. With 100% test coverage and a focus on security through a 50ms regex execution timeout, it's an
ideal solution for applications requiring reliable and efficient data validation.

## Usage

To use Pandatech.RegexBox, simply add a reference to the package in your project and call the desired static validation
methods:

```csharp
using Pandatech.RegexBox;

// URI validation
bool isValidUri = PandaValidator.IsUri("http://example.com", allowNonSecure: false);

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

// Panda formatted phone number validation

bool isValidPandaFormattedPhoneNumber = PandaValidator.IsPandaFormattedPhoneNumber("(374)94810553");

// Guid validation
bool isValidGuid = PandaValidator.IsGuid("12345678-1234-1234-1234-123456789012");

// IPv4 validation
bool isValidIpv4 = PandaValidator.IsIPv4("192.168.1.1");

// IPv6 validation
bool isValidIpv6 = PandaValidator.IsIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334");

// Any IP validation
bool isValidIp = PandaValidator.IsIpAddress("192.168.1.1");

// Json validation
bool isValidJson = PandaValidator.IsJson("{\"name\":\"John\", \"age\":30}");

// and many more...
```

## License

PandaTech.RegexBox is licensed under the MIT License.