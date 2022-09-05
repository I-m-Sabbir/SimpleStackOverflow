using AutoMapper;
using SimpleStackOverflow.Infrastructure.BusinessObjects;
using SimpleStackOverflow.Infrastructure.UnitofWorks;
using CommentEO = SimpleStackOverflow.Infrastructure.Entities.Comment;

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

        public async Task CreateAsync(Comment comment)
        {
            try
            {
                var entity = _mapper.Map<CommentEO>(comment);
                await _unitofWork.Comments.AddAsync(entity);
                await _unitofWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Comment> GetAsync(int id)
        {
            try
            {
                var entity = await _unitofWork.Comments.GetByIdAsync(id);
                return _mapper.Map<Comment>(entity);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task VerifyCommentAsync(Comment comment)
        {
            try
            {
                var entity = await _unitofWork.Comments.GetByIdAsync(comment.Id);
                _mapper.Map(comment, entity);
                await _unitofWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
