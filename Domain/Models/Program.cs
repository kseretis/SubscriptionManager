using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

[Table("Programs", Schema = "mainApp")]
[Comment("Represents the type of programs an organazation can have to provide some services, eg: a gym could provide a Functional or a Crossfit program")]
public class Program
{
    [Key]
    public int Id { get; set; }
    
    public required string Name { get; set; }

    public required bool IsActive { get; set; } = false;
    
    public required DateTimeOffset CreationDate { get; set; }
}
