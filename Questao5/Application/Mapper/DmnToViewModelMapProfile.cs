using AutoMapper;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.Mapper
{
    public class DmnToViewModelMapProfile : Profile
    {
        public DmnToViewModelMapProfile()
        {
            CreateMap<CheckAccount, BalanceViewModel>();
        }
    }
}
