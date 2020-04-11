using System.Threading;
using System.Threading.Tasks;

namespace NetExtensions
{
    public class NullProcessor<T> : IProcessor<T>
    {
        public async Task<T> ExecuteAsync(T payload, CancellationToken token)
        {
            return await Task.FromResult(payload).ConfigureAwait(false);
        }
    }
}