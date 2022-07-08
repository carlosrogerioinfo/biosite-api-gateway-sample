using Biosite.Core.Extensions;
using Biosite.Core.Response;
using FluentValidator;

namespace Biosite.Main.Gateway.Service.Base
{
    public abstract class ServiceBase : Notifiable
    {
        protected virtual bool ResponseErrorHandling(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                case 400:
                    SetError(response);
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        private void SetError(HttpResponseMessage response)
        {
            var notifications = response.Content.ReadJsonAsync<ResponseError>("error").Result;
            foreach (var item in notifications.Errors)
            {
                AddNotification(item.Property, item.Message);
            }
        }
    }
}
