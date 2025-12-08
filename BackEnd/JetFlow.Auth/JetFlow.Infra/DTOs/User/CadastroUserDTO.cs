using System.ComponentModel.DataAnnotations;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JetFlow.Infra.DTOs.User;

public class CadastroUserDTO
{
    
    public string Name { get;set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public static implicit operator Domain.BackOffice.Entities.User(CadastroUserDTO userDto)
        =>new Domain.BackOffice.Entities.User(userDto.Name, new Email(userDto.Email), userDto.Password);
    
}