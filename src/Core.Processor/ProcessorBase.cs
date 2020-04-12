using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetExtensions
{
    public abstract class ProcessorBase<T> : IProcessor<T>
    {
        private readonly IProcessor<T>[] _processors;

        protected ProcessorBase(params IProcessor<T>[] processors)
        {
            _processors = processors;
        }
        public async Task<T> ExecuteAsync(T payload, CancellationToken token)
        {
            var result = _processors.Aggregate((IProcessor<T>)new NullProcessor<T>(), (current, processor) => ChainProcessorExtension.Then<T>(current, processor));
            return await result.ExecuteAsync(payload, token).ConfigureAwait(false);
        }
    }
}