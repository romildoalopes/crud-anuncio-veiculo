using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.Entities;
using CrudAnuncioVeiculo.Domain.Repositories;
using CrudAnuncioVeiculo.Infra.Services;
using Dapper;

namespace CrudAnuncioVeiculo.Infra.Repositories
{
    public class AnuncioRepository : BaseRepository, IAnuncioRepository
    {
        public AnuncioRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task Adicionar(CriarAnuncioCommand command)
        {
            var sql = @$"INSERT INTO tb_AnuncioWebmotors 
                            VALUES (@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao)";

            var param = new DynamicParameters();
            param.Add("@Marca", command.Marca);
            param.Add("@Modelo", command.Modelo);
            param.Add("@Versao", command.Versao);
            param.Add("@Ano", command.Ano);
            param.Add("@Quilometragem", command.Quilometragem);
            param.Add("@Observacao", command.Observacao);

            await _context.Connection.ExecuteAsync(sql: sql, param: param);
        }   

        public async Task Atualizar(AlterarAnuncioCommand command)
        {
            var sql = @$"   UPDATE tb_AnuncioWebmotors 
                            SET marca = ISNULL(@Marca,marca), 
                                modelo = ISNULL(@Modelo,modelo), 
                                versao = ISNULL(@Versao,versao), 
                                ano = ISNULL(@Ano,ano), 
                                quilometragem = ISNULL(@Quilometragem,quilometragem), 
                                observacao = ISNULL(@Observacao,observacao)
                                WHERE ID = @Id";

            var param = new DynamicParameters();
            param.Add("@Marca", command.Marca);
            param.Add("@Modelo", command.Modelo);
            param.Add("@Versao", command.Versao);
            param.Add("@Ano", command.Ano);
            param.Add("@Quilometragem", command.Quilometragem);
            param.Add("@Observacao", command.Observacao);
            param.Add("@Id", command.Id);

            await _context.Connection.ExecuteAsync(sql: sql, param: param);
        }

        public async Task Deletar(int id)
        {
            var sql = @$"DELETE FROM tb_AnuncioWebmotors 
                         WHERE ID = @Id";

            var param = new DynamicParameters();
            param.Add("@Id", id);

            await _context.Connection.ExecuteAsync(sql: sql, param: param);
        }

        public async Task<IEnumerable<tb_AnuncioWebmotors>> Obter()
        {
            var sql = @$"SELECT * FROM tb_AnuncioWebmotors";
            return await _context.Connection.QueryAsync<tb_AnuncioWebmotors>(sql: sql);
        }

      
        public async Task<tb_AnuncioWebmotors> Obter(int id)
        {
            var sql = @$"SELECT * FROM tb_AnuncioWebmotors WHERE ID = @id";

            var param = new DynamicParameters();
            param.Add("@id", id);

            await _context.Connection.ExecuteAsync(sql: sql, param: param);
            return await _context.Connection.QueryFirstOrDefaultAsync<tb_AnuncioWebmotors>(sql: sql, param: param);
        }
    }
}
