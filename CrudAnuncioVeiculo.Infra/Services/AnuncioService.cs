using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.DTOs;
using CrudAnuncioVeiculo.Domain.Repositories;
using CrudAnuncioVeiculo.Domain.Services.Anuncio;

namespace CrudAnuncioVeiculo.Infra.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public async Task<RequestResult> Deletar(int id)
        {
            var result = await _anuncioRepository.Obter(id);

            if (result == null)
                return new RequestResult("Campo Id não informado ou está inválido!", false);

            await _anuncioRepository.Deletar(id);

            return new RequestResult("Registro deletado", true);
        }

        public async Task<RequestResult> Obter()
        {
            var result = await _anuncioRepository.Obter();

            if (!result.Any())
                return new RequestResult("Nenhum dado encontrado", false);

            var resultDto = result.Select(anuncio => (AnuncioWebMotorsDTO)anuncio);

            return new RequestResult("Dados filtrados com sucesso", resultDto);
        }
    }
}
