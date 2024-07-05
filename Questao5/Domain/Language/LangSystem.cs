using AutoMapper.Internal;
using Questao5.Infrastructure.Cross;
namespace Questao5.Domain.Language

{

    public enum LanguageChoice
    {

        Portuguese = 1,
        Ingles = 2,

    }
    public class LangSystem : ILangSystem
    {

        readonly IConfiguration _configuration;

        LanguageChoice _languageChoice;
        public LangSystem(IConfiguration configuration)
        {
            _configuration = configuration;
            ChoiceLanguage();
        }

        void ChoiceLanguage()
        {
            string languageString = _configuration.GetValue<string>("Language");
            if (!Enum.TryParse(languageString, true, out _languageChoice))
            {                
                _languageChoice = LanguageChoice.Portuguese;
            }
        }

        public string SuccessMessage()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Dados Atualizados com Sucesso";
                case LanguageChoice.Ingles:
                    return "Data Updated Successfully";
                default:
                    return "Dados Atualizados com Sucesso";
            }
        }

        public string ErrorMessage()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Ops Houve Algum Problema.";
                case LanguageChoice.Ingles:
                    return "Oops there was a problem";
                default:
                    return "Dados Atualizados com Sucesso";
            }
        }

        public string InvalidAccount()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção conta corrente não cadastrada";
                case LanguageChoice.Ingles:
                    return "Attention not registered checking account";
                default:
                    return "Atenção conta corrente não cadastrada";
            }
        }

        public string InvalidValue()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção valor inválido";
                case LanguageChoice.Ingles:
                    return "Attention invalid value";
                default:
                    return "Dados Atualizados com Sucesso";
            }
        }

        public string InactiveAccount()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção conta inativa";
                case LanguageChoice.Ingles:
                    return "Attention inactive account";
                default:
                    return "Atenção conta inativa";
            }
        }

        public string InvalidType()
        {
            switch (_languageChoice)
            {
                case LanguageChoice.Portuguese:
                    return "Atenção tipo da movimentação inválido";
                case LanguageChoice.Ingles:
                    return "Warning Invalid move type";
                default:
                    return "Atenção tipo da movimentação inválido";
            }
        }
    }
}
