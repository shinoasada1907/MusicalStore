namespace MusicalStore.Services
{
    public interface IRenderViewToString
    {
        public Task<string> RenderViewToStringAsync(string viewName, object model);
    }
}
