using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var response = await _http.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(content);
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

        public async Task<List<DetalleViewModel>> GetPostsCompletosAsync()
        {
            var posts = await GetPostsAsync();
            var users = await _http.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users");
            var comments = await _http.GetFromJsonAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");

            var resultado = posts.Select(post => new DetalleViewModel
            {
                Post = post,
                Autor = users.FirstOrDefault(u => u.id == post.userId),
                Comentarios = comments.Where(c => c.postId == post.id).ToList()
            }).ToList();

            return resultado;
        }
    }
}
