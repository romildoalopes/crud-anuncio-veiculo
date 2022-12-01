using CrudAnuncioVeiculo.Domain.Commands;
using CrudAnuncioVeiculo.Domain.Repositories;
using MediatR;

namespace CrudAnuncioVeiculo.Domain.Handlers
{
    public class AlterarAnuncioHandler : IRequestHandler<AlterarAnuncioCommand, RequestResult>
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public AlterarAnuncioHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }
        public async Task<RequestResult> Handle(AlterarAnuncioCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new RequestResult("", request.Notifications);


            var result = await _anuncioRepository.Obter(request.Id);
            
            if (result == null)
                return new RequestResult("Campo Id não informado ou está inválido!", false);

            await _anuncioRepository.Atualizar(request);
            return new RequestResult("Anúncio atualizado com sucesso", true);
        }
    }
}
