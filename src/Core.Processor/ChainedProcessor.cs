using System.Threading;
using System.Threading.Tasks;

namespace NetExtensions
{
    public class ChainedProcessor<T> : IProcessor<T>
    {
        public ChainedProcessor(IProcessor<T> inner, IProcessor<T> next)
        {
            Inner = inner;
            Next = next;
        }

        private IProcessor<T> Inner { get; }
        private IProcessor<T> Next { get; }

        public async Task<T> ExecuteAsync(T payload, CancellationToken token)
        {
            return await Next.ExecuteAsync(await Inner.ExecuteAsync(payload, token).ConfigureAwait(false), token)
                .ConfigureAwait(false);
        }
    }
}