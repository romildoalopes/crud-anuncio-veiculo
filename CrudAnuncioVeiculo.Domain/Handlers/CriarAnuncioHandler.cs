using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.Repositories;
using MediatR;

namespace CrudAnuncioVeiculo.Domain.Handlers
{
    public class CriarAnuncioHandler : IRequestHandler<CriarAnuncioCommand, RequestResult>
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public CriarAnuncioHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public async Task<RequestResult> Handle(CriarAnuncioCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new RequestResult("", request.Notifications);

            await _anuncioRepository.Adicionar(request);
            return new RequestResult("Anúncio criado com sucesso", true);
        }
    }
}
