using Domain.Interfaces.HttpClientBase;
using Domain.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.HttpClientBase
{
    public abstract class HttpClientBase<T> : IHttpClientBase<T> where T : class
    {
        private readonly HttpClient _client;
        public HttpClientBase(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(this.GetType().Name);
        }

        public T OnGet(IDictionary<string, string> headers, string uri)
        {
            T obj = default;

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = _client.Send(request);

            if(response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                return obj;
            }
        }

        public List<T> OnGetAll(IDictionary<string, string> headers, string uri)
        {
            List<T> obj = default;

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = _client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(responseJson);
            }
            else
            {
                return obj;
            }
        }

        public async Task<List<T>> OnGetAllAsync(IDictionary<string, string> headers, string uri)
        {
            List<T> obj = default;

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await _client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(responseJson);
            }
            else
            {
                return obj;
            }
        }

        public async Task<T> OnGetAsync(IDictionary<string, string> headers, string uri)
        {
            T obj = default;

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                return obj;
            }
        }

        public TResp OnPost<TResp>(IDictionary<string, string> headers, string uri, T data)
        {
            TResp obj = default;

            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
            };

            foreach (var header in  headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = _client.Send(request);

            if(response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResp>(responseJson);
            }
            else
            {
                return obj;
            }
        }

        public async Task<TResp> OnPostAsync<TResp>(IDictionary<string, string> headers, string uri, T data)
        {
            TResp obj = default;

            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
            };

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResp>(responseJson);
            }
            else
            {
                return obj;
            }
        }

        public bool OnUpdate<TResp>(IDictionary<string, string> headers, string uri, T data)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
            };

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = _client.Send(request);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> OnUpdateAsync<TResp>(IDictionary<string, string> headers, string uri, T data)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
            };

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await _client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool OnDelete<TResp>(IDictionary<string, string> headers, string uri, T data)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
            };

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = _client.Send(request);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> OnDeleteAsync<TResp>(IDictionary<string, string> headers, string uri, T data)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
            };

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await _client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
