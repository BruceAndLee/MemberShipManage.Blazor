using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Utility
{
    public static class CommonJsHelper
    {
        public static async Task ShowInfo(this IJSRuntime _jsRuntime, string message)
        {
            await _jsRuntime.InvokeVoidAsync("messager.showInfo", message);
        }

        public static async Task ShowSuccess(this IJSRuntime _jsRuntime, string message)
        {
            await _jsRuntime.InvokeVoidAsync("messager.showSuccess", message);
        }

        public static async Task ShowError(this IJSRuntime _jsRuntime, string message)
        {
            await _jsRuntime.InvokeVoidAsync("messager.showError", message);
        }
    }
}
