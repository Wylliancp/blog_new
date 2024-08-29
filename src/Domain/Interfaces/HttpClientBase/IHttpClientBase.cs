using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.HttpClientBase
{
    public interface IHttpClientBase<T> where T : class
    {
        Task<T> OnGetAsync(IDictionary<string,string> headers, string uri);
        T OnGet(IDictionary<string, string> headers, string uri);
        Task<List<T>> OnGetAllAsync(IDictionary<string, string> headers, string uri);
        List<T> OnGetAll(IDictionary<string, string> headers, string uri);
        Task<TResp> OnPostAsync<TResp>(IDictionary<string, string> headers, string uri, T data);
        TResp OnPost<TResp>(IDictionary<string, string> headers, string uri, T data);
        Task<bool> OnUpdateAsync<TResp>(IDictionary<string, string> headers, string uri, T data);
        bool OnUpdate<TResp>(IDictionary<string, string> headers, string uri, T data);
        Task<bool> OnDeleteAsync<TResp>(IDictionary<string, string> headers, string uri, T data);
        bool OnDelete<TResp>(IDictionary<string, string> headers, string uri, T data);
    }
}
