using System.Threading;
using System.Threading.Tasks;

namespace NetExtensions
{
    public interface IProcessor<T>
    {
        Task<T> ExecuteAsync(T payload, CancellationToken token);
    }
}