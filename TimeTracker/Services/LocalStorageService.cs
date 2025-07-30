using Microsoft.JSInterop;
using System.Text.Json;

namespace TimeTracker.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItemAsync<T>(string key);
        Task SetItemAsync<T>(string key, T Value);
        Task RemoveItemAsync(string key);
    }
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jSRuntime;

        public LocalStorageService(IJSRuntime jSRuntime) 
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task RemoveItemAsync(string key)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task SetItemAsync<T>(string key, T Value)
        {
            var json = JsonSerializer.Serialize(Value);
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
        }
        List
    }
}
