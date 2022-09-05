using AutoMapper;
using SimpleStackOverflow.Infrastructure.UnitofWorks;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IInfrastructureUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public CommentService(IInfrastructureUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }


    }
}
