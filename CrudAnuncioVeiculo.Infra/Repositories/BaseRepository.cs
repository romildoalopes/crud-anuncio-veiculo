using CrudAnuncioVeiculo.Infra.Services;
using System.Data.SqlClient;

namespace CrudAnuncioVeiculo.Infra.Repositories
{
    public class BaseRepository 
    {
        protected SqlTransaction transaction;
        protected DbContext _context;

        public BaseRepository()
        {
        }

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;

        }
    }
}
