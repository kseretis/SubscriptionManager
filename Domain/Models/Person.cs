using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheUltimateStrictLibrary.DataTypes;

namespace Domain.Models;

[Table("Persons", Schema = "mainApp")]
public class Person
{
    [Key]
    public int Id { get; set; }

    public required Name FirstName { get; set; }

    public Name? MiddleName { get; set; }

    public required Name LastName { get; set; }

    [ForeignKey("Id")]
    public int UserId { get; set; }
    
    public User User { get; set; } = null!;

    public required DateOnly DateOfBirth { get; set; }

    public required int Age { get; set; }
}
