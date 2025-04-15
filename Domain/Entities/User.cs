using TheUltimateStrictLibrary.DataTypes;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public string Email { get; set; } = string.Empty;
}
