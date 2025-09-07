using VeridiCore.Domain.Common;
using VeridiCore.Domain.Enums;

namespace VeridiCore.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public CategoryType Type { get; private set; }
    public Guid UserId { get; private set; }

    private Category() { }

    private Category(string name, string? description, CategoryType type, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        Description = description;
        Type = type;
        UserId = userId;
    }

    public static Category Create(string name, string? description, CategoryType type, Guid userId)
    {
        var category = new Category(name, description, type, userId);
        return category;
    }

    public void Update(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        DeletedAt = DateTime.UtcNow;
    }
}