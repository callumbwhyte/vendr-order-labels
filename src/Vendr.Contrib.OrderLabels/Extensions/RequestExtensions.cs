using System.Net.Http;
using System.Net.Http.Headers;

namespace Vendr.Contrib.OrderLabels.Extensions
{
    internal static class RequestExtensions
    {
        public static HttpResponseMessage CreateFileResponse(this HttpRequestMessage request, string name, byte[] content)
        {
            var response = request.CreateResponse();

            response.Content = new ByteArrayContent(content);

            response.Content.Headers.Add("x-filename", name);

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = name
            };

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return response;
        }
    }
}