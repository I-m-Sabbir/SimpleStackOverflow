using SimpleStackOverflow.Infrastructure.BusinessObjects;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public interface IPostService
    {
        Task<(int total, int totalDisplay, List<Post>)> GetPostsAsync(Guid id, int pageIndex,
            int pageSize);
        Task<(int total, int totalDisplay, List<Post>)> GetAllPostsAsync(int pageIndex,
            int pageSize);
        Task CreatePostAsync(Post post);
        //Task DeletePostAsync(int id);
        Task<Post> GetPostAsync(int id);
        Task<Post> GetPostWithIncludeAsync(int id);
        Task UpdateAsync(Post post);
    }
}
