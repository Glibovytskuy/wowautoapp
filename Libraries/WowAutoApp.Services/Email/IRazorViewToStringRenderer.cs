using System;
using System.Threading.Tasks;

namespace WowAutoApp.Services.Email
{
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
