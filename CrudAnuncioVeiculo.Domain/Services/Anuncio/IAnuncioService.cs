using CrudAnuncioVeiculo.Domain.Commands;

namespace CrudAnuncioVeiculo.Domain.Services.Anuncio
{
    public interface IAnuncioService
    {
        Task<RequestResult> Obter();
        Task<RequestResult> Deletar(int id);
    }
}
