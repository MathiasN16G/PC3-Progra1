using System.Net.Http;
using System.Text.Json;
using PC3_Progra1.Models;

namespace PC3_Progra1.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var response = await _http.GetAsync("https://jsonplaceholder.typicode.com/posts");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(content);
        }

        public async Task<User> GetAuthorAsync(int userId)
        {
            var response = await _http.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(content);
        }

        public async Task<List<Comment>> GetCommentsAsync(int postId)
        {
            var response = await _http.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Comment>>(content);
        }
    }
}
