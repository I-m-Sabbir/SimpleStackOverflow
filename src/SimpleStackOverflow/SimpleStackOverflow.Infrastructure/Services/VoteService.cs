using AutoMapper;
using SimpleStackOverflow.Infrastructure.BusinessObjects;
using SimpleStackOverflow.Infrastructure.UnitofWorks;
using VoteEO = SimpleStackOverflow.Infrastructure.Entities.Vote;

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

        public async Task VoteAsync(Vote vote)
        {
            try
            {
                var entity = _mapper.Map<VoteEO>(vote);
                await _unitofWork.Votes.AddAsync(entity);
                await _unitofWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteVoteAsync(int commentId, Guid authorId)
        {
            try
            {
                await _unitofWork.Votes.RemoveAsync(x => x.CommentId == commentId
                && x.AuthorId == authorId);
                await _unitofWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task UpdateVoteAsync(Vote vote)
        {
            try
            {
                var entity = await _unitofWork.Votes.GetByIdAsync(vote.Id);
                _mapper.Map(vote, entity);
                await _unitofWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
