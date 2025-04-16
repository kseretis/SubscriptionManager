using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheUltimateStrictLibrary.DataTypes;

namespace Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public required Name Name { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Email { get; set; }
}
