namespace API.DTOs;

public record ProgramDto
{
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; } = false;
    public DateTime? CreationDate { get; set; }
}
