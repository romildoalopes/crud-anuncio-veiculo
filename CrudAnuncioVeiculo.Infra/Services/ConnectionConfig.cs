using CrudAnuncioVeiculo.Domain.Services.Config;

namespace CrudAnuncioVeiculo.Infra.Services
{
    public class ConnectionConfig : IConnectionConfig
    {
        private readonly string _connection;

        public ConnectionConfig(string connection)
        {
            _connection = connection;
        }

        public string GetConnectionString()
        {
            return _connection;
        }
    }
}
