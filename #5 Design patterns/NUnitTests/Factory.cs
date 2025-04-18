public static class PageObjectFactory
{
    public static T Create<T>() where T : BasePage, new()
    {
        return new T();
    }
}
