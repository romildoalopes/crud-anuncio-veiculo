using Flunt.Validations;
using Flunt.Notifications;
using MediatR;


namespace CrudAnuncioVeiculo.Domain.Commands
{
    public class BaseAnuncioCommand : Notifiable, IRequest<RequestResult>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }


    }

}
