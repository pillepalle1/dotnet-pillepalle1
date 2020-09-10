using System.Threading.Tasks;

namespace dotnet_pillepalle1.Collections
{
    public interface IAsyncCollection<T> : System.Collections.Generic.IAsyncEnumerable<T>
    {
        Task Add(T item);
        Task<bool> Remove(T item);
        Task Clear();
        Task<bool> Contains(T item);
        Task CopyTo(T[] array, int arrayIndex);

        Task<int> Count { get; }
        Task<bool> IsReadOnly { get; }
        object SyncRoot { get; }
    }
}