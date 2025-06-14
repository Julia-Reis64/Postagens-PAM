using Postagens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Postagens.Services
{
    public class PostService
    {
        string base_url = "https://jsonplaceholder.typicode.com";
        PostModel postagem;
        JsonSerializerOptions serializerOptions;

        PostService() {
            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true

            };
        }
        public async Task<PostModel> getPost()
        {
            Uri uri = new Uri($"{base_url}/posts");
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            string content = await responseMessage.Content.ReadAsStringAsync();
            postagem = JsonSerializer.Deserialize < PostModel >(content, serializerOptions);
            return postagem;
        }
    }
}
