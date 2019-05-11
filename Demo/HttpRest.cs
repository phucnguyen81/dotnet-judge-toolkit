using System;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace Judge
{
    /**
     * Make REST calls and retrieve responses.
     */
    internal class Rest
    {
        internal class Request
        {
            internal string URL;
            internal string Method;
            internal string Json;

            internal Request(string url, string method, string json = "")
            {
                URL = url;
                Method = method;
                Json = json;
            }
        }

        internal class Response
        {
            internal bool IsSuccessStatusCode = false;
            internal string StatusCode = "";
            internal string StatusMessage = "";
            internal string Json = "";
        }

        internal static Response Send(Request request)
        {
            string url = request.URL;
            string method = request.Method;
            string contentJson = request.Json;

            HttpMethod httpMethod = new HttpMethod(method);
            StringContent content = null;
            if (!string.IsNullOrWhiteSpace(contentJson))
            {
                content = new StringContent(
                        contentJson, Encoding.UTF8, "application/json");
            }

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequest = new HttpRequestMessage(
                            httpMethod, url))
                {
                    if (content != null)
                    {
                        httpRequest.Content = content;
                    }
                    Task<HttpResponseMessage> responseTask;
                    responseTask = httpClient.SendAsync(httpRequest);
                    using (HttpResponseMessage httpResponse = responseTask.Result)
                    {
                        Task<string> task = httpResponse.Content.ReadAsStringAsync();
                        return new Response()
                        {
                            IsSuccessStatusCode = httpResponse.IsSuccessStatusCode,
                            StatusCode = httpResponse.StatusCode.ToString(),
                            StatusMessage = httpResponse.ReasonPhrase,
                            Json = task.Result
                        };
                    }
                }
            }
        }
    }
}
