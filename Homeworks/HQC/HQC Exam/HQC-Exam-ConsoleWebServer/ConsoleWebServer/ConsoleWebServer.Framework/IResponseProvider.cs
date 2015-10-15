namespace ConsoleWebServer.Framework
{
    /// <summary>
    /// An interface that provides Http Responses.
    /// </summary>
    public interface IResponseProvider
    {
        /// <summary>
        /// Gest a Http response from a given request.
        /// </summary>
        /// <param name="requestAsString">Http Request given as a string.</param>
        /// <returns>Http Response.</returns>
        HttpResponse GetResponse(string requestAsString);
    }
}
