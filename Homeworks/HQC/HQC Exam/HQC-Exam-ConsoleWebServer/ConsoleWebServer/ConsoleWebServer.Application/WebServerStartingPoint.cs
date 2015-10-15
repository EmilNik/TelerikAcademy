namespace ConsoleWebServer.Application
{
    using System;
    using System.Text;
    using Framework;

    public class WebServerStartingPoint
    {
        public static void Main()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            var responseProvider = new ResponseProvider();

            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = responseProvider.GetResponse(requestBuilder.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}
