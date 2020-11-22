using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

        public static HttpResponseMessage CreateZipResponse(this HttpRequestMessage request, string name, IDictionary<string, byte[]> files)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        var entry = archive.CreateEntry(file.Key);

                        using (var entryStream = entry.Open())
                        {
                            entryStream.Write(file.Value, 0, file.Value.Length);
                        }
                    }
                }

                return request.CreateFileResponse(name, memoryStream.ToArray());
            }
        }
    }
}