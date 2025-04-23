using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheUltimateStrictLibrary.DataTypes;

namespace Domain.Models;

[Table("Users", Schema = "mainApp")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(100)")]
    public required string Username { get; set; }

    public required EMail Email { get; set; }

    public PhoneNumber? PhoneNumber { get; set; }

    public required DateTimeOffset CreationDate { get; set; }
}
