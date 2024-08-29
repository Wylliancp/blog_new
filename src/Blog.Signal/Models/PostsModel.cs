using System;
using System.Text.Json.Serialization;

namespace Blog.Signal.Models
{
    public class PostModel
    {
        public PostModel(string title, int sum)
        {
            Title = title;
            Sum = sum;
        }

        [JsonPropertyName("title")]
        public string Title { get; private set; }
        [JsonPropertyName("sum")]
        public int Sum { get; private set; }

    }
}
