namespace Talantix.Core.Domain.Common;

public class DomainException : Exception
{
    public DomainException(string text)
        : base(text) { }
}
