using Biosite.Core.Extensions;
using Biosite.Core.Response;
using FluentValidator;

namespace Biosite.Main.Gateway.Service.Base
{
    public abstract class ServiceBase : Notifiable
    {
        protected bool ResponseErrorHandling(HttpResponseMessage response)
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
            if ((int)response.StatusCode == 401)
            {
                AddNotification("Autenticação", "Usuário não autorizado");
                return;
            }

            if ((int)response.StatusCode == 403)
            {
                AddNotification("Autenticação", "Usuário sem permissão para efetuar essa requisição");
                return;
            }

            var notifications = response.Content.ReadJsonAsync<ResponseError>("error").Result;
            foreach (var item in notifications.Errors)
            {
                AddNotification(item.Property, item.Message);
            }
        }
    }
}
