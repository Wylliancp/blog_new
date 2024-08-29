using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Domain.Utils
{
    public static class JsonSerialize
    {
        public static string ToJson<T>(this T model) where T : class
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
