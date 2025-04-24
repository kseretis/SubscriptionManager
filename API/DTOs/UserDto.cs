namespace API.DTOs;

public record UserDto
{
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? CreationDate { get; set; }
}