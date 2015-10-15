namespace ConsoleWebServer.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    }
}
