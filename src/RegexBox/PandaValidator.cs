﻿using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RegexBox;

public static class PandaValidator
{
    private static readonly TimeSpan RegexTimeout = TimeSpan.FromMilliseconds(50);

    private static readonly Regex Email =
        new Regex(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);

    private static readonly Regex Username =
        new Regex(@"^[a-zA-Z0-9_]{5,15}$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);


    private static readonly Regex PandaFormattedPhoneNumber =
        new Regex(@"^\(\d{1,5}\)\d{4,15}$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);


    //Credit card is commented out as 4 tests are not passing for an unknown reason! Via https://regex101.com/ everything passes.
    // private static readonly Regex CreditCardNumber =
    //     new Regex(
    //         @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|35\d{14})$",
    //         RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);


    private static readonly Regex UsSocialSecurityNumber =
        new Regex(
            @"^4[0-9]{12}(?:[0-9]{3})?$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);

    private static readonly Regex ArmeniaSocialSecurityNumber =
        new Regex(@"^(\d{10}|Տ\d{3}\/\d{5}|S\d{3}A\d{5})$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);

    private static readonly Regex ArmeniaIdCard =
        new Regex(@"^\d{9}$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);

    private static readonly Regex ArmeniaPassportNumber =
        new Regex(@"^([A-Z]{2}\d{7}|\d{9})$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);

    private static readonly Regex ArmeniaTaxCode =
        new Regex(@"^\d{8}$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);

    private static readonly Regex ArmeniaStateRegistryNumber =
        new Regex(@"^\d{3}\.\d{3}\.\d{5,10}$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled, RegexTimeout);


    public static bool IsUri(string uri, bool allowNonSecure = true)

    {
        Uri.TryCreate(uri, UriKind.Absolute, out var parsedUri);

        if (parsedUri is null)
        {
            return false;
        }

        if (!allowNonSecure && parsedUri.Scheme == Uri.UriSchemeHttp)
        {
            return false;
        }

        return true;
    }

    public static bool IsUsSocialSecurityNumber(string number)
    {
        return UsSocialSecurityNumber.IsMatch(number);
    }

    public static bool IsEmail(string email)
    {
        return Email.IsMatch(email);
    }

    public static bool IsUsername(string userName)
    {
        return Username.IsMatch(userName);
    }

    public static bool IsArmeniaSocialSecurityNumber(string socialCardNumber)
    {
        return ArmeniaSocialSecurityNumber.IsMatch(socialCardNumber);
    }

    public static bool IsArmeniaIdCard(string idCard)
    {
        return ArmeniaIdCard.IsMatch(idCard);
    }

    public static bool IsArmeniaPassportNumber(string passportNumber)
    {
        return ArmeniaPassportNumber.IsMatch(passportNumber);
    }

    public static bool IsArmeniaTaxCode(string taxCode)
    {
        return ArmeniaTaxCode.IsMatch(taxCode);
    }

    public static bool IsArmeniaStateRegistryNumber(string stateRegistryNumber)
    {
        return ArmeniaStateRegistryNumber.IsMatch(stateRegistryNumber);
    }

    public static bool IsPandaFormattedPhoneNumber(string phoneNumber)
    {
        return PandaFormattedPhoneNumber.IsMatch(phoneNumber);
    }

    public static bool IsGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    }

    public static bool IsIPv4(string ipv4)
    {
        return IPAddress.TryParse(ipv4, out var address) && address.AddressFamily == AddressFamily.InterNetwork;
    }

    public static bool IsIPv6(string ipv6)
    {
        return IPAddress.TryParse(ipv6, out var address) && address.AddressFamily == AddressFamily.InterNetworkV6;
    }

    public static bool IsIpAddress(string ipAddress)
    {
        return IPAddress.TryParse(ipAddress, out _);
    }

    public static bool IsJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return false;
        try
        {
            using var doc = JsonDocument.Parse(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}