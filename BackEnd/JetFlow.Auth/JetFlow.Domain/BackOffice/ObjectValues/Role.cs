using JetFlow.Domain.BackOffice.Entities.Contracts;

namespace JetFlow.Domain.BackOffice.ObjectValues;

public class Role : Entity
{
    public string Title { get; set; }
    public Guid UserId { get; set; }
}