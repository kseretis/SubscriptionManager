using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Users", Schema = "mainApp")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(100)")]
    public required string Username { get; set; }

    // TODO replae the string with EMail
    [Column(TypeName = "varchar(255)")]
    public required string Email { get; set; }
}
