using Core.Picareta.Comunication;
using Microsoft.Extensions.DependencyInjection;

namespace admin.picareta.car.Setup.Core
{
    public static class CoreIoc
    {
        public static void RegisterCoreDependencies(this IServiceCollection services)
        {
            services.AddScoped<IComunication, ComunicationHandler>();
        }
    }
}
