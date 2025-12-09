using System.Diagnostics.CodeAnalysis;
using JetFlow.Domain.BackOffice.Exception;

namespace JetFlow.Domain.BackOffice.ObjectValues;

public struct Email
{
    public Email(string address)
    {
        if (!IsValidAddress(address))
            throw new EmailException("Invalid address format");
        Address = address;
    }
    public string Address { get; private set; }

    public bool IsValidAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || address.Length < 3 ||
            !address.Contains('@'))
            return false;
        return true;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (!(obj is string))
            return false;
        string email = (string)obj;
        return email.Equals(Address);
    }
}
