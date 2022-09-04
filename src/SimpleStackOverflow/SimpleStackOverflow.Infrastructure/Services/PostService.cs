using AutoMapper;
using SimpleStackOverflow.Infrastructure.BusinessObjects;
using SimpleStackOverflow.Infrastructure.UnitofWorks;
using PostEO = SimpleStackOverflow.Infrastructure.Entities.Post;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IInfrastructureUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public PostService(IInfrastructureUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<(int total, int totalDisplay, List<Post>)> GetPostsAsync(Guid id, int pageIndex,
            int pageSize)
        {
            var list = await _unitofWork.Posts.GetDynamicAsync(x => x.AuthorId == id, "CreateTime desc",
                "Votes,Author", pageIndex, pageSize, true);
            
            List<Post> posts = new List<Post>();
            foreach (var post in list.data)
            {
                posts.Add(_mapper.Map<Post>(post));
            }
            return (list.total, list.totalDisplay, posts);
        }

        public async Task CreatePostAsync(Post post)
        {
            try
            {
                var entity = _mapper.Map<PostEO>(post);
                await _unitofWork.Posts.AddAsync(entity);
                await _unitofWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Post> GetPostAsync(int id)
        {
            try
            {
                var entity = (await _unitofWork.Posts.GetAsync(x => x.Id == id, "Author,Comments,Author,Votes,Author"))
                    .FirstOrDefault();
                return _mapper.Map<Post>(entity);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
