﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Infrastructure.Helpers
{
    public interface ILocalStorageHelper
    {
        Task SetItemAsync<T>(string key, T data);
        Task<T> GetItemAsync<T>(string key);
    }
}