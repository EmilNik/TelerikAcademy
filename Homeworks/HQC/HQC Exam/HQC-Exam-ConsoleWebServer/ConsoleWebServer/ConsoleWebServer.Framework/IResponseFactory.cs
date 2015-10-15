namespace ConsoleWebServer.Framework
{
    public interface IResponseFactory
    {
        HttpResponse CreateResponse(HttpRequest request);
    }
}