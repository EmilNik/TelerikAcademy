using System.Collections.Generic;

namespace ConsoleWebServer.Framework
{
    /// <summary>
    /// Basic Action Result interface that contains the method GetResponse();
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// Response Headers are the headers passed to the Result.
        /// </summary>
        List<KeyValuePair<string, string>> ResponseHeaders { get; }

        /// <summary>
        /// Gets a http response from a given http request.
        /// </summary>
        /// <returns>Http Response.</returns>
        HttpResponse GetResponse();
    }
}
