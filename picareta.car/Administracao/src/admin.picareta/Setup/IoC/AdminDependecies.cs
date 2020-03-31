using Admin.Picareta.Commands;
using Admin.Picareta.Commands.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Picareta.Setup.IoC
{
    public static class AdminDependecies
    {
        public static void RegisterAdminDependencies(this IServiceCollection services)
        {
            //Repositories
            
            //Commands
            services.AddScoped<IRequestHandler<AdicionarIntencaoVendaCommand, bool>, IntencaoVendaCommandHandler>();

            //IntegrationEvents
        }
    }
}
