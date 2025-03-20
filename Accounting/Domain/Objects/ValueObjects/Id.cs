namespace Accounting;

/// <summary>
/// Value object for future id system implementation (just an int so far).
/// </summary>
public class Id(int value)
{
    // Setter is public, because this is purely a value object
    public int Value { get; set; } = value;

    public static implicit operator Id(int num)
    {
        return new Id(num);
    }
}