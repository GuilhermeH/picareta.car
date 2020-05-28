using Admin.Picareta.Application.Queries;
using Admin.Picareta.Commands;
using Admin.Picareta.Commands.Handlers;
using Admin.Picareta.Data.Repositories;
using Admin.Picareta.Domain.Commands;
using Admin.Picareta.Domain.Commands.Handlers;
using Admin.Picareta.Domain.Interfaces.Repositories;
using Admin.Picareta.Domain.Queries.Interfaces;
using Admin.Picareta.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace admin.picareta.car.Setup.Admin.IoC
{
    public static class AdminIoC
    {
        public static void RegisterAdminDependencies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IIntencaoVendaRepository, IntencaoVendaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();

            //Queries
            services.AddScoped<IIntencaoVendaQuery, IntencaoVendaQuery>();

            //Commands
            services.AddScoped<IRequestHandler<AdicionarIntencaoVendaCommand, bool>, IntencaoVendaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarModeloCommand, bool>, ModeloCommandHandler>();

            //IntegrationEvents
        }
    }
}
