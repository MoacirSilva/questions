using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Language;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Cross;
using AutoMapper;

namespace Questao5.Application.Handlers
{
    public class MoveCheckAccountHandler : IRequestHandler<CheckAccountRequest, CheckAccountResponse>
    {
        private readonly IBaseRepository<CheckAccount> _checkAccount;
        private readonly IBaseRepository<MoveAccount> _moveAccount;
        private readonly List<Notify> _notify;
        private readonly ILangSystem _langSystem;
        private readonly IMapper _mapper;

        public MoveCheckAccountHandler(IBaseRepository<CheckAccount> CheckAccount,
                                                     IBaseRepository<MoveAccount> MoveAccount,
                                                     List<Notify> Notify,
                                                     ILangSystem LangSystem,
                                                     IMapper mapper)
        {
            _checkAccount = CheckAccount;
            _moveAccount = MoveAccount;
            _notify = Notify ?? new List<Notify>();
            _langSystem = LangSystem;
            _mapper = mapper;
        }

        public async Task<CheckAccountResponse> Handle(CheckAccountRequest request, CancellationToken cancellationToken)
        {
            var resp = new CheckAccountResponse();

            var contaCorrente = await MovimentIsValid(request);
            if (_notify.Any())
                return resp;

            var movimentoAdd = _mapper.Map<MoveAccount>(request);

            if (contaCorrente is not null)
            {
                movimentoAdd.IdCheckingAccount = contaCorrente.Id;
                _moveAccount.Add(movimentoAdd);
            }


            await _moveAccount.UnitOfWork.CommitAsync();
            return resp;
        }

        private async Task<CheckAccount?> MovimentIsValid(CheckAccountRequest request)
        {

            string[] tipoMovimentoValid = { "C", "D" };

            if (request.Value <= 0)
                _notify.Add(new Notify { Message = _langSystem.InvalidValue() });

            var numeroConta = request.Number;

            CheckAccount? contaCorrente = await CurrentAccountIsValid(numeroConta);

            if (!tipoMovimentoValid.Any(x => x == request.MoveType))
                _notify.Add(new Notify { Message = _langSystem.InvalidType() });

            return contaCorrente;
        }

        private async Task<CheckAccount?> CurrentAccountIsValid(int numeroConta)
        {
            var contaCorrente = (await _checkAccount.RepositoryConsult.SearchAsync(x => x.Number == numeroConta, true))
                                  ?.FirstOrDefault();

            if (contaCorrente is null)
                _notify.Add(new Notify { Message = _langSystem.InvalidAccount() });

            if (contaCorrente is not null
                              && !contaCorrente.IsActive)
                _notify.Add(new Notify { Message = _langSystem.InactiveAccount() });
            return contaCorrente;
        }
    }
}
