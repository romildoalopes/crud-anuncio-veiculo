using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.Entities;

namespace CrudAnuncioVeiculo.Domain.Repositories
{
    public interface IAnuncioRepository
    {
        Task Adicionar(CriarAnuncioCommand command);
        Task<IEnumerable<tb_AnuncioWebmotors>> Obter();
        Task<tb_AnuncioWebmotors> Obter(int id);
        Task Atualizar(AlterarAnuncioCommand command);
        Task Deletar(int id);
    }
}
