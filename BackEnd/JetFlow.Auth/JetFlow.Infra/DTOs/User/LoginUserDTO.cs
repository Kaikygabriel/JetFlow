using System.ComponentModel.DataAnnotations;

namespace JetFlow.Infra.DTOs.User;

public class LoginUserDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(3)]
    public string Password { get; set; }
}