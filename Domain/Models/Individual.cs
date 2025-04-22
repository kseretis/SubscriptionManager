using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheUltimateStrictLibrary.DataTypes;

namespace Domain.Models;

[Table("Individuals", Schema = "mainApp")]
public class Individual
{
    [Key]
    public int Id { get; set; }

    public Name FirstName { get; set; } = null!;

    public Name? MiddleName { get; set; }

    public Name LastName { get; set; } = null!;

    [ForeignKey("Id")]
    public int UserId { get; set; }
    
    public User User { get; set; } = null!;
}
