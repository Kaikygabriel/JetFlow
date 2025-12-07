namespace JetFlow.Domain.BackOffice.Exception;

public class EmailException : ApplicationException
{
    private const string MENSSAGE_DEFAULT = "Email invalid";
    public EmailException(string menssage = MENSSAGE_DEFAULT) : base(menssage){}
}