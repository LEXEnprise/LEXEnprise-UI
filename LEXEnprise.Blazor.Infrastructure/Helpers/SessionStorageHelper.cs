using Blazored.SessionStorage;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Infrastructure.Helpers
{
    public class SessionStorageHelper : ISessionStorageHelper
    {
        private readonly ISessionStorageService _sessionStorage;

        public SessionStorageHelper(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task SetItemAsync<T>(string key, T data)
        {
            await _sessionStorage.SetItemAsync<T>(key, data);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var data = await _sessionStorage.GetItemAsync<T>(key);

            return data;
        }

        public async Task RemoveItemAsync(string key)
        {
            await _sessionStorage.RemoveItemAsync(key);
        }
    }
}
