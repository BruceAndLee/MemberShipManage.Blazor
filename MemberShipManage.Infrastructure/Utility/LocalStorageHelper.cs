using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Utility
{
    public static class LocalStorageHelper
    {
        public static async Task SetLocalStorage(this IJSRuntime _jsRuntime, string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("SetLocalStorage", key, value);
        }

        public static async Task<string> GetLocalStorage(this IJSRuntime _jsRuntime, string key)
        {
            return await _jsRuntime.InvokeAsync<string>("GetLocalStorage", key);
        }

        public static async Task RemoveLocalStorage(this IJSRuntime _jsRuntime, string key)
        {
            await _jsRuntime.InvokeAsync<string>("RemoveLocalStorage", key);
        }

        public static async Task SetSessionStorage(this IJSRuntime _jsRuntime, string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("SetSessionStorage", key, value);
        }

        public static async Task<string> GetSessionStorage(this IJSRuntime _jsRuntime, string key)
        {
            return await _jsRuntime.InvokeAsync<string>("GetSessionStorage", key);
        }

        public static async Task RemoveSessionStorage(this IJSRuntime _jsRuntime, string key)
        {
            await _jsRuntime.InvokeAsync<string>("RemoveSessionStorage", key);
        }
    }
}
