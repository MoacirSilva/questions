namespace Questao5.Domain.Entities
{
    public class CheckAccount
    {
        public CheckAccount()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int Number {  get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<MoveAccount> MoveAccounts { get; set; }= new List<MoveAccount>();
        public bool IsActive { get; set; }

    }
}
