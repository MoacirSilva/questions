using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class MoveAccount
    {
        public Guid Id { get; set; }
        public virtual Guid IdCheckingAccount { get; set; } 
        public virtual CheckAccount CheckAccount { get; set; }
        public string MovementType { get; set; }
        public DateTime MoveTime { get; set; }
        public decimal Valor { get; set; }

        public MoveAccount()
        {
            CheckAccount = new CheckAccount();
            MovementType = string.Empty;
            MoveTime = new DateTime();
        }

        public MoveType MoveType 
        {
            get 
            {
                if (MovementType.Trim() == "C")
                    return MoveType.Credit;
                else
                {
                    return MoveType.Debit;
                }
            } 
        }

        
    }
}
