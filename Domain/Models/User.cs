using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TheUltimateStrictLibrary.DataTypes;

namespace Domain.Models;

[Table("Users", Schema = "mainApp")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Comment("The name is passed through the Name class from the 'TheUltimateStrictLibrary' package")]
    public required Name Name { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Email { get; set; }
}
