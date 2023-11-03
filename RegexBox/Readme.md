# Pandatech.RegexBox

## Introduction
Pandatech.RegexBox is a .NET library that provides a set of regular expressions for common data validation tasks. It includes regex patterns for validating email addresses, usernames, URLs, IP addresses (both IPv4 and IPv6), US Social Security Numbers, and Armenian Social Security Numbers.

## Features
* **Email Validation:** You can use the `PandaValidator.IsEmail(string email)` method to check if a given string is a valid email address.
* **Username Validation:** The library provides the `PandaValidator.IsUsername(string userName)` method to validate usernames according to a defined pattern.
* **URL Validation:** You can validate URLs using the `PandaValidator.IsUri(string uri, bool allowWildcards, bool allowNonSecure)` method. It supports wildcards and secure/non-secure URLs.
* **IP Address Validation:** The library offers methods to validate both IPv4 and IPv6 addresses using `PandaValidator.IsIpAddress(string ip, bool isIpv4)`.
* **US Social Security Number Validation:** The `PandaValidator.IsUsSocialSecurityNumber(string number)` method allows you to check if a string matches the pattern for a US Social Security Number.
* **Armenian Social Security Number Validation:** You can validate Armenian Social Security Numbers using `PandaValidator.IsArmenianSocialSecurityNumber(string socialCardNumber)`.

## How to Use
Here's an example of how to use Pandatech.RegexBox for email validation:
```csharp
using Pandatech.RegexBox;

string email = "example@email.com";
if (PandaValidator.IsEmail(email))
{
    Console.WriteLine("Valid email address.");
}
else
{
    Console.WriteLine("Invalid email address.");
}
```
# Note
* The library is designed for easy integration into your .NET projects.
* The library has best performance and security practices in mind.
* This library has 100% code coverage.
* Will be ongoing updated and maintained.

## License

PandaTech.RegexBox is licensed under the MIT License.