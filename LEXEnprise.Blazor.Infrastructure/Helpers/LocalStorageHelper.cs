using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Infrastructure.Helpers
{
    public class LocalStorageHelper : ILocalStorageHelper
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorageHelper(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SetItemAsync<T>(string key, T data)
        {
            await _localStorage.SetItemAsync<T>(key, data);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var data = await _localStorage.GetItemAsync<T>(key);

            return data;
        }

        public async Task RemoveItemAsync(string key)
        {
            await _localStorage.RemoveItemAsync(key);
        }
    }
}
