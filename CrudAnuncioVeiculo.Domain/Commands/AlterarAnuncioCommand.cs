using Flunt.Validations;

namespace CrudAnuncioVeiculo.Domain.Commands
{
    public class AlterarAnuncioCommand : BaseAnuncioCommand, IValidatable
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract()
           .Requires()
           .IsGreaterThan(Id, 0, "Id", "Campo Id não informado ou está inválido!"));
        }

    }
}
