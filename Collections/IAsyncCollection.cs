using System.Threading.Tasks;

namespace dotnet_pillepalle1.Collections
{
    public interface IAsyncCollection<T> : System.Collections.Generic.IAsyncEnumerable<T>
    {
        /// <summary>
        /// Adds an item to the ICollection<T>.
        /// </summary>
        /// <param name="item">The object to add to the ICollection<T>.</param>
        Task AddAsync(T item);

        /// <summary>
        /// Removes the first occurrence of a specific object from the ICollection<T>.
        /// </summary>
        /// <param name="item">The object to remove from the ICollection<T>.</param>
        /// <returns>true if item was successfully removed from the ICollection<T>; otherwise, false. This method also returns false if item is not found in the original ICollection<T>.</returns>
        Task<bool> RemoveAsync(T item);

        /// <summary>
        /// Removes all items from the ICollection<T>.
        /// </summary>
        Task ClearAsync();

        /// <summary>
        /// Determines whether the ICollection<T> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the ICollection<T>.</param>
        /// <returns>true if item is found in the ICollection<T>; otherwise, false.</returns>
        Task<bool> ContainsAsync(T item);

        /// <summary>
        /// Copies the elements of the ICollection<T> to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection<T>. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        Task CopyToAsync(T[] array, int arrayIndex);

        /// <summary>
        /// Gets the number of elements contained in the ICollection<T>
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Gets a value indicating whether the ICollection<T> is read-only.
        /// </summary>
        bool IsReadOnly { get; }
    }
}