using System.Globalization;

namespace Accounting;

/// <summary>
/// Value object for future balance (e.g. different currencies) system implementation (just a double so far).
/// </summary>
public class Balance(double value)
{
    // Setter is public, because this is purely a value object
    public double Value { get; set; } = value;

    public static implicit operator Balance(double num)
    {
        return new Balance(num) ;
    }
}