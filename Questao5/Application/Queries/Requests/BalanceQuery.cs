using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class BalanceQuery : IRequest<BalanceViewModel>
    {
        public int Numero { get; set; }
    }
}
