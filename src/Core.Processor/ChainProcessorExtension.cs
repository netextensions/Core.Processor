namespace NetExtensions
{
    public static class ChainProcessorExtension
    {
        public static IProcessor<T> Then<T>(
            this IProcessor<T> first, IProcessor<T> next)
        {
            if (first is NullProcessor<T>) return next;

            return next is NullProcessor<T> ? first : new ChainedProcessor<T>(first, next);
        }
    }
}