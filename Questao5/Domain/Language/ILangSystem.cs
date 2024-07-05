namespace Questao5.Domain.Language
{
    public interface ILangSystem
    {
        string SuccessMessage();

        string ErrorMessage();

        string InvalidAccount();

        string InvalidValue();

        string InactiveAccount();

        string InvalidType();
    }
}
