public interface IFactory<TSource>
{
    T Get<T>(bool isActive) where T : TSource;
}
