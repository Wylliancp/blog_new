using System.Text.Json.Serialization;

namespace Blog.Signal.Models
{
    public class PostModel
    {
        public PostModel()
        {
        }

        public PostModel(string title, int sum)
        {
            Title = title;
            Sum = sum;
        }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("sum")]
        public int Sum { get; set; }

    }
}
