using AutoMapper;
using SimpleStackOverflow.Infrastructure.UnitofWorks;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public class VoteService : IVoteService
    {
        private readonly IInfrastructureUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public VoteService(IInfrastructureUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }


    }
}
