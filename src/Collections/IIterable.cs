namespace Finance.Model.Collections
{
    public interface IIterable<T>
    {
        T this[int index] { get; }
        int Count { get; }
    }
}