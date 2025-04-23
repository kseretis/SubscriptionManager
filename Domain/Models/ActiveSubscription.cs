using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models;

[Table("ActiveSubscription", Schema = "mainApp")]
public class ActiveSubscription
{
    [Key]
    public int Id { get; set; }

    public required DateTimeOffset StartingDate { get; set; }

    public required DateTimeOffset EndingDate { get; set; }

    public required Subscription SubscriptionType { get; set; } = Subscription.Simple;

    [ForeignKey("Id")]
    public int PersonId { get; set; }

    public Person Person { get; set; } = null!;

    public string? Comment { get; set; }
}
