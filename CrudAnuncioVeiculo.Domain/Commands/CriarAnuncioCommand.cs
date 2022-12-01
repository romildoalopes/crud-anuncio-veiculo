using Flunt.Validations;

namespace CrudAnuncioVeiculo.Domain.Commands
{
    public class CriarAnuncioCommand : BaseAnuncioCommand, IValidatable
    {
        public void Validate()
        {
            AddNotifications(
            new Contract()
           .Requires()
           .IsNotNull(Marca, "Marca", "Campo Marca não informado ou está inválido!")
           .IsNotNullOrEmpty(Modelo, "Modelo", "Campo Modelo não informado ou está inválido!")
           .IsNotNullOrEmpty(Versao, "Versao", "Campo Versao não informado ou está inválido!")
           .IsGreaterThan(Ano, 0, "Ano", "Campo ano não informado ou está inválido!")
           .IsNotNullOrEmpty(Observacao, "Observacao", "Campo Observacao não pode ser nulo"));
        }
    }
}
