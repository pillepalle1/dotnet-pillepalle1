using System.Threading.Tasks;

namespace dotnet_pillepalle1.Collections
{
    public interface IAsyncCollection<T> : System.Collections.Generic.IAsyncEnumerable<T>
    {
        Task AddAsync(T item);
        Task<bool> RemoveAsync(T item);
        Task ClearAsync();
        Task<bool> ContainsAsync(T item);
        Task CopyToAsync(T[] array, int arrayIndex);

        Task<int> CountAsync { get; }
        Task<bool> IsReadOnlyAsync { get; }
    }
}