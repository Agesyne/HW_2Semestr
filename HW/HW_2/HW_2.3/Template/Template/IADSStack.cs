

namespace CalculatingStack
{
    public interface IADSStack
    {
        int Count { get; }

        void Push(int value);
        int Pop();
        int Peek();
        bool IsEmpty();
    }
}
