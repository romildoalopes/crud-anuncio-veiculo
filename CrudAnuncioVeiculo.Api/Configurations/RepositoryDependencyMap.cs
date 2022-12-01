using CrudAnuncioVeiculo.Domain.Handlers;
using CrudAnuncioVeiculo.Domain.Repositories;
using CrudAnuncioVeiculo.Domain.Services.Anuncio;
using CrudAnuncioVeiculo.Domain.Services.Config;
using CrudAnuncioVeiculo.Infra.Repositories;
using CrudAnuncioVeiculo.Infra.Services;
using System.Text;
using MediatR;

namespace CrudAnuncioVeiculo.Api.Configurations
{
    public static class RepositoryDependencyMap
    {
        public static void RepositoryMap(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionConfig, ConnectionConfig>(sp =>
            {
                return new(
                    GetDBConnectionString()
                );
            });

            services.AddScoped<DbContext>();

            services.AddScoped<IAnuncioService, AnuncioService>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();

            services.AddMediatR(typeof(AlterarAnuncioHandler));
            services.AddMediatR(typeof(CriarAnuncioHandler));
        }

        public static string GetDBConnectionString()
        {
            StringBuilder sbConnectionString = new();

            sbConnectionString.Append("server=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_HOST"));
            sbConnectionString.Append(';');
            sbConnectionString.Append("database=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_DATABASE"));
            sbConnectionString.Append(';');
            sbConnectionString.Append("user id=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_USER"));
            sbConnectionString.Append(';');
            sbConnectionString.Append("password=");
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD"));
            sbConnectionString.Append(';');
            sbConnectionString.Append(Environment.GetEnvironmentVariable("SQLSERVER_ADDITIONAL_CONFIGS"));

            return sbConnectionString.ToString();
        }
    }
}
