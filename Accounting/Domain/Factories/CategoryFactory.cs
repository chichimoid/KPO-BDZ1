namespace Accounting;

public class CategoryFactory
{
    public Category Create(Id id, string name, CategoryType type)
    {
        if (name == null || name.Length < 2)
        {
            throw new ArgumentException("Name must be at least 2 characters long");
        }
        return new Category(id, name, type);
    }
}