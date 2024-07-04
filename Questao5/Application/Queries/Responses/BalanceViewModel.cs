namespace Questao5.Application.Queries.Responses
{
    public class BalanceViewModel
    {
        public string Saldo { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataHora { get; set; }

        public BalanceViewModel()
        {
            DataHora = DateTime.Now.ToString();
        }
    }
}
