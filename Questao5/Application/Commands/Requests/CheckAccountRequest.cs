using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class CheckAccountRequest: IRequest<CheckAccountResponse>
    {
        public string MoveType { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
        public CheckAccountRequest() { }
    }
}
