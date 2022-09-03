
namespace SimpleStackOverflow.Data
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        Task SaveAsync();
        void Save();
    }
}
