using VeridiCore.Domain.Enums;

namespace VeridiCore.API.Contracts.Categories;

public record CreateCategoryRequest(string Name, string? Description, CategoryType Type);