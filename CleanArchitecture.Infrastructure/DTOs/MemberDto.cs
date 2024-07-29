namespace CleanArchitecture.Infrastructure.DTOs;

public class MemberDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? About { get; set; }
    public DateTime BirthDate { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public decimal Salary { get; set; }
}